using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      2
Дата:        09.11.23
*/

namespace ConsoleApp2
{
    internal class IntegerList
    {
        private static readonly Random Random = new Random();

        private int[] _list;
        private int _currentElement = 0; // the index of the first 0 in _list[]

        /// <summary>
        /// Создаёт список указанного размера
        /// </summary>
        /// <param name="size">Размер списка</param>
        public IntegerList(int size)
        {
            _list = new int[size];
        }

        /// <summary>
        /// Заполняет список числами между 1 и 100 включительно
        /// </summary>
        public void Randomize()
        {
            for (int i = 0; i < _list.Length; i++)
                _list[i] = Random.Next(101);
            _currentElement = _list.Length;
        }

        /// <summary>
        /// Печатает элементы списка с их индексами
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < _list.Length; i++)
                if (_list[i] != 0) Console.WriteLine(i + ":\t" + _list[i]);
        }

        // doubles the size of _list[]
        private void IncreaseSize()
        {
            Array.Resize(ref _list, _list.Length * 2);
        }

        /// <summary>
        /// Adds newVal to _list[]
        /// </summary>
        /// <param name="newVal"></param>
        public void AddElement(int newVal)
        {
            if (_currentElement >= _list.Length) IncreaseSize();
            _list[_currentElement] = newVal;
            _currentElement++;
        }

        /// <summary>
        /// Deletes the first occurance of val in _list[]
        /// </summary>
        /// <param name="val"></param>
        public void RemoveFirst(int val)
        {
            int index = Array.IndexOf(_list, val); // the index of the first occurance of val in list[]
            int[] temp = new int[_list.Length]; // temporary array 
            if (index == -1) return;
            for (int i = 0; i < _list.Length; i++)
            {
                if (i < index) temp[i] = _list[i];
                if (i >= index && i != _list.Length - 1) temp[i] = _list[i + 1];
                if (_list[i] == 0) break;
            }
            _list = temp;
            _currentElement--;
        }

        /// <summary>
        /// Removes all inctances of val in _list[]
        /// </summary>
        /// <param name="val"></param>
        public void RemoveAll(int val)
        {
            // Turning elements which should be deleted into 0.
            // Changing _currentElement.
            for (int i = 0; i < _list.Length; i++)
            {
                if (_list[i] == val)
                {
                    _list[i] = 0;
                    _currentElement--;
                }
            }

            int[] temp = new int[_list.Length]; // temporary array 

            int k = 0; // a counter
            for (int i = 0; i < _list.Length; i++)
            {
                if (_list[i] == 0) k++;
                if (_list[i] != 0) temp[i - k] = _list[i];
            }
            _list = temp;

        }

    }

    internal class IntegerListTest
    {
        private static IntegerList _list = new IntegerList(10);

        /// <summary>
        /// Создаёт список и выполняет пользовательские операции,
        /// пока пользователь не захочет выйти
        /// </summary>
        public static void Main()
        {
            PrintMenu();

            int choice = int.Parse(Console.ReadLine());

            while (choice != 0)
            {
                Dispatch(choice);
                PrintMenu();

                choice = int.Parse(Console.ReadLine());
            }
        }

        /// <summary>
        /// Выполняет действия меню
        /// </summary>
        /// <param name="choice">Выбранный пункт меню</param>
        public static void Dispatch(int choice)
        {
            int n; // user's input
            switch (choice)
            {
                case 0: Console.WriteLine("Пока!"); break;
                case 1:
                    Console.WriteLine("Какой размер будет у списка?");
                    int size = int.Parse(Console.ReadLine());
                    _list = new IntegerList(size);
                    _list.Randomize();
                    break;
                case 2: _list.Print(); break;
                case 3:
                    Console.WriteLine("Введите натуральное число.");
                    while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                    {
                        Console.WriteLine("Неверный ввод. Повторите попытку.");
                    }
                    _list.AddElement(n);
                    break;
                case 4:
                    Console.WriteLine("Введите натуральное число.");
                    while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                    {
                        Console.WriteLine("Неверный ввод. Повторите попытку.");
                    }
                    _list.RemoveFirst(n);
                    break;
                case 5:
                    Console.WriteLine("Введите натуральное число.");
                    while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                    {
                        Console.WriteLine("Неверный ввод. Повторите попытку.");
                    }
                    _list.RemoveAll(n);
                    break;
                default: Console.WriteLine("Извините, вы выбрали что-то не то"); break;
            }
        }

        /// <summary>
        /// Выводит варианты пользователю
        /// </summary>
        public static void PrintMenu()
        {
            Console.WriteLine("\n Меню ");
            Console.WriteLine(" ====");
            Console.WriteLine("0: Выйти");
            Console.WriteLine("1: Создать новый список (** сделайте это с самого начала!! **)");
            Console.WriteLine("2: Напечатать список");
            Console.WriteLine("3: Добавить элемент в список");
            Console.WriteLine("4: Удалить первое вхождение элемента из списка");
            Console.WriteLine("5: Удалить все вхождения элемента из списка");
            Console.Write("\nВведите ваш выбор: ");
        }
    }

}
