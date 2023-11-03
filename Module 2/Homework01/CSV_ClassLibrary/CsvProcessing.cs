using System.Text.RegularExpressions;

namespace CSV_ClassLibrary
{
    public static class CsvProcessing
    {
        static string fPath = @"..\..\..\transport-changing-points.csv";

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

            // checking if the header is correct
            if (lines[0] != "\"ID\";\"TPUName\";\"global_id\";\"AdmArea\";" +
                "\"District\";\"NearStation\";\"YearOfComissioning\";\"Status\";" +
                "\"AvailableTransfer\";\"CarCapacity\";\"geodata_center\";\"geoarea\";")
            {
                throw new ArgumentNullException();
            }

            // cheking that each line is in correct format
            for (int i = 1; i < lines.Length; i++)
            {
                string str = "\"96\";\"Транспортно-пересадочный узел «Сортировочная» (п)\";\"1769845\";\"Юго-Восточный административный округ\";\"район Лефортово\";\"платформа «Сортировочная»\";\"2014\";\"проект\";\"пригородная железная дорога\";\"\";\"\";\"\";\r\n";
                MatchCollection matches = Regex.Matches(lines[i], @"""[^""]*"";");
                if (matches.Count != 12) throw new ArgumentNullException();

            }

            return lines;
        }
    }
}