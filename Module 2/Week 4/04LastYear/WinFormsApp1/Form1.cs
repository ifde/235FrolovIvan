namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonPrintSquare_Click(object sender, EventArgs e)
        {
            int n;
            int.TryParse(textBox1.Text, out n);
            labelResult.Text = (n * n).ToString();
        }
    }
}