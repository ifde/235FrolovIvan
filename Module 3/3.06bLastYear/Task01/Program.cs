using System.Runtime.Serialization.Json;
using Task01Lib;

namespace Task01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student[] list171 = {new Student("Иванов", 1),
        new Student("Петров", 1),new Student("Сидоров",1)};

            Group gr171 = new Group("ПИ-171", list171);

            Student[] list271 = {new Student("Яковлев", 2),
        new Student("Юрьевa", 2),new Student("Белов",2)};

            Group gr271 = new Group("ПИ-271", list271);

            Group[] groups = { gr171, gr271 };

            DataContractJsonSerializer format = new DataContractJsonSerializer(typeof(Group[]));

            using (FileStream fs = new FileStream("group.json", FileMode.Create))
            {

                format.WriteObject(fs, groups);
            }

            using (FileStream fs = new FileStream("group.json", FileMode.Open))
            {
                Group[]? grps = format.ReadObject(fs) as Group[];
                if (grps != null)
                {
                    foreach (Group group in grps)
                    {
                        Console.WriteLine(group);
                    }
                }
            }
        }
    }
}