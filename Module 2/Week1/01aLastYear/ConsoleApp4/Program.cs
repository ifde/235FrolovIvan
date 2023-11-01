/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      5
1. Объявить класс ConsolePlate, представляющий символ консольного окна. Закрытые поля класса – символ _plateChar и цвет символа _plateColor (типа ConsoleColor) инициализированы.
2. В классе ConsolePlate  два конструктора: 
2.1 без параметров, устанавливающий символ равным  ‘+’ 
2.2. с параметрами, определяющими символ и его цвет.
3. Определить свойства доступа к полям класса. Свойство доступа к полю _plateChar для всех символов с кодами меньшими или равными 31 (1Fh)  присваивает полю  _plateChar значение ‘+’ 
4. В методе Main() класса Program создать массив объектов типа ConsolePlate  и вывести все символы массива на экран, окрашивая в цвет, определяемый полем _plateColor .

 Дата:       1.11.2023
*/

using System.Drawing;
using System.Linq.Expressions;
using System.Transactions;

namespace ConsoleApp4
{
    internal class ConsolePlate
    {
        char _plateChar;
        ConsoleColor _plateColor;

        public ConsolePlate()
        {
            _plateChar = '+';
            _plateColor = default;
        }
        public ConsolePlate(char ch, ConsoleColor col)
        {
            _plateChar = ch;
            _plateColor = col;
        }

        public char PublicChar
        {
            set
            {
                if (value <= 31) _plateChar = '+';
                else _plateChar = value;
            }
        }

        public ConsoleColor PublicColor
        {
            get { return _plateColor; }
        }

        public override string ToString()
        {
            return _plateChar.ToString(); 
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            ConsolePlate[] arr = new ConsolePlate[10];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new ConsolePlate((char)rnd.Next('A', 'z' + 1), ConsoleColor.Red);
                Console.ForegroundColor = arr[i].PublicColor;
                Console.Write(arr[i].ToString());
            }
            Console.ResetColor();
        }
    }
}