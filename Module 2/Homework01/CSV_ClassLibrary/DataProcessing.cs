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
        public static string[] GetSelectedFields(params string[] selected_fields)
        {
            string[] lines = CsvProcessing.Read(); // all lines in a file
            string[] headers = CsvProcessing.Split(lines[0]); // headers

            int[] indices = new int[headers.Length]; // an array where if an element equals 1,
                                                     // it means that this index corresponds to a selected field
                                                     // filling indices[]
            for (int i = 0; i < headers.Length; i++)
            {
                if (selected_fields.Contains(headers[i][1..^1])) indices[i]++;
            }

            string[] new_lines = new string[lines.Length]; // Method output. An array of lines with selected fields
            int k = 0; // counter

            // filling new_lines[]
            foreach (string line in lines)
            {
                StringBuilder new_line = new StringBuilder(); // a line with only selected fields
                string[] temp = CsvProcessing.Split(line);

                // filling new_line with those elements that correspond to selected fieds
                for (int i = 0; i < temp.Length; i++)
                {
                    if (indices[i] == 1) new_line.Append($"{temp[i]};");
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
                string field_1 = CsvProcessing.Split(line_1)[columnIndex];
                string field_2 = CsvProcessing.Split(line_2)[columnIndex];
                if (field_1 == "\"Возможность пересадки\"" || 
                    field_1 == "\"AvailableTransfer\"" || 
                    field_2 == "\"Возможность пересадки\"" || 
                    field_2 == "\"AvailableTransfer\"") return -1; // making sure we don't include headers in sorting

                return String.Compare(field_1, field_2);
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
                Array.Sort(lines, (a, b) => int.Parse(CsvProcessing.Split(b)[6][1..^1])
                                            - int.Parse(CsvProcessing.Split(a)[6][1..^1]));
            }

            return lines;


        }
    }
}
