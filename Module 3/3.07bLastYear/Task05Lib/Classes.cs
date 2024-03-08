using System.Collections;

namespace Task05Lib
{
    public class Words : IEnumerable<string[]>
    {
        string[] source; // Ссылка на исходный массив «слов»
        public Words(string[] source)
        {     // Конструктор
            this.source = source;
        }

        public IEnumerator<string[]> GetEnumerator()
        {
            string letters = "abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < letters.Length; i++)
            {
                string[] resAr = (from word in source
                                  where letters[i] == word[0]
                                  select word).ToArray();
                yield return resAr;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }

    public class MyLib
    {
        static public string[] keywords = {
"abstract", "as", "base", "bool", "break",
"byte", "case", "catch", "char", "checked",
"class", "const", "continue", "decimal", "default",
"delegate", "do", "double", "else", "enum",
"event", "explicit", "extern", "false", "finally",
"fixed", "float", "for", "foreach", "goto",
"if", "implicit", "in", "int", "interface",
"internal", "is", "lock", "long", "namespace",
"new", "null", "object", "operator", "out",
"override", "params", "private", "protected", "public",
"readonly", "ref", "return", "sbyte", "sealed",
"short", "sizeof", "stackalloc", "static", "string",
"struct", "switch", "this", "throw", "true",
"try", "typeof", "uint", "ulong", "unchecked",
"unsafe", "ushort", "using", "virtual", "void",
"volatile", "while"  };  //  string[ ]
    }   //  class MyLib

}