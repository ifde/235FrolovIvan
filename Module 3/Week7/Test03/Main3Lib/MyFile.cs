using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main3Lib
{
    public static class MyFile
    {
        public static void CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                var fs = File.Create(path);
                fs.Close();
            }
        }

        public static void AppendAllText(string path, string text)
        {
            if (!File.Exists(path)) throw new ArgumentException("File couldn't be found");
            File.AppendAllText(path, text);
        }

        public static string ReadAllText(string path)
        {
            if (!File.Exists(path)) throw new ArgumentException("File couldn't be found");
            return File.ReadAllText(path);
        }
    }
}
