using System.ComponentModel.Design.Serialization;

namespace ConsoleApp3
{
    delegate double DelegateConvertTemperature(double a);

    class TemperatureConverterImp
    {
        public double ToCelcius (double t)
        {
            return 5.0 / 9 * (t - 32);
        }

        public double ToFarrenheit (double t)
        {
            return 9.0 / 5 * t + 32;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            TemperatureConverterImp temperatureConverterImp = new TemperatureConverterImp();
            DelegateConvertTemperature[] arr = new DelegateConvertTemperature[2];
            arr[0] = temperatureConverterImp.ToCelcius;
            arr[1] = temperatureConverterImp.ToFarrenheit;

            Console.WriteLine("Введите вещественное значение температуры в градусах Цельсия:");
            double a;
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out a)) break;
                Console.WriteLine("Повторите попытку.");
            }
            Console.WriteLine("В градусах Фаренгейта: {0:f2}", arr[1](a));
            Console.WriteLine("Обратно в градусах Цельсия: {0:f2}", arr[0](arr[1](a)));
        }
    }
}