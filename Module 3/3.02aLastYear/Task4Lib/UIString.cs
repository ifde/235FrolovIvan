namespace Task4Lib
{
    public delegate void NewStringValue(string s);
    public class UIString
    {
        string str = "Default text";
        public string Str { get { return str; } private set { str = value; } }
        public void NewStringValueHappenedHandler(string s)
        {
            str = s;
        }
    }
}