namespace MyLib
{
    /// <summary>
    /// Represents a unti matrix
    /// </summary>
    public class Matrix
    {
        private int[,] _matrix;

        /// <summary>
        /// A constuctor. Creates a unit matrix
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Matrix(int n)
        {
            if (n <= 0)
                throw new ArgumentOutOfRangeException("Аргумент метода  должен быть положительным!");

            int[,] ar = new int[n, n];
            for (int i = 0; i < n; i++)
                ar[i, i] = 1;
            _matrix = ar;
        }

        /// <summary>
        /// Outputs a matrix int[,] by rows
        /// </summary>
        /// <param name="ar"></param>
        public void MatrPrint()
        {
            string result = ""; // method output
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0 ; j < _matrix.GetLength(1); j++)
                {
                    result += _matrix[i, j] + " ";
                }
                result += "\n";
            }
            Console.WriteLine(result);

        }
    }

}