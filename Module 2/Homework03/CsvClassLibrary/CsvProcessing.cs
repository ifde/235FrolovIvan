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
    public static class CsvProcessing
    {

        private static string GetHeader(string[] columns)
        {
            string output = ""; // formatted header

            output += $"|{"ROWNUM",-7}";
            output += $"|{"CommonName",-55}";
            output += $"|{"Email",-35}";
            output += $"|{"WebSite",-32}";

            // adding values to the header
            if (columns.Contains("MainHallCapacity") && columns.Contains("AdditionalHallCapacity") && columns.Length == 2)
                output += $"|{"MainHallCapacity",-30}" + $"|{"MainHallCapacity",-30}";

            else if (columns.Contains("ChiefName") && columns.Length == 1) output += $"|{"ChiefName",-30}";
            else if (columns.Contains("AdmArea") && columns.Length == 1) output += $"|{"AdmArea",-30}";
            else if (columns.Length == 0) output += "";

            else throw new ArgumentException();

            return output;
        } 

        public static Театр[] Read(string path)
        {
            string[] lines = File.ReadAllLines(path);
            Театр[] theatres = new Театр[lines.Length - 1];

            // checking if the header is correct
            if (lines[0] != "ROWNUM;CommonName;FullName;ShortName;AdmArea;District;Address;ChiefName;" +
                "ChiefPosition;PublicPhone;Fax;Email;WorkingHours;ClarificationOfWorkingHours;WebSite;" +
                "OKPO;INN;MainHallCapacity;AdditionalHallCapacity;X_WGS;Y_WGS;GLOBALID;")
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
        /// <param name="columns">Indices of columns by which the file for is sorted</param>
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
                if (theatre.Email.Contains(" ")) output += $"|{Regex.Match(theatre.Email, @".*?(?=[,;])").Value,-35}";
                else output += $"|{theatre.Email,-35}";

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

        
        public static void Write(Театр[] theatres, string path)
        {
            if (path == null || theatres == null) throw new ArgumentNullException();
            string[] lines = new string[theatres.Length + 1];
            lines[0] = "ROWNUM;CommonName;FullName;ShortName;AdmArea;District;Address;ChiefName;" +
                "ChiefPosition;PublicPhone;Fax;Email;WorkingHours;ClarificationOfWorkingHours;WebSite;" +
                "OKPO;INN;MainHallCapacity;AdditionalHallCapacity;X_WGS;Y_WGS;GLOBALID;"; // write header
            for (int i = 0; i < theatres.Length; i++)
            {
                lines[i + 1] = theatres[i].ToString();
            }
            File.WriteAllLines(path, lines);
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

            else throw new ArgumentException();

            return newTheatres.ToArray();
        }
    }
}
