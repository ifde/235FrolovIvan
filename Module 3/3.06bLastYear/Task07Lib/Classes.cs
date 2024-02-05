using System.Runtime.Serialization;

namespace Task07Lib
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public string _id;
        [DataMember]
        public int age;
        [DataMember]
        public string eyeColor;
        [DataMember]
        public string name;
        [DataMember]
        public string gender;
        [DataMember]
        public int studentGroup;
        [DataMember]
        public int algebra;
        [DataMember]
        public int programming;
        [DataMember]
        public int english;

        public Student(string name)
        {
            this.name = name;
        }
    }
}