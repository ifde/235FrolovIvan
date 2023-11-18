using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Methods
    {
        
        /// <summary>
        /// Gets an integer from the user
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public static int GetIntValue(string comment)
        {
            Console.WriteLine(comment);
            return int.Parse(Console.ReadLine());
        }
    }
}
