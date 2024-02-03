using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02Lib
{
    [Serializable]
    public class University
    {
        public List<Departament> Departaments { get; set; }
        public string Name {  get; set; }

        public University(string name, List<Departament> departaments)
        {
            Departaments = departaments;
            Name = name;
        }

        public University() { }
    }
}
