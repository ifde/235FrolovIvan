namespace Task06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string sample = "0123456789";
        static char[] temp = sample.ToCharArray();

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.IndexOfAny(temp) == -1)
            {
                MessageBox.Show("Не введены цифры!");
                textBox1.Focus();
                return;
            }
            string number = textBox1.Text.Trim();
            foreach (char c in number)
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("Это не натуральное число!");
                    textBox1.Focus();   // установить фокус ввода
                    return;
                }
            }
            char[] arNumb = number.ToCharArray();
            Array.Sort(arNumb);
            Array.Reverse(arNumb);
            textBox1.Text = new string(arNumb);
        }
    }
}