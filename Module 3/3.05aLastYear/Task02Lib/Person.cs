using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02Lib
{
    public struct Person
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        private int age;

        //TODO: нужны проверки корректности возраста
        public int Age {
            get { return age; }
            set
            {
                if (age <= 0) throw new ArgumentOutOfRangeException();
                age = value;
            } 
        }

        public Person(string name, string lastname, int age)
        {
            Name = name;
            LastName = lastname;
            this.age = age;
        }

        public override string ToString() => $"{Name} {LastName} {Age}";
    }

}
