namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            button2.Visible = !button2.Visible;
            button1.Visible = !button1.Visible;
        }
    }
}