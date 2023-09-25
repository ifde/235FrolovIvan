namespace Self07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int a; // вводимое пользователем целое число
                Console.WriteLine("Введите целое число:");

                // выходим из программы при неправильном вводе
                if (!int.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine("Wrong input.");
                    continue;
                }
                Console.WriteLine($"Перевернутое число: {Reverse(a)}");

                Console.WriteLine("Для завершения программы нажмите ESC");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Переврнуть целое число
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        static int Reverse(int a)
        {
            string res = ""; // Итоговое число записываем в строчку
            if (a % 10 == 0) a /= 10; // отбрасываем последний 0
            int sign = 1; // знак числа

            // записываем знак числа и берем его модуль
            if (a < 0)
            {
                sign = -1;
                a = -a;
            }
            // переворачиваем число
            do
            {
                res += (a % 10).ToString();
                a /= 10;
            } while (a != 0);

            return int.Parse(res) * sign;
            
        }
    }
}