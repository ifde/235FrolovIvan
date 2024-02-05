using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using Task07Lib;

namespace Task07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Student[]));

            Student[] students1 = new Student[3] { new Student("A"), new Student("B"), new Student("C") };

            using (FileStream fs = new FileStream(@"../../../MyStudents.json", FileMode.Create))
            {
                ser.WriteObject(fs, students1);
            }

            DataContractJsonSerializer ser1 = new DataContractJsonSerializer(typeof(List<Student>));
            using (FileStream fs = new FileStream(@"../../../Students.json", FileMode.Open))
            {
                List<Student> students = ser1.ReadObject(fs) as List<Student> ?? new List<Student>();
                Console.WriteLine(students.Count);

                if (students.Count == 0) Console.WriteLine("The list is empty!");
                foreach (Student student in students)
                {
                    Type t = student.GetType();
                    foreach (var field in t.GetFields(BindingFlags.Public |
                                              BindingFlags.NonPublic |
                                              BindingFlags.Instance))
                    {
                        Console.WriteLine($"{field.Name}: {field.GetValue(student)}");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}