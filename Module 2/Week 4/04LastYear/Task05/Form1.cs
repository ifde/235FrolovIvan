namespace Task05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            buttonShow.Visible = false;
        }

        string[] lines = { "����", "���", "���", "������", "����", "�����", "����" };

        private void buttonInit_Click(object sender, EventArgs e)
        {
            textBox1.Lines = lines;
            buttonShow.Visible = true;
        }

        private void ButtonShow_Click(object sender, EventArgs e)
        {
            string res = string.Join(" ", textBox1.Lines);
            MessageBox.Show($"��������� ���������:\r\n{res}");
        }
    }
}