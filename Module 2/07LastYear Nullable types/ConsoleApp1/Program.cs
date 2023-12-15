using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*B b = new B();
            C c = new C();
            A[] x = { b, c };
            x[0].Show();
            b.Show();
            x[1].Show();
            c.Show();
            // 1113*/

            Baz f = new Baz(-5);
            Console.WriteLine(f.Field);

            IB IbClass = new MyClass();
            IbClass.A();
        }
    }

    abstract class A
    {
        protected int a = 1;
        public abstract void Show();
    }
    class B : A
    {
        public override void Show() { Console.Write(a); }
    }
    class C : B
    {
        int q = 2;
        new public void Show() { Console.Write(q + a); }
    }

    interface IA
    {
        public void A();
    }

    interface IB : IA { public void B(); }

    class MyClass : IB
    {
        public void A() { Console.Write("A"); }
        public void B() { Console.Write("B"); }
    }



    class Bar
    {
        protected int _field;
        public int Field
        {
            get => _field;
            set => _field = value;
        }
        public Bar(int x) => Field = x;
    }

    class Foo : Bar
    {
        public int Field
        {
            get => _field;
            set => _field = Math.Abs(value);
        }
        public Foo(int x) : base(x) { }
    }

    class Baz : Foo
    {
        public int Field
        {
            get => _field;
            set => _field = base.Field + 1;
        }
        public Baz(int x) : base(x) { }
    }

}
