using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSV_ClassLibrary
{
    public static class DataProcessing
    {

        /// <summary>
        /// Creates an array with lines that contain only selected fields in a .csv file.
        /// </summary>
        /// <param name="selected_fields"></param>
        /// <returns></returns>
        public static string[] GetSelectedLines(params (int, string)[] values)
        {

            string[] lines = CsvProcessing.Read(); // all lines in a file

            string[] new_lines = new string[lines.Length]; // Method output. An array of lines with selected fields

            // adding headers to new_lines[]
            new_lines[0] = lines[0];
            new_lines[1] = lines[1];
            int k = 2; // counter

            // filling new_lines[]
            foreach (string line in lines)
            {
                string[] temp = CsvProcessing.Split(line); // splitted line
                bool flag = true; // flag
                // cheking if the line contains values
                foreach ((int, string) value in values)
                {
                    if (temp[value.Item1][1..^1] != value.Item2)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag) new_lines[k++] = line;
            }
            Array.Resize(ref new_lines, k);
            return new_lines;
        }

        /// <summary>
        /// Compares two lines in .csv file by thier "Available Transfer" fields in an alphabetical order
        /// </summary>
        class AvailableTransferComparer : IComparer<string>
        {
            public int Compare(string? line_1, string? line_2)
            {
                line_1 ??= "";
                line_2 ??= "";
                string field_1 = CsvProcessing.Split(line_1)[8];
                string field_2 = CsvProcessing.Split(line_2)[8];

                return String.Compare(field_1, field_2);
            }
        }

        /// <summary>
        /// Compares two lines in .csv file by thier "Year Of Comissioning" fields in a decreasing numerical order
        /// </summary>
        class YearOfComissioningComparer : IComparer<string>
        {
            public int Compare(string? line_1, string? line_2)
            {
                line_1 ??= "";
                line_2 ??= "";
                int year_1, year_2; // Year of Comissioning corresponding to line_1 and line_2, respectively

                string field_1 = CsvProcessing.Split(line_1)[6][1..^1];
                int.TryParse(field_1, out year_1);

                string field_2 = CsvProcessing.Split(line_2)[6][1..^1];
                int.TryParse(field_2, out year_2);

                return year_2 - year_1;
            }
        }

        /// <summary>
        /// Sorts lines in .csv file by a given column.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static string[] SortByColumn(string column)
        {

            string[] lines = CsvProcessing.Read(); // all lines in a file
            int length = lines.Length; // the total number of lines

            string eng_header = lines[0]; // header in English
            string rus_header = lines[1]; // header in Russian

            lines = lines[2..]; // remove headers for sorting

            // sorting in an alphabetic order
            if (column == "AvailableTransfer") Array.Sort(lines, new AvailableTransferComparer());

            // sorting in a decreasing numerical order
            else if (column == "YearOfComissioning") Array.Sort(lines, new YearOfComissioningComparer());
                

            string[] new_lines = new string[length]; // the method output

            // Filling new_lines[].
            new_lines[0] = eng_header;
            new_lines[1] = rus_header;
            for (int i = 2; i < length; i++)
            {
                new_lines[i] = lines[i - 2];
            }

            return new_lines;
        }
    }
}
