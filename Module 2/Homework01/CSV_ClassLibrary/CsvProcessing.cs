using System.Text.RegularExpressions;

namespace CSV_ClassLibrary
{
    public static class CsvProcessing
    {
        static string fPath = @"..\..\..\transport-changing-points.csv";

        /// <summary>
        /// A property for setting and getting fPath
        /// </summary>
        public static string path
        {
            get { return fPath; }
            set { fPath = value; }
        }

        /// <summary>
        /// Returns an array(string[]) from a file at fPath.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string[] Read()
        {
            // cheking if the file exists
            if (!File.Exists(fPath)) throw new ArgumentNullException();

            string[] lines = File.ReadAllLines(fPath); // reading the CSV file

            // checking if the English header is correct
            if (lines[0] != "\"ID\";\"TPUName\";\"global_id\";\"AdmArea\";" +
                "\"District\";\"NearStation\";\"YearOfComissioning\";\"Status\";" +
                "\"AvailableTransfer\";\"CarCapacity\";\"geodata_center\";\"geoarea\";")
            {
                throw new ArgumentNullException();
            }

            // checking if the Russian header is correct
            if (lines[1] != "\"Локальный идентификатор\";\"Наименование транспортно-пересадочного узла\";\"global_id\";" +
                "\"Административный округ по адресу\";\"Район\";\"Станция метро или платформа, возле которой находится ТПУ\";" +
                "\"Год ввода в эксплуатацию\";\"Статус объекта\";\"Возможность пересадки\";\"Количество машиномест\";" +
                "\"geodata_center\";\"geoarea\";")
            {
                throw new ArgumentNullException();
            }

            // cheking that each line is in correct format
            for (int i = 2; i < lines.Length; i++)
            {
                MatchCollection matches = Regex.Matches(lines[i], @"(?<="")[^""]*(?="";)");
                if (matches.Count != 12) throw new ArgumentNullException();

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
            if (!Directory.Exists(nPath)) throw new DirectoryNotFoundException("Путь до файла указан некорректно.");
            File.AppendAllText(text, nPath);
        }

        /// <summary>
        /// Writes lines to a file.
        /// </summary>
        /// <param name="lines"></param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public static void Write(string[] lines)
        {
            if (!Directory.Exists(fPath)) throw new DirectoryNotFoundException("Путь до файла указан некорректно.");
            File.WriteAllLines(fPath, lines);
        }
    }
}