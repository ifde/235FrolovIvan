namespace Task4Lib
{
    public class Series
    {
        public int[] Arr { get; }

        public Series(int[] arr)
        {
            Arr = arr;
        }

        public void Order(Func<int, int, int> rule)
        {
            for (int i = 0; i < Arr.Length - 1; i++)
            {
                for (int j = i + 1; j < Arr.Length; j++)
                {
                    if (rule(Arr[i], Arr[j]) > 0)
                    {
                        int temp = Arr[i];
                        Arr[i] = Arr[j];
                        Arr[j] = temp;
                    }
                }
            }
        }
    }
}