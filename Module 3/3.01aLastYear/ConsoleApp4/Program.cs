using Task4Lib;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Robot rob = new Robot();    // конкретный робот 
            Steps[] trace = { new Steps(rob.Backward),
                           new Steps(rob.Backward),
                           new Steps(rob.Left) };

            // сообщить координаты
            Console.WriteLine("Start: " + rob.GetPosition());

            for (int i = 0; i < trace.Length; i++)
            {
                Console.WriteLine("Method = {0}, Target = {1}",
                trace[i].Method, trace[i].Target);
                trace[i]();
            }

            Console.WriteLine("Finish: " + rob.GetPosition());

            Console.WriteLine("continue...");
            Steps delR = new Steps(rob.Right);      // направо
            Steps delL = new Steps(rob.Left);       // налево
            Steps delF = new Steps(rob.Forward);    // вперед
            Steps delB = new Steps(rob.Backward);   // назад

            // шаги по диагоналям (многоадресные делегаты):
            Steps delRF = delR + delF;
            Steps delRB = delR + delB;
            Steps delLF = delL + delF;
            Steps delLB = delL + delB;
            Console.WriteLine("Start: " + rob.GetPosition());
            delLB();
            Console.WriteLine("ControlPoint: " + rob.GetPosition());
            delRB();
            Console.WriteLine("Finish: " + rob.GetPosition() + Environment.NewLine);

            Console.WriteLine("Введите программу для робота:");
            string commands = Console.ReadLine() + "";
            Steps moves = null;
            foreach (char command in commands)
            {
                moves += command switch
                {
                    'R' => delR,
                    'L' => delL,
                    'F' => delF,
                    _ => delB
                };
            }

            Console.WriteLine("Start: " + rob.GetPosition());
            moves();
            Console.WriteLine("Finish: " + rob.GetPosition());
        }
    }
}