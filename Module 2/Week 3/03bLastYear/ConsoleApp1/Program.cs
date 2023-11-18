/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      1
 Дата:       18.11.2023
*/
using MyLib;

namespace ConsoleApp1
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
                    int n = Methods.GetIntValue("Введите порядок единичной матрицы:"); // the size of the unit matrix
                    Matrix arr = new Matrix(n);
                    arr.MatrPrint();
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Аругмент не может быть Null.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Аругмент неверного формата.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Стек переполнен.");
                }
                catch
                {
                    Console.WriteLine("An error occured.");
                }
                finally
                {
                    Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
                }
                
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}