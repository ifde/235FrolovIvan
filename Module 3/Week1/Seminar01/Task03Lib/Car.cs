namespace Task03Lib
{
    public delegate void CarEngineHandler(string msgForCaller);

    public class Car
    {
        private CarEngineHandler listOfHandlers;
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }

        public string CarName { get; set; }

        private bool carIsDead;
        // Конструкторы перегружены.
        public Car() { MaxSpeed = 100; }
        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            CarName = name;
        }

        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers = methodToCall;
        }

        public void Accelerate (int delta)
        {
            if (carIsDead)
            {
                listOfHandlers?.Invoke("К сожалению, машина сломана :( ...");
                return;
            }
            CurrentSpeed += delta;

            // Машина почти сломана?
            if (MaxSpeed > CurrentSpeed && (MaxSpeed - CurrentSpeed) <= 10)
                listOfHandlers?.Invoke("Предупреждение! Будь осторожнее");

            // Машина сломана?
            if (CurrentSpeed >= MaxSpeed)
                carIsDead = true;
            else
                Console.WriteLine("Скорость = {0}", CurrentSpeed);
        }
    }
}