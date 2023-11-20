/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      2
 Дата:       19.11.2023
*/

using MyLib;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GeomProgr geomProgrObj; // ссылка на объект типа GeomProgr
            bool flag;
            int b, q, n;
            do
            {
                flag = false;
                try
                {
                    Console.Write("Введите начальный член прогрессии: ");
                    b = int.Parse(Console.ReadLine());
                    Console.Write("Введите знаменатель прогрессии: ");
                    q = int.Parse(Console.ReadLine());
                    geomProgrObj = new GeomProgr(b, q);

                    Console.Write("Введите количество членов: ");
                    n = int.Parse(Console.ReadLine());

                    for (int i = 1; i <= n; i++)
                    {
                        Console.Write(geomProgrObj[i] + " ");
                    }
                    Console.WriteLine();
                    Console.Write("Сумма этих членов = " + geomProgrObj.ProgrSum(n));
                }
                catch (Exception e)
                { // ловим любые исключения
                    flag = true;
                    Console.WriteLine("Некорректные входные данные!");
                }
            } while (flag);

        }
    }
}