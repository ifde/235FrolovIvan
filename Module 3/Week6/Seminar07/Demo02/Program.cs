using Demo02Lib;

namespace Demo02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 3, 5, 7 };

            Sequence<int> even = new Sequence<int>(arr);

            even[2] = 15;// Изменение по индексу.
            try
            {
                // Изменение по несуществующему индексу.
                even[-4] = 10;
                // Создание последовательности с пустой ссылкой.
                Sequence<double> x = new Sequence<double>(null);
            }
            catch (IndexOutOfRangeException e) { Console.WriteLine("Элемент с таким индексом отсутствует"); }
            catch (ArgumentNullException ex) { Console.WriteLine("Ссылка null"); }
            catch (Exception) { Console.WriteLine("Что-то еще случилось"); }

        }
    }
}