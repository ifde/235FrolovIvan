/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      1
 Дата:      09.10.2023
*/

using System.Text.RegularExpressions;
using System.Web;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string htmlText = GetHtmlText("https://ru.wikipedia.org/wiki/%D0%97%D0%B0%D0%B3%D0%BB%D0%B0%D0%B2%D0%BD%D0%B0%D1%8F_%D1%81%D1%82%D1%80%D0%B0%D0%BD%D0%B8%D1%86%D0%B0");

            Console.WriteLine($"Скачали ответ: {htmlText.Length} символов");
            // Находим все подстроки, подходящие по шаблону:
            MatchCollection linksCollection = Regex.Matches(
                htmlText, @" href=""\/wiki\/(?<name>[\w\(\)%]+)""");

            foreach (Match link in linksCollection)
                Console.WriteLine($" {HttpUtility.UrlDecode(link.Groups["name"].Value)} : {HttpUtility.UrlDecode(link.Value)}");
        }

        /// <summary>
        /// Get HTML text by a webpage link
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        static string GetHtmlText (string link)
        {
            using HttpClient client = new HttpClient();
            var response = client.GetAsync(link).Result;
            string htmlText = response.Content.ReadAsStringAsync().Result;

            return htmlText;
        }


    }
}