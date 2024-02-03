using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02Lib
{
    [Serializable]
    public class Departament
    {
        public List<Human> Staff { get; }
        public string Name { get; set; }

        public Departament(string name, Human[] list)
        {
            Staff = new List<Human>(list);
            Name = name;
        }
        public Departament() { }
    }
}
