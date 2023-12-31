﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    /// <summary>
    /// Represents strings containing letters of Russian alphabet.
    /// </summary>
    public class RusString : MyString
    {
        public RusString(char start, char finish, int n)
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
        /// Validates that the string consists of Cyrillic symbols
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override bool Validate()
        {
            char[] cyrillic_alphabet = new char['я' - 'А' + 1]; // Cyrillic alpahbet
            for (int i = 0;i < cyrillic_alphabet.Length;i++)
            {
                cyrillic_alphabet[i] = (char)('А' + i);
            }

            bool flag = true;
            foreach (char c in str)
            {
                if (!cyrillic_alphabet.Contains(c))
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }

        
    }
}
