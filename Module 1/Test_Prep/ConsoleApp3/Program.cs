/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      3 Variation

Метод CreateArray( ) возвращает сформированный и заполненный массив из N вещественными элементами. 
Элементы массива – последовательно идущие значения последовательности: -1;1/3;-1/5;1/7;….
Метод ShowArray( ) выводит в консоль вещественный массив, ссылка на который передана в параметре. 
Элементы массива при выводе разделены символом пробела и выводятся на экран по восемь в строке с точностью до четырёх знаков после запятой.
Метод ShiftArray( ), «удаляет» из переданного в параметре вещественного массива все отрицательные элементы, сдвигая оставшиеся вправо. 
Если отрицательный элемент – крайний слева, заменить его нулём. Например, для массива {-1, 0, 5, -7,11} 
результат работы метода: {0, 0, 0, 5, 11}, а для {1, 2, -4, 6, -8} результат: {1, 1, 1, 2, 6}. 
В основной программе при помощи метода CreateArray( ) сформировать массив А из K  элементов (K – целое число вводятся пользователем). 

Используя метод ShiftArray( ) удалить из A все отрицательные значения. Исходные и результирующий массивы вывести на экран при помощи метода ShowArray( ).
Предусмотреть проверку корректности ввода и цикл повторения решения


 Дата:      13.10.2023
*/

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                int k;

                Console.WriteLine("Введите целое число K >= 0:");
                // вводим целое число K
                while (!int.TryParse(Console.ReadLine(), out k) || k < 0)
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите целое число K >= 0:");
                }

                double[] arr = CreateArray(k);
                Console.WriteLine("\nИсходный массив:");
                ShowArray(arr);

                ShiftArray(arr);
                Console.WriteLine("\nСдвинутый массив:");
                ShowArray(arr);

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// «Удаляет» из переданного в параметре вещественного массива все отрицательные элементы, сдвигая оставшиеся вправо. 
        /// </summary>
        /// <param name="arr"></param>
        static void ShiftArray(double[] arr)
        {
            int k = arr.Length - 1; // counter
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] >= 0) arr[k--] = arr[i];
            }
            // if all elements are less that zero, arr[] is filled with 0
            if (k == arr.Length - 1)
            {
                for (int i = 0; i <= k; i++)
                {
                    arr[i] = 0;
                }
            }
            // otherwise
            else
            {
                for (int i = 0; i <= k; i++)
                {
                    arr[i] = arr[k + 1];
                }
            }
        }

        /// <summary>
        ///  Вывод в консоль массива, ссылка на который передана в параметре. 
        ///  Элементы массива при выводе разделены символом пробела и выводятся на экран по восемь в строке с точностью до четырёх знаков после запятой.
        /// </summary>
        /// <param name="arr"></param>
        static void ShowArray(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 8 == 7) Console.Write($"{arr[i]:f4}\n");
                else Console.Write($"{arr[i]:f4} ");
            }
        }

        /// <summary>
        /// Возвращает сформированный и заполненный массив из N вещественными элементами. 
        /// Элементы массива – последовательно идущие значения последовательности: -1;1/3;-1/5;1/7;….
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static double[] CreateArray(int n)
        {
            double[] res = new double[n]; // resulting array
            for (int i = 0; i < n; i++)
            {
                res[i] = (double)(i % 2 == 0 ? -1 : 1) / (2 * i + 1);
            }
            return res;
        }
    }
}