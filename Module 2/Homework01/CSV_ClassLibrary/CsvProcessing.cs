using System.Text.RegularExpressions;

namespace CSV_ClassLibrary
{
    public static class CsvProcessing
    {
        static string fPath = "";

        /// <summary>
        /// A property for setting and getting fPath
        /// </summary>
        public static string path
        {
            get { return fPath; }
            set { fPath = value; }
        }

        /// <summary>
        /// Prints lines in a .csv file in a readable format
        /// </summary>
        /// <param name="lines"></param>
        public static void Print(string[] lines)
        {
            if (lines == null) return; // cheking if the argument is null
            foreach (string line in lines)
            {
                string[] temp = Split(line);
                foreach (string temp_line in temp)
                {
                    Console.Write($"{temp_line};\t");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Spilts a string from the the .csv file into an array of values of each cell.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static string[] Split(string line)
        {
            if (line == null) return new string[0]; // cheking if the argument is null

            string[] temp = new string[12]; // method output
            int cnt = 0; // a counter
            foreach (Match match in Regex.Matches(line, @"""[^""]*""(?=;)"))
            {
                temp[cnt++] = match.Value;
            }
            Array.Resize(ref temp, cnt);
            return temp;
        }

        /// <summary>
        /// Returns an array(string[]) from a file at fPath.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string[] Read()
        {
            // cheking if the file exists
            if (!File.Exists(fPath)) throw new ArgumentNullException("Файла по этому пути не существует");

            string[] lines = File.ReadAllLines(fPath); // reading the CSV file

            // checking if the English header is correct
            if (lines[0] != "\"ID\";\"TPUName\";\"global_id\";\"AdmArea\";" +
                "\"District\";\"NearStation\";\"YearOfComissioning\";\"Status\";" +
                "\"AvailableTransfer\";\"CarCapacity\";\"geodata_center\";\"geoarea\";")
            {
                throw new ArgumentNullException("Данные в файле не соответствуют условию.");
            }

            // checking if the Russian header is correct
            if (lines[1] != "\"Локальный идентификатор\";\"Наименование транспортно-пересадочного узла\";\"global_id\";" +
                "\"Административный округ по адресу\";\"Район\";\"Станция метро или платформа, возле которой находится ТПУ\";" +
                "\"Год ввода в эксплуатацию\";\"Статус объекта\";\"Возможность пересадки\";\"Количество машиномест\";" +
                "\"geodata_center\";\"geoarea\";")
            {
                throw new ArgumentNullException("Данные в файле не соответствуют условию.");
            }

            // cheking that each line is in correct format
            for (int i = 2; i < lines.Length; i++)
            {
                MatchCollection matches = Regex.Matches(lines[i], @"(?<="")[^""]*(?="";)");
                if (matches.Count != 12) throw new ArgumentNullException("Данные в файле не соответствуют условию.");

            }

            return lines;
        }

        /// <summary>
        /// Appends lines to a file.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="nPath"></param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public static void Write(string text, string nPath)
        {
            if (!File.Exists(nPath)) File.WriteAllLines(nPath, File.ReadAllLines(fPath)[..2]); // appending headers
            File.AppendAllText(nPath, text);
        }

        /// <summary>
        /// Writes lines to a file.
        /// </summary>
        /// <param name="lines"></param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public static void Write(string[] lines)
        {
            File.WriteAllLines(fPath, lines);
        }
    }
}