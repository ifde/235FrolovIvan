using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    abstract public class MyString
    {
        protected string str; // str
        protected Random rnd = new Random();

        /// <summary>
        /// Returns true if the string is Palindrom
        /// </summary>
        public bool isPlindrom
        {
            get
            {
                bool flag = true;
                for (int i = 0; i < str.Length / 2; i++)
                {
                    if (str[i] != str[str.Length - 1 - i])
                    {
                        flag = false;
                        break;
                    }
                }
                return flag;
            }
        }

        /// <summary>
        /// Validates the string
        /// </summary>
        /// <returns></returns>
        abstract public bool Validate();

        /// <summary>
        /// Counts the number of copies of the symbol that the RusString contatins
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        public int CountLetter(char ch)
        {
            int count = 0; // method output
            foreach (char elem in str)
            {
                if (elem == ch) count++;
            }
            return count;
        }

        public override string ToString()
        {
            return str;
        }
    }
}
