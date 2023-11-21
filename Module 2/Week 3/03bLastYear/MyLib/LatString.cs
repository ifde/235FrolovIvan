using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class LatString : MyString
    {

        public LatString(char start, char finish, int n)
        {
            if (finish < start || n <= 0) throw new ArgumentOutOfRangeException();
            string output = ""; // the created rusString
            for (int i = 0; i < n; i++)
            {
                output += (char)rnd.Next(start, finish + 1);
            }
            if (!Validate()) throw new ArgumentException();
            str = output;
        }
        /// <summary>
        /// Validates that the string consists of Latin symbols
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override bool Validate()
        {
            char[] latin_alphabet = new char['z' - 'A' + 1]; // Cyrillic alpahbet
            for (int i = 0; i < latin_alphabet.Length; i++)
            {
                latin_alphabet[i] = (char)('A' + i);
            }

            bool flag = true;
            foreach (char c in str)
            {
                if (!latin_alphabet.Contains(c))
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }
    }
}
