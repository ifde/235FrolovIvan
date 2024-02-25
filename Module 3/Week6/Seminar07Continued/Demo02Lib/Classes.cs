
namespace Demo02Lib
{
    public class Number<T>
        where T : struct
    {
        protected T _value;
        // Свойство виртуально, на случай переопределения в наследнике.
        public virtual T Value
        {
            get => _value;
            set => _value = value;
        }
        // В этом типе нет ограничений на значение. 
        // Но метод виртуален, чтобы могли работать наследники.
        public virtual bool IsAcceptable(T newValue) => true;
        public Number() { }
        public Number(T value) => Value = value;

        public override string ToString() => _value.ToString();

    }
    /// <summary>
    /// Обобщённое число с ограничением на значение.
    /// </summary>
    /// <typeparam name="T">Типизирующий параметр, ограничен типами значений, т.к. такое ограничение есть в родителе.</typeparam>
    public class LimitedNumber<T> : Number<T>
        where T : struct
    {
        // Критерий для ограничения значения числа.
        public Predicate<T> Criterion
        {
            set;
            private get;
        }

        protected LimitedNumber() { }
        // Конструктор с критерием и значением. 
        public LimitedNumber(Predicate<T> criterion, T initValue)
        {
            // Если критерий не передан -- сразу исключение.
            if (criterion == null) throw new ArgumentNullException();
            Criterion = criterion;
            // Значения, не отвечающие критерию не должны попасть в объект.
            if (criterion(initValue))
            {
                _value = initValue;
            }
            else throw new ArgumentOutOfRangeException();
        }
        // В интерфейс отправляем метод проверки значения на соответствие критерию.
        public override bool IsAcceptable(T newValue)
        {
            if (Criterion(newValue)) return true;
            return false;
        }
    }

    public class EvenSequence<T>
        where T : struct
    {
        List<LimitedNumber<T>> list = new List<LimitedNumber<T>>();
        Predicate<T> criterion = x => Convert.ToInt32(x) == Convert.ToDouble(x) && Convert.ToInt32(x) % 2 == 0;

        public EvenSequence(params T[] arr)
        {
            foreach (var item in arr)
            {
                LimitedNumber<T> ltdNumber = new LimitedNumber<T>(criterion, item);
                list.Add(ltdNumber);
            }
        }

        public void AddNumber(T number)
        {
            LimitedNumber<T> ltdNumber = new LimitedNumber<T>(criterion, number);
            list.Add(ltdNumber);
        }

        public void RemoveNumber(T number)
        {
            LimitedNumber<T> ltdNumber = new LimitedNumber<T>(criterion, number);
            list.RemoveAll(x => x == ltdNumber);
        }

        public override string ToString()
        {
            string res = "";
            foreach (var item in list)
            {
                res += item.ToString() + "\n";
            }
            return res;
        }

    }

    public class OddSequence<T>
        where T : struct
    {
        List<LimitedNumber<T>> list = new List<LimitedNumber<T>>();
        Predicate<T> criterion = x => Convert.ToInt32(x) == Convert.ToDouble(x) && Convert.ToInt32(x) % 2 == 1;

        public OddSequence(params T[] arr)
        {
            foreach (var item in arr)
            {
                LimitedNumber<T> ltdNumber = new LimitedNumber<T>(criterion, item);
                list.Add(ltdNumber);
            }
        }

        public void AddNumber(T number)
        {
            LimitedNumber<T> ltdNumber = new LimitedNumber<T>(criterion, number);
            list.Add(ltdNumber);
        }

        public void RemoveNumber(T number)
        {
            LimitedNumber<T> ltdNumber = new LimitedNumber<T>(criterion, number);
            list.RemoveAll(x => x == ltdNumber);
        }

        public override string ToString()
        {
            string res = "";
            foreach (var item in list)
            {
                res += item.ToString() + "\n";
            }
            return res;
        }

    }

}