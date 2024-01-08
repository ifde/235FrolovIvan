using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03Lib
{
    public static class StaticClass
    {
        public static T[] SelectByPredicate<T>(this T[] mass, Func<T, bool> predicate)
        {
            List<T> temp = new List<T>();
            foreach (var t in mass)
            {
                if (predicate(t)) temp.Add(t);
            }
            return temp.ToArray();
        }
    }
}
