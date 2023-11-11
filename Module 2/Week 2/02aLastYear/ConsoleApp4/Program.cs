/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      4
Дата:        11.11.23
*/

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                try
                {
                    ArithmeticSequence sequence; // a separate sequence
                    Random rnd = new Random();
                    ArithmeticSequence[] arr = new ArithmeticSequence[rnd.Next(5, 16)];

                    for (int i = 0; i < arr.Length; i++)
                    {
                        int start = rnd.Next(1001);
                        int increment = rnd.Next(1, 11);

                        arr[i] = new ArithmeticSequence(start, increment);
                    }

                    sequence = new ArithmeticSequence(rnd.Next(1001), rnd.Next(1, 11));

                    int step = rnd.Next(3, 16); // index

                    int cnt = 1; // counter
                    foreach (ArithmeticSequence elem in arr)
                    {
                        Console.WriteLine($"Последовательность {cnt++}:" +
                            $"\nСумма первых {step} членов - {elem.GetSum(step)}");
                        if (elem[step] > sequence[step]) Console.WriteLine(elem);
                        Console.WriteLine(Environment.NewLine);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }
    }
}