using Telegram.Bot;
using Telegram.Bot.Types;
using TgBotLib;

namespace Main
{
    public class Program
    {
        volatile static string fileType = ""; // type of file the user chose in the menu of the bot
        volatile static string fileName = ""; // the name of the file the user uploaded in the bot
        volatile static Options option = Options.Default; // the option the user chose in the menu of the bot

        public static void Main()
        {

            JSONProcessing.CsvToJson(@"transport-changing-points"); // creating "transport-changing-points.json" file

            try
            {
                var botClient = new TelegramBotClient("7094277426:AAGYOBRlkSbmYlRyYUioHTD_HiCpkW5NwAc"); // connecting API

                botClient.StartReceiving(Update, Error); // starting the bot
                Console.ReadLine();

                
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Возникла непредвиденная ошибка.");
            }

        }

        public void FunctionHandler(int i)
        {
            Main();
        }

        /// <summary>
        /// Receives and manages updates from the bot
        /// </summary>
        /// <param name="client"></param>
        /// <param name="update"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        async public static Task Update(ITelegramBotClient client, Update update, CancellationToken token)
        {

            var message = update.Message;
            if (message == null) return;

            if (message.Text != null)
            {
                switch (message.Text)
                {
                    case "Прислать CSV файл":
                        fileType = ".csv";
                        await client.SendTextMessageAsync(message.Chat.Id, "Жду");
                        return;
                    case "Прислать JSON файл":
                        fileType = ".json";
                        await client.SendTextMessageAsync(message.Chat.Id, "Жду");
                        return;
                    case "Отсортировать по полю AvailableTransport (по алфавиту)":
                        Action(client, update, fileType, Options.SortAvailableTransportAscending);
                        return;
                    case "Отсортировать по полю YearOfCommisioning (по убыванию)":
                        Action(client, update, fileType, Options.SortYearOfCommisioningDescending);
                        return;
                    case "Сделать выборку по полю District":
                        option = Options.SelectByDisctrict;
                        await client.SendTextMessageAsync(message.Chat.Id, "Введите значения поля District:");
                        return;
                    case "Сделать выборку по полю CarCapacity":
                        option = Options.SelectByCarCapacity;
                        await client.SendTextMessageAsync(message.Chat.Id, "Введите значения поля CarCapacity:");
                        return;
                    case "Сделать выборку по полям Status и NearStation":
                        option = Options.SelectByStatusAndNearStation;
                        await client.SendTextMessageAsync(message.Chat.Id, "Введите значения полей Status и NearStation (в одном сообщении через перенос строки):");
                        return;
                    case "start" or "/start":
                        await client.SendTextMessageAsync(message.Chat.Id, "Выберите тип файла.", replyMarkup: Keyboard.FileTypeKeyboard());
                        return;
                    default:
                        if (option == Options.SelectByDisctrict) Action(client, update, fileType, option, message.Text);
                        else if (option == Options.SelectByCarCapacity) Action(client, update, fileType, option, message.Text);
                        else if (option == Options.SelectByStatusAndNearStation) Action(client, update, fileType, option, message.Text);
                        else if (fileType != "") await client.SendTextMessageAsync(message.Chat.Id, "Такой команды нет.\nВыберите команду.", replyMarkup: Keyboard.CommandKeyboard()); // the menu
                        else await client.SendTextMessageAsync(message.Chat.Id, "Эта команда не поддерживается.\nВведите /start для повторного запуска.");
                        option = Options.Default;
                        return;
                }
            }


            if (message.Document != null)
            {
                if (fileType == "")
                {
                    await client.SendTextMessageAsync(message.Chat.Id, "Перед отправкой нового файла перезапустите программу.\nВведите /start");
                    return;
                }

                // Getting Telegram's filePath.
                var field = message.Document.FileId;
                var fileInfo = await client.GetFileAsync(field);
                var filePath = fileInfo.FilePath;

                fileName = message.Document.FileName; // saving the original name of the file (to be used later)

                // Checking that recieved file is in the right format.
                if (!filePath.EndsWith(fileType))
                {
                    await client.SendTextMessageAsync(message.Chat.Id, "Файл имеет неверный формат. Повторите попытку.");
                    return;
                }

                // Downloading the file from Telegram to our computer
                string destinationFilePath = "transportation" + fileType;
                await using FileStream fileStream = System.IO.File.Create(destinationFilePath);
                await client.DownloadFileAsync(filePath, fileStream);
                fileStream.Close();

                await client.SendTextMessageAsync(message.Chat.Id, "Выберите команду.", replyMarkup: Keyboard.CommandKeyboard()); // the menu

                return;
            }
        }
        /// <summary>
        /// This method sorts or selects from the document and sends the output to the user of the bot
        /// </summary>
        /// <param name="client"></param>
        /// <param name="update"></param>
        /// <param name="fileType"></param>
        /// <param name="option"></param>
        /// <param name="value"></param>
        public static async void Action(ITelegramBotClient client, Update update, string fileType, Options option, params string[] value)
        {
            var message = update.Message;
            await using Stream stream = System.IO.File.OpenRead("transportation" + fileType);

            // Creating a list of TPUs from the file
            List<TPU> list;
            if (fileType == ".csv") list = CSVProcessing.Read(stream);
            else if (fileType == ".json") list = JSONProcessing.Read(stream);
            else
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Неизвестый формат файла.\nВведите /start для перезапуска программы.");
                return;
            }

            // Changing the list as the user pleases
            switch (option)
            {
                case Options.SortAvailableTransportAscending:
                    list = DataProcessing.Sort(list, "AvailableTransfer");
                    break;
                case Options.SortYearOfCommisioningDescending:
                    list = DataProcessing.Sort(list, "YearOfComissioning");
                    break;
                case Options.SelectByDisctrict:
                    list = DataProcessing.Select(list, new[] { "District" }, new[] { value[0] });
                    break;
                case Options.SelectByCarCapacity:
                    list = DataProcessing.Select(list, new[] { "CarCapacity" }, new[] { value[0] });
                    break;
                case Options.SelectByStatusAndNearStation:
                    string[] values = value[0].Split('\n');
                    list = DataProcessing.Select(list, new[] { "Status", "NearStation" }, new[] { values[0], values[1] });
                    break;
            }

            // Sending the result back to the user.
            if (fileType == ".csv")
            {
                using Stream newStream = CSVProcessing.Write(list);
                await client.SendDocumentAsync(message.Chat.Id, InputFile.FromStream(newStream, fileName));
            }
            else if (fileType == ".json")
            {
                using Stream newStream = JSONProcessing.Write(list);
                await client.SendDocumentAsync(message.Chat.Id, InputFile.FromStream(newStream, fileName));
            }

            fileType = "";
            await client.SendTextMessageAsync(message.Chat.Id, "Введите /start для перезапуска программы.");
        }

        /// <summary>
        /// Receives errors.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="exception"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            throw new NotImplementedException();
        }

    }
}