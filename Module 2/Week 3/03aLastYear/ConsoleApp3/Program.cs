/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      3
 Дата:       15.11.2023
*/


using Task03Lib_Employee;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random(); // randomizer
            int salseEmployeesNum = rnd.Next(1, 16); // the number of Sales Employees
            int partTimeEmployeesNum = rnd.Next(1, 16);  // the number of Part-time Employees
            Employee[] arr = new Employee[salseEmployeesNum + partTimeEmployeesNum];

            // filling arr[]
            for (int i = 0; i < arr.Length; i++)
            {
                if (i < salseEmployeesNum) arr[i] = new SalesEmployee(new string( (char)('a' + rnd.Next('z' - 'a' + 1)), rnd.Next(1, 11) ), rnd.Next(100, 1001), rnd.Next(100, 1001));
                else arr[i] = new PartTimeEmployee(new string((char)('a' + rnd.Next('z' - 'a' + 1)), rnd.Next(1, 11)), rnd.Next(100, 1001), rnd.Next(1, 26));
            }

            // sorting Sales Employees in a decresing order of the saleries
            for (int i = 0; i < salseEmployeesNum - 1; i++)
            {
                if (arr[i].CalculatePay() < arr[i + 1].CalculatePay())
                {
                    Employee temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i] = temp;
                } 
            }

            // sorting Part-time Employees in a decresing order of the saleries
            for (int i = salseEmployeesNum; i < arr.Length - 1; i++)
            {
                if (arr[i].CalculatePay() < arr[i + 1].CalculatePay())
                {
                    Employee temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i] = temp;
                }
            }

            // outputting information about employees
            foreach (Employee emp in arr)
            {
                Console.WriteLine(emp);
            }
        }
    }
}