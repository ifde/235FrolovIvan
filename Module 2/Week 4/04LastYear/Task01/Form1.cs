namespace Task01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Visible = false;
        }SaveFileDialog=

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = !button2.Visible;
            button1.Visible = !button1.Visible;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = !button2.Visible;
            button1.Visible = !button1.Visible;
        }
    }
}