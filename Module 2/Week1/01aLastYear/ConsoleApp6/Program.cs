/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      6
Создать класс со статическими членами, константами и полями (readonly) только для чтения. 
В отладочном режиме (начиная с первого оператора класса – 
поставьте точку прерывания на readonly string name =) и 
на static int entranceYear = проследить (по F11) последовательность выполнения инициализаций и  ….

 Дата:       1.11.2023
*/

namespace ConsoleApp6
{
    class MyClassmate
    { // Одноклассник
        readonly string name = "Неизвестный"; // Фамилия
        readonly int birthYear = 1998; // год рождения
        const int apprenticeship = 4; // срок обучения (лет)
        static int entranceYear = 2016; // год поступления
        static MyClassmate()  // статический конструктор
        {
            entranceYear = 2015;
        }
        public MyClassmate() { } // Конструктор умолчания
        public MyClassmate(string name, int by)
        {   //Конструктор общего вида
            this.name = name;
            birthYear = by;
        }
        public string Information()
        {   // Метод объекта 
            return "Фамилия: " + name + "; возраст: " +
                (entranceYear - birthYear) +
                " лет; год окончания: " +
                (entranceYear + apprenticeship);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MyClassmate Nan = new MyClassmate();
            Console.WriteLine(Nan.Information());
            MyClassmate Bob = new MyClassmate("Смирнов", 1997);
            Console.WriteLine(Bob.Information());

        }
    }
}