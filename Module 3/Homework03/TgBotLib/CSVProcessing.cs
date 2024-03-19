using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TgBotLib
{
    public class CSVProcessing
    {
        /// <summary>
        /// A basic constructor
        /// </summary>
        public CSVProcessing() { }

        /// <summary>
        /// Creates a stream from data
        /// </summary>
        /// <param name="text"></param>
        /// <param name="nPath"></param>
        public static Stream Write(List<TPU> data)
        {
            var properties = typeof(TPU).GetProperties(); // properties of TPU

            using (var sw = new StreamWriter(@"csv_temp.csv"))
            {
                // Getting a header.
                string hearder = properties
                    .Select(p => p.Name)
                    .Select(n => "\"" + n + "\"")
                    .Aggregate((a, b) => a + ';' + b);
                hearder += ";";

                string rusHeader = "\"Локальный идентификатор\";\"Наименование транспортно-пересадочного узла\";\"global_id\";" +
                "\"Административный округ по адресу\";\"Район\";\"Станция метро или платформа, возле которой находится ТПУ\";" +
                "\"Год ввода в эксплуатацию\";\"Статус объекта\";\"Возможность пересадки\";\"Количество машиномест\";" +
                "\"geodata_center\";\"geoarea\";"; // Russian hearder

                // Writing headers.
                sw.WriteLine(hearder);
                sw.WriteLine(rusHeader);

                // Writing CSV file into a stream
                foreach (TPU tPU in data)
                {
                    string? line = properties
                        .Select(p => p.GetValue(tPU))
                        .Select(n => n == null ? "" : n.ToString())
                        .Select(n => "\"" + n + "\"")
                        .Aggregate((a, b) =>  a  + ';' + b);
                    line += ";";
                    sw.WriteLine(line);
                }
            }
            return File.Open(@"csv_temp.csv", FileMode.Open);
        }

        /// <summary>
        /// Converts a stream into an array of TPUs
        /// </summary>
        /// <param name="sr"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static List<TPU> Read(Stream stream)
        {
            // Getting the headers from the file.
            var sr = new StreamReader(stream);
            string header = sr.ReadLine() ?? "";
            string rusHeader = sr.ReadLine() ?? "";

            // Checking if the headers are correct
            if (header != "\"ID\";\"TPUName\";\"global_id\";\"AdmArea\";" +
                "\"District\";\"NearStation\";\"YearOfComissioning\";\"Status\";" +
                "\"AvailableTransfer\";\"CarCapacity\";\"geodata_center\";\"geoarea\";")
            {
                throw new ArgumentException("Данные в файле не соответствуют условию.");
            }

            if (rusHeader != "\"Локальный идентификатор\";\"Наименование транспортно-пересадочного узла\";\"global_id\";" +
                "\"Административный округ по адресу\";\"Район\";\"Станция метро или платформа, возле которой находится ТПУ\";" +
                "\"Год ввода в эксплуатацию\";\"Статус объекта\";\"Возможность пересадки\";\"Количество машиномест\";" +
                "\"geodata_center\";\"geoarea\";")
            {
                throw new ArgumentException("Данные в файле не соответствуют условию.");
            }

            List<TPU> list = new(); // method output
            string? line; // current line of the file

            // Converting CSV-file into a list of TPUs
            while((line = sr.ReadLine()) != null)
            {
                MatchCollection matches = Regex.Matches(line, @"(?<="")[^""]*(?="";)"); // values of the properties
                if (matches.Count != 12) throw new ArgumentException("Данные в файле не соответствуют условию.");
                Match[] values = matches.ToArray();

                list.Add(new TPU(values));
            }

            return list;
        }
    }
}
