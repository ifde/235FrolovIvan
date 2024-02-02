using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Task01Lib
{
    [DataContract]
    public class Group
    {
        [DataMember]
        string name;
        [DataMember]
        Student[] students;

        public Group(string name, Student[] students)
        {
            this.name = name;
            this.students = students;
        }
        public Group() : this("", new Student[0]) { }

        public override string ToString()
        {
            string res = $"Group \"{name}\":\n";
            foreach (Student student in this.students)
            {
                res += student.ToString() + '\n';
            }
            return res;
        }
    }
}
