﻿using System.Data.Common;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace CSV_ClassLibrary
{

    public static class CsvProcessing
    { 
        private static string fPath = ""; // the path to the .csv file

        /// <summary>
        /// A property for setting and getting fPath
        /// </summary>
        public static string Path
        {
            get { return fPath; }
            set { fPath = value; }
        }


        /// <summary>
        /// Prints lines in a.csv file in a readable format
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="columns">Indices of columns by which the file for is sorted</param>
        public static void Print(string[] lines, params int[] columns)
        {
            if (lines == null) return; // cheking if the argument is null

            Console.WriteLine(Environment.NewLine);
            foreach (string line in lines)
            {
                if (line == lines[1]) continue; // we don't print Russian headers because they are too long

                string[] temp = Split(line);
                string output = ""; // formatted line
                for (int i = 0; i < temp.Length; i++)
                {

                    string value = temp[i][1..^1]; // deleting " from the value
                    if (i >= 0 && i <=3 || columns.Contains(i))
                    {
                        output += i switch
                        {
                            0 => $"|{value,-4}",
                            1 => $"|{value,-64}",
                            2 => $"|{value,-10}",
                            3 => $"|{value,-40}",
                            4 => $"|{value,-33}",
                            5 => $"|{value,-63}",
                            6 => $"|{value,-23}",
                            7 => $"|{value,-9}",
                            8 => $"|{value,-118}",
                            9 => $"|{value,-13}",
                            _ => ""
                        };
                    }
                    
                }

                //foreach (string value in temp)
                //{
                //    Console.Write($"{value};\t");
                //}
                Console.WriteLine(output);
                //Console.WriteLine(new string('-', output.Length));
                //Console.WriteLine();
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
        public static void Write(string text, string nPath)
        {
            try
            {
                if (!File.Exists(nPath)) File.WriteAllLines(nPath, File.ReadAllLines(fPath)[..2]); // appending headers
                File.AppendAllText(nPath, text);
            }
            catch (IOException)
            {
                throw new Exception("Путь до файлу указан некорректно или к нему нельзя получить доступ.");
            }
            
        }

        /// <summary>
        /// Writes lines to a file.
        /// </summary>
        /// <param name="lines"></param>
        public static void Write(string[] lines)
        {
            try
            {
                File.WriteAllLines(fPath, lines);
            }
            catch (IOException)
            {
                throw new Exception("Путь до файлу указан некорректно или к нему нельзя получить доступ.");
            }
        }
    }
}