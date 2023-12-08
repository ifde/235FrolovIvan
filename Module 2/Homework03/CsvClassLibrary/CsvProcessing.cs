using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CsvClassLibrary
{
    public enum Operation
    {
        Top,
        Bottom
    }
    public static class CsvProcessing
    {
        private static string header = "ROWNUM;CommonName;FullName;ShortName;AdmArea;District;Address;ChiefName;" +
                "ChiefPosition;PublicPhone;Fax;Email;WorkingHours;ClarificationOfWorkingHours;WebSite;" +
                "OKPO;INN;MainHallCapacity;AdditionalHallCapacity;X_WGS;Y_WGS;GLOBALID;";

        /// <summary>
        /// Returns a header with essential colums and additional colums passed in the argument
        /// </summary>
        /// <param name="columns">Additional colums</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private static string GetHeader(string[] columns)
        {
            string output = ""; // formatted header

            // Adding essential colums
            output += $"|{"ROWNUM",-7}";
            output += $"|{"CommonName",-55}";
            output += $"|{"Email",-35}";
            output += $"|{"WebSite",-32}";

            // including additional colums
            if (columns.Contains("MainHallCapacity") && columns.Contains("AdditionalHallCapacity") && columns.Length == 2)
                output += $"|{"MainHallCapacity",-30}" + $"|{"MainHallCapacity",-30}";

            else if (columns.Contains("ChiefName") && columns.Length == 1) output += $"|{"ChiefName",-30}";
            else if (columns.Contains("AdmArea") && columns.Length == 1) output += $"|{"AdmArea",-30}";
            else if (columns.Length == 0) output += "";

            else throw new ArgumentException("Такие значения заголовков не предусмотрены.");

            return output;
        } 

        /// <summary>
        /// Reads .csv file and returns Театр[] array
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Театр[] Read(string path)
        {
            string[] lines = File.ReadAllLines(path);
            Театр[] theatres = new Театр[lines.Length - 1];

            // checking if the header is correct
            if (lines[0] != header)
            {
                throw new ArgumentNullException("Данные в файле не соответствуют условию.");
            }

            // cheking that each line is in correct format
            for (int i = 1; i < lines.Length; i++)
            {
                MatchCollection matches = Regex.Matches(lines[i], @"(?<="")[^""]*(?="";)");
                if (matches.Count != 21) throw new ArgumentNullException("Данные в файле не соответствуют условию.");
                Match[] values = matches.ToArray(); // values of the line

                theatres[i - 1] = new Театр(values, i);
            }

            return theatres;
        }

        /// <summary>
        /// Prints theatres in a readable format
        /// </summary>
        /// <param name="theatres"></param>
        /// <param name="columns">Additional colums to print</param>
        public static void Print(Театр[] theatres, params string[] columns)
        {
            if (columns == null || theatres == null) throw new ArgumentNullException(); // cheking if the argument is null

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(GetHeader(columns)); // print header

            string output; // formatted line
            foreach (Театр theatre in theatres)
            {
                output = "";
                output += $"|{theatre.RowNum,-7}";
                output += $"|{theatre.CommonName,-55}";

                // including "Email" field. If there are 2 or more emails, we output only the first one
                if (theatre.Email.Contains(" ")) output += $"|{Regex.Match(theatre.Email, @".*?(?=[,;])").Value,-35}";
                else output += $"|{theatre.Email,-35}";

                // including "Website" field. If there are 2 or more websites, we output only the first one
                if (theatre.Website.Contains(" ")) output += $"|{Regex.Match(theatre.Website, @".*?(?=[,;])").Value,-32}";
                else output += $"|{theatre.Website,-32}";

                // adding colums to the output
                if (columns.Contains("MainHallCapacity") && columns.Contains("AdditionalHallCapacity"))
                {
                    if (theatre.MainHallCapacity == "") continue;
                    output += $"|{theatre.MainHallCapacity,-30}" + $"|{theatre.AdditionalHallCapacity,-30}";
                }  

                else if (columns.Contains("ChiefName")) output += $"|{theatre.ChiefName,-30}";
                else if (columns.Contains("AdmArea")) output += $"|{theatre.AdmArea,-30}";

                Console.WriteLine(output);
            }
        }


        /// <summary>
        /// Writes data about thatres into a .csv file
        /// </summary>
        /// <param name="theatres"></param>
        /// <param name="path"></param>
        /// <param name="mode">"Write" to write over. "Append" to add to an existing file.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Write(Театр[] theatres, string path, string mode)
        {
            if (path == null || theatres == null) throw new ArgumentNullException();
            string[] lines = new string[theatres.Length + 1];
            lines[0] = header; // write header
            for (int i = 0; i < theatres.Length; i++)
            {
                lines[i + 1] = theatres[i].ToString();
            }

            if (mode == "Write") File.WriteAllLines(path, lines);
            else if (mode == "Append")
            {
                try
                {
                    Театр[] oldTheatres = Read(path);
                }
                catch(Exception)
                {
                    throw new ArgumentException("Данные в существующем файле не соответствуют условию.");
                }
                
                File.AppendAllLines(path, lines[1..]); // here we don't write headers as they already exist.
            }
            else throw new ArgumentException("Такой тип сохранения в файл не предусмотрен.");

        }

        /// <summary>
        /// Sorts theatres by capacity.
        /// </summary>
        /// <param name="theatres"></param>
        /// <param name="mode">Increasing order if true. Decreasing order if false</param>
        /// <returns></returns>
        public static Театр[] SortByCapacity(Театр[] theatres, bool mode)
        {
            if (mode) Array.Sort(theatres, (a, b) => 
            (a.MainHallCapacity == "" ? 0 : int.Parse(a.MainHallCapacity)) +
            (a.AdditionalHallCapacity == "" ? 0 : int.Parse(a.AdditionalHallCapacity)) -
            (b.MainHallCapacity == "" ? 0 : int.Parse(b.MainHallCapacity)) -
            (b.AdditionalHallCapacity == "" ? 0 : int.Parse(b.AdditionalHallCapacity)) );

            else Array.Sort(theatres, (a, b) =>
            - (a.MainHallCapacity == "" ? 0 : int.Parse(a.MainHallCapacity)) -
            (a.AdditionalHallCapacity == "" ? 0 : int.Parse(a.AdditionalHallCapacity)) +
            (b.MainHallCapacity == "" ? 0 : int.Parse(b.MainHallCapacity)) +
            (b.AdditionalHallCapacity == "" ? 0 : int.Parse(b.AdditionalHallCapacity)));

            return theatres;
        }

        /// <summary>
        /// Filters theatres by given options
        /// </summary>
        /// <param name="theatres"></param>
        /// <param name="field">the column for filtering</param>
        /// <param name="value">the value of filtering</param>
        /// <returns></returns>
        public static Театр[] Filter(Театр[] theatres, string field, string value)
        {
            List<Театр> newTheatres = new List<Театр>(); // method output
            if (field == "ChiefName")
            {
                foreach (var a in theatres)
                {
                    if (a.ChiefName == value) newTheatres.Add(a);
                }
            }

            else if (field == "AdmArea")
            {
                foreach (var a in theatres)
                {
                    if (a.AdmArea == value) newTheatres.Add(a);
                }
            }

            else throw new ArgumentException("Фильтрация по этому полю не предусмотрена.");

            return newTheatres.ToArray();
        }
    }
}
