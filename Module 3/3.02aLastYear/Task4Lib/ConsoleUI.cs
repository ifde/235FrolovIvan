using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Lib
{
    public class ConsoleUI
    {
        public event NewStringValue NewStringValueHappened;

        UIString s = new UIString(); // специальная строка
        public UIString S { get { return s; } set { s = value; } }
        public void GetStringFromUI()
        {
            Console.Write("Введите новое значение строки: ");
            string str = Console.ReadLine() + "";
            NewStringValueHappened?.Invoke(str);
            RefreshUI();
        }
        public void CreateUI()
        {
            NewStringValueHappened += s.NewStringValueHappenedHandler;
            RefreshUI();
        }
        public void RefreshUI()
        {      // обновление строки     
            Console.Clear();
            Console.WriteLine("Текст строки: " + s.Str);
        }

    }
}
