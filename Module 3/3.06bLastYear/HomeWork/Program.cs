using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography.X509Certificates;

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                try
                {
                    string[] lines = File.ReadAllLines(@"../../../sample3.csv")[1..];
                    
                    List<FileRecord> fileRecords = new List<FileRecord>();
                    foreach (string line in lines)
                    {
                        string[] values = line.Split(", ");
                        FileRecord fr = new FileRecord();
                        fr.GameNumber = int.Parse(values[0]);
                        fr.GameLength = int.Parse(values[1]);
                        fileRecords.Add(fr);
                    }

                    fileRecords.Sort((fr1, fr2) => fr1.GameLength - fr2.GameLength);

                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<FileRecord>));

                    using (FileStream fs = new FileStream(@"../../../output.json", FileMode.OpenOrCreate))
                    {
                        ser.WriteObject(fs, fileRecords);
                    }

                    using (FileStream fs = new FileStream(@"../../../output.json", FileMode.Open))
                    {
                        List<FileRecord>  data = ser.ReadObject(fs) as List<FileRecord> ?? new List<FileRecord>();
                        foreach (FileRecord record in data)
                        {
                            Console.WriteLine($"#{record.GameNumber}: played {record.GameLength} minutes");
                        }
                    }

                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.ParamName);
                }
                catch (Exception)
                {
                    Console.WriteLine("Возникла непредвиденная ошибка.");
                }


                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }

    [DataContract]
    class FileRecord
    {
        [DataMember]
        public int GameNumber { get; set; }
        [DataMember]
        public int GameLength { get; set; }

        public FileRecord(int GameNumber, int GameLength)
        {
            this.GameNumber = GameNumber;
            this.GameLength = GameLength;
        }

        public FileRecord() { }
    }
}