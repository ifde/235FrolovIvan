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
        /// Spilts a string from the the .csv file into an array of values of each cell.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        static string[] Split(string line)
        {
            string[] temp = new string[12]; // method output
            int cnt = 0; // a counter
            foreach (Match match in Regex.Matches(line, @"""[^""]*""(?=;)"))
            {
                temp[cnt++] = match.Value;
            }
            return temp;
        }

        /// <summary>
        /// Creates an array with lines that contain only selected fields in a .csv file.
        /// </summary>
        /// <param name="selected_fields"></param>
        /// <returns></returns>
        public static string[] GetSelectedFields(params string[] selected_fields)
        {
            string[] lines = CsvProcessing.Read(); // all lines in a file
            string[] headers = Split(lines[0]); // headers

            int[] indices = new int[headers.Length]; // an array where if an element equals 1,
                                                     // it means that this index corresponds to a selected field
                                                     // filling indices[]
            for (int i = 0; i < headers.Length; i++)
            {
                if (selected_fields.Contains(headers[i][1..^1])) indices[i]++;
            }

            string[] new_lines = new string[lines.Length - 1]; // Method output. An array of lines with selected fields
            int k = 0; // counter

            // filling new_lines[]
            foreach (string line in lines[2..])
            {
                StringBuilder new_line = new StringBuilder(); // a line with only selected fields
                string[] temp = Split(line);

                // filling new_line with those elements that correspond to selected fieds
                for (int i = 0; i < temp.Length; i++)
                {
                    if (indices[i] == 1) new_line.Append(temp[i] + ";");
                }
                new_lines[k++] = new_line.ToString();
            }

            return new_lines;
        }

        static int columnIndex; // a static field for AvailableTransferComparer Comparer

        class AvailableTransferComparer : IComparer<string>
        {
            public int Compare(string? line_1, string? line_2)
            {
                line_1 ??= "";
                line_2 ??= "";
                string field_1 = Split(line_1)[columnIndex];
                string field_2 = Split(line_2)[columnIndex];
                string[] temp = { field_1, field_2 };
                Array.Sort(temp);
                return field_1 != temp[0] ? 1 : -1;
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
            if (column == "AvailableTransfer")
            {
                columnIndex = 8;
                Array.Sort(lines, new AvailableTransferComparer());
            }
            else if (column == "YearOfComissioning")
            {
                Array.Sort(lines, (a, b) => int.Parse(Split(b)[6][1..^1])
                                            - int.Parse(Split(a)[6][1..^1]));
            }

            return lines;


        }
    }
}
