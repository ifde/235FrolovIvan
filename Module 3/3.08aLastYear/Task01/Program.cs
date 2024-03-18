using System.Text;
using Taask01Lib;

namespace Task01
{
    internal class Program
    {
        static Func<int, int> g = (x) => (-3 * x * x * x * x - 8 * x * x * x - x * x - 5 * x - 9) * (x - 2);
        static Func<int, int> f = (x) => -3 * x * x * x * x * x * x + 4 * x * x * x * x * x + x * x * x * x + 5 * x * x * x + 2 * x * x + 4 * x - 6;
        static void Main()
        {
            BankAccount dep = new BankAccount(1000);
            Task[] tasks = new Task[10];
            for (int i = 0; i < 10; i++)
            {
                Task task = new Task(dep.DoTransactions);
                tasks[i] = task;
            }
            // foreach (Task task in tasks) task.Start();
            int[] values = new int[] { 0, 3, -3, 4, -4 };
            foreach (int value in  values)
            {
                Console.Write($"x = {value}: ");
                foreach (int coef in GetCoef(value)) Console.Write(coef + " ");
                Console.WriteLine();
            }
            // while (!TaskAreCompleted(tasks)) for (int i = 0; i < 100000; i++) ;
        }
        static int[] GetCoef(int x)
        {
            int[] res = new int[6];
            res[0] = FindReverse(x - 1);
            res[1] = FindReverse(x - 2);
            res[2] = FindReverse(x + 1);
            res[3] = FindReverse(x + 2);
            res[4] = FindReverse(x - 8);
            res[5] = (f(x) * FindReverse(g(x)) - x + 3) % 13;

            return res;

        }

        static int FindReverse(int a)
        {
            if (a < 0) a += 13;
            for(int i = 1; i <= 12; i++)
            {
                if (a * i % 13 == 1) return i;
            }
            return 1;
        }

        static bool TaskAreCompleted(Task[] tasks)
        {
            bool flag = true;
            foreach (Task task in tasks)
            {
                if (!task.IsCompleted) flag = false;
            }
            return flag;
        }
    }
}