namespace Task04Lib
{
    public delegate bool predicate(int a, int b);
    public class Series
    {
        private static Random rand = new Random();
        int[] ar;  // поле ar элементы последовательности 
        public Series(int ni,         // ni - количество элементов
                      int xn, int xk)
        {   // диапазон значений элементов 
            ar = new int[ni];
            for (int i = 0; i < ar.Length; i++)
                ar[i] = rand.Next(xn, xk);
        }
        public void Order(predicate pr)
        { //сортировка, параметр - предикат
            int temp;
            for (int i = 0; i < ar.Length - 1; i++)
                for (int j = i + 1; j < ar.Length; j++)
                    if (pr(ar[i], ar[j]))
                    {
                        temp = ar[i];
                        ar[i] = ar[j]; ar[j] = temp;
                    }
        }
        public void Display()
        {    // метод вывода элементов массива
            for (int i = 0; i < ar.Length; i++)
                Console.Write("{0}\t", ar[i]);
        }
    } //class Series

}