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

                theatres[i - 1] = new Театр(values);
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

            foreach (Театр theatre in theatres)
            {
                string output = ""; // formatted line

                output += $"|{theatre.CommonName,-30}";
                output += $"|{theatre.Email,-50}";
                output += $"|{theatre.Website,-15}";

                // adding colums to the output
                if (columns.Contains("MainHallCapacity") && columns.Contains("AdditionalHallCapacity") && columns.Length == 2)
                    output += $"|{theatre.MainHallCapacity,-30}" + $"|{theatre.AdditionalHallCapacity,-30}";

                else if (columns.Contains("ChiefName") && columns.Length == 1) output += $"|{theatre.ChiefName,-30}";
                else if (columns.Contains("AdmArea") && columns.Length == 1) output += $"|{theatre.AdmArea,-30}";
                else if (columns.Length == 0) output += "";

                else throw new ArgumentException();

                Console.WriteLine(output);
            }
        }

        
        public static void Write(Театр[] theatres, string path)
        {
            if (path == null || theatres == null) throw new ArgumentNullException();
            string[] lines = new string[theatres.Length];
            for (int i = 0; i < theatres.Length; i++)
            {
                lines[i] = theatres[i].ToString();
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
            if (mode) Array.Sort(theatres, (a, b) => int.Parse(a.MainHallCapacity) + int.Parse(a.AdditionalHallCapacity) 
            - int.Parse(b.MainHallCapacity) - int.Parse(b.AdditionalHallCapacity));

            else Array.Sort(theatres, (a, b) => int.Parse(b.MainHallCapacity) + int.Parse(b.AdditionalHallCapacity)
            - int.Parse(a.MainHallCapacity) - int.Parse(a.AdditionalHallCapacity));

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
