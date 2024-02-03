using System.Runtime.Serialization.Formatters.Binary;
using Task02Lib;

namespace Task02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            University HSE = new University();
            HSE.Name = "NRU HSE";

            Human[] deptStaff = { new Professor("Ivanov"),
                      new Professor("Petrov")
                    };

            Departament SE = new Departament("SE", deptStaff);
            HSE.Departaments = new List<Departament>();
            HSE.Departaments.Add(SE);

            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fs = new FileStream("Uni.bat", FileMode.Create))
            {
                bf.Serialize(fs, HSE);
            }

            University HSEdeserial;

            using (FileStream fs = new FileStream("Uni.bat", FileMode.Open))
            {
                HSEdeserial = (University)bf.Deserialize(fs);
            }

            foreach (Departament d in HSEdeserial.Departaments)
            {
                foreach (Human h in d.Staff)
                {
                    if (h is Professor) Console.WriteLine(d.Name + "prof.:" + h.Name);
                }
            }
        }
    }
}