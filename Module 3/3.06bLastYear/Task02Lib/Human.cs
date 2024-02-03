namespace Task02Lib
{
    [Serializable]
    public class Human
    {
        public string Name { get; set; }
        public Human(string name) { Name = name; }
        public Human() : this(" ") { }
    }
}