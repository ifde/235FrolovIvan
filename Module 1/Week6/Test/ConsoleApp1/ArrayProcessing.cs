/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Вариант:      12

Дата:      14.10.2023
*/

// make sure that namespace in Program.cs is "Test"
namespace Test
{
    internal class ArrayProcessing
    {

        /// <summary>
        /// Modifes an Array.
        /// </summary>
        /// <param name="arr"></param>
        public static void UpOn10(double[] arr)
        {
            if (arr == null) return; // check if arr[] is null
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 10) arr[i] /= 10; // modify
            }
        }

        /// <summary>
        /// Converts an array to a string
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static string DblArrToString(double[] arr)
        {
            string res = ""; // method output
            if (arr == null) return res; // check if arr[] is null
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1) res += $"{arr[i]:f2}"; // we don't add "; " after the last element
                else res += $"{arr[i]:f2}; ";
            }
            return res;
        }
    }
}
