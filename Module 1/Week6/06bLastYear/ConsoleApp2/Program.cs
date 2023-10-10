/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      2
 Дата:      10.10.2023
*/

using System.Text.RegularExpressions;
using System.Web;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number_of_deleted_scripts = 0; // количество удаленных скриптов
            string htmlText = GetHtmlText("https://en.wikipedia.org/wiki/Main_Page");
            File.WriteAllText(@"..\..\..\InitialPage.html", htmlText);
            int page_size = htmlText.Length; // количество символов на странице
            string new_htmlText = ""; // новый текст
            int index = 0;
            foreach (Match match in Regex.Matches(htmlText, @"<(?'tag'script).*?>(?'text'[.\s]*?)</\k'tag'>"))
            {
                Console.WriteLine(match.Value);
                number_of_deleted_scripts++;
                new_htmlText += htmlText[index..(match.Index)];
                index = match.Index + match.Length;
            }
            new_htmlText += htmlText[index..];
            Console.WriteLine($"Удалено скриптов: {number_of_deleted_scripts}");
            Console.WriteLine($"Количество символов на странице уменьшилось на {page_size - new_htmlText.Length}");
            File.WriteAllText(@"..\..\..\Page.html", new_htmlText);
        }

        /// <summary>
        /// Get HTML text by a webpage link
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        static string GetHtmlText(string link)
        {
            using HttpClient client = new HttpClient();
            var response = client.GetAsync(link).Result;
            string htmlText = response.Content.ReadAsStringAsync().Result;

            return htmlText;
        }
    }
}