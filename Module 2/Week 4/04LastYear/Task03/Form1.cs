namespace Task03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = text;
        }

        int p1 = 1, p2 = 0;
        string text = "Член ряда Пелла: ";

        private void button1_Click(object sender, EventArgs e)
        {
            if (p1 >= int.MaxValue - 2 * p2)
            {
                MessageBox.Show("Переполнение!\r\n Ряд начнем с начала!");
                p1 = 1;
                p2 = 0;
            }
            int p = p1 + 2 * p2;
            label1.Text = text + " " + p;
            p1 = p2;
            p2 = p;
        }
    }
}