/*
 Дисциплина: "Программирование"
 Группа:      БПИ235(2)
 Студент:     Фролов Иван Григорьевич
 Задача:      Self06
   Дата:      24.09.2023
*/

namespace Self06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            uint n; // число разрядов числа
            do
            {
                Console.Write("Введите разрядность числа: ");
            } while (!uint.TryParse(Console.ReadLine(), out n) || n == 0);

            Console.WriteLine("Все n-значные числа с попарно равными цифрами:");
            NiceNumbers(n);
        }

        /// <summary>
        /// Счтаем n-значные числа, в которых все цифры одинаковы
        /// </summary>
        static void NiceNumbers(uint n)
        {
            uint min_value = (uint)Math.Pow(10, n - 1); // минимальное возможное n-значное число
            uint max_value = (uint)Math.Pow(10, n); // максимальное возможное n-значное число +1

            // рассматриваем все n-значные числа
            for (uint i = min_value; i < max_value; i++)
            {
                uint cnt = 0; // При хотя бы двух различных цифрах этот счетких станет равным 0

                uint last_digit = i % 10; // предыдущая цифра
                uint t = i; // копия числа i

                // Пробегаемся по всем цифрам числа t
                for (uint j = 0; j < n; j++)
                {
                    uint curr_digit = t % 10; // текущая цифра
                    t /= 10;
                    // если соседние цифры не равны, то выходим из цикла и увеличиваем счетчик
                    if (curr_digit != last_digit)
                    {
                        cnt++;
                        break;
                    }
                    last_digit = curr_digit;
                }

                // если все цифры равны, то есть счетчик равен 0, то выводим число
                if (cnt == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}