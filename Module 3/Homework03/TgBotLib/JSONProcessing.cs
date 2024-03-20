using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace TgBotLib
{
    public class JSONProcessing
    {
        /// <summary>
        /// A basic constructor
        /// </summary>
        public JSONProcessing() { }

        /// <summary>
        /// Creates a stream from data
        /// </summary>
        /// <param name="text"></param>
        /// <param name="nPath"></param>
        public static Stream Write(List<TPU> data)
        {
            using (var sw = new StreamWriter(@"json_temp.json"))
            {
                sw.WriteLine(JsonSerializer.Serialize(data,
                    new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) }));
            }
            return File.Open(@"json_temp.json", FileMode.Open);
        }

        /// <summary>
        /// Converts a stream into an array of TPUs
        /// </summary>
        /// <param name="sr"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static List<TPU> Read(Stream stream)
        {
            List<TPU>? list; // method output
            using (StreamReader sr = new StreamReader(stream)) // used to read from stream
            {
                list = JsonSerializer.Deserialize<List<TPU>>(sr.ReadToEnd(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) });
            }
            

            if (list == null) throw new ArgumentException("Данные в файле не соответствуют условию.");

            return list;
        }

        /// <summary>
        /// A useful method to convert Csv to Json and save it in the same directory with the same name
        /// </summary>
        /// <param name="fileName"></param>
        public static void CsvToJson(string fileName)
        {
            using (var stream = System.IO.File.OpenRead(fileName + ".csv"))
            {

                List<TPU> list = CSVProcessing.Read(stream);
                using var jsonStream = new StreamReader(JSONProcessing.Write(list));
                System.IO.File.WriteAllText(fileName + ".json", jsonStream.ReadToEnd());
                jsonStream.Close();
            }
        }
    }
}
