using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    /// <summary>
    /// Represents strings containing letters of Russian alphabet.
    /// </summary>
    public class RusString
    {
        private string rusString;
        public RusString(char start, char finish, int n)
        {
            if (start < 'А' || finish > 'я' || finish < start || n <= 0) throw new ArgumentOutOfRangeException();
            Random rnd = new Random(); // randomizer
            string output = ""; // the created rusString
            for (int i = 0; i < n; i++)
            {
                output += (char)rnd.Next(start, finish + 1);
            }
            rusString = output;
        }

        /// <summary>
        /// Returns true if the string is Palindrom
        /// </summary>
        public bool isPlindrom
        {
            get
            {
                bool flag = true;
                for (int i = 0; i < rusString.Length / 2; i++)
                {
                    if (rusString[i] != rusString[rusString.Length - 1 - i])
                    {
                        flag = false;
                        break;
                    }
                }
                return flag;
            }
        }

        /// <summary>
        /// Counts the number of copies of the symbol that the RusString contatins
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        public int CountLetter(char ch)
        {
            if (ch < 'А' || ch > 'я') throw new ArgumentOutOfRangeException();
            int count = 0; // method output
            foreach (char elem in rusString)
            {
                if (elem == ch) count++;
            }
            return count;
        }

        public override string ToString()
        {
            return rusString;
        }
    }
}
