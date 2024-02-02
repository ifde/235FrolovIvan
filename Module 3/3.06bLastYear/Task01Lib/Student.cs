using System.Runtime.Serialization;

namespace Task01Lib
{
    [DataContract]
    public class Student
    {
        [DataMember]
        string last_name;
        [DataMember]
        int academ_year;

        public Student(string last_name, int academ_year)
        {
            this.last_name = last_name;
            this.academ_year = academ_year;
        }
        public Student() : this("", default) { }

        public override string ToString()
        {
            return $"{last_name} - {academ_year}";
        }
    }
}