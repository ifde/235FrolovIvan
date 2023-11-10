using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Square
    {
        private int[][] _square;

        /// <summary>
        /// Создаёт новый квадрат указанного размера
        /// </summary>
        /// <param name="size">Размер квадрата</param>
        public Square(int size)
        {
            if (size <= 0) throw new Exception("Размер матрицы должен быть натуральным числом.");
            _square = new int[size][];
            for (int i = 0; i <  size; i++)
            {
                _square[i] = new int[size];
            }
        }

        /// <summary>
        /// Возвращает сумму элементов указанной строки
        /// </summary>
        /// <param name="row">Номер строки</param>
        public int SumRow(int row)
        {
            if (row < 0 || row >= _square.Length) throw new Exception("Столбца с таким номером не существует.");
            int sum = 0; // method output
            foreach (int elem in _square[row])
            {
                sum += elem;
            }
            return sum;
        }

        /// <summary>
        /// Возвращает сумму элементов указанного столбца
        /// </summary>
        /// <param name="col">Номер столбца</param>
        public int SumCol(int col)
        {
            if (col < 0 || col >= _square.Length) throw new Exception("Строки с таким номером не существует.");
            int sum = 0; // method output
            foreach (int[] elem in _square)
            {
                sum += elem[col];
            }
            return sum;
        }

        /// <summary>
        /// Возвращает сумму элементов главной диагонали
        public int SumMainDiag()
        {
            int sum = 0; // method output
            for (int i = 0; i < _square.Length; i++)
            {
                sum += _square[i][i];
            }
            return sum;
        }
        /// Возвращает сумму элементов побочной диагонали
        public int SumOtherDiag()
        {
            int sum = 0; // method output
            for (int i = _square.Length - 1; i >= 0; i--)
            {
                sum += _square[i][_square.Length - 1 - i];
            }
            return sum;
        }
        /// <summary>
        /// Возвращает, является ли текущий квадрат магическим
        /// </summary>
        public bool Magic()
        {
            int the_sum = SumRow(0); // the sum to which we will compare all other sums

            if (SumMainDiag() != the_sum || SumOtherDiag() != the_sum) return false;
            for (int i = 0; i < _square.Length; i++)
            {
                if (SumRow(i) != the_sum || SumCol(i) != the_sum) return false;
            }
            return true;
        }
        /// <summary>
        /// Считывает значения элементов квадрата из консоли
        /// </summary>
        public void ReadSquare(string[] lines, int lineIndex)
        {
            for (int row = 0; row < _square.Length; row++)
            {
                string[] line = lines[lineIndex + row]
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (line.Length != _square.Length)
                    Console.WriteLine($"Ошибка при чтении квадрата: строка должна содержать {_square.Length} значений, а содержит {line.Length}");
                for (int i = 0; i < _square.Length; i++)
                    int.TryParse(line[i], out _square[row][i]);
            }
        }
        /// <summary>
        /// Выводит аккуратно отформатированное содержимое квадрата
        /// </summary>
        public void PrintSquare()
        {
            foreach (int[] arr in _square)
            {
                Console.WriteLine(string.Join(' ', arr));
            }
        }
    }

}
