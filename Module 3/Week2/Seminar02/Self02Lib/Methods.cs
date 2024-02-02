namespace Self02Lib
{
    public delegate double ProcDel(int a, int b, int c); 
    public static class Methods
    {
        public static double Processing (int a, int b, int c, ProcDel F, ProcDel G, ProcDel H)
        {
            if (a < 0 || b < 0 || c < 0) return F(a, b, c);
            else if (a + b > c && a + c > b && b + c > a) return G(a, b, c);
            return H(a, b, c);
        }
    }
}