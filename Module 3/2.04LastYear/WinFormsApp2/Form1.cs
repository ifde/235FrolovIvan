namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double step;
        private void Form1_Load(object sender, EventArgs e)
        {
            step = 0.1;
            timer1.Enabled = true;  // ������ �������
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (step > 0)
            {
                string temp = label1.Text;
                if (temp.Length > 0)
                    label1.Text = temp.Substring(0, temp.Length - 1);
                else
                {
                    if (this.Opacity > 0)
                        this.Opacity -= step;
                    else
                    {
                        label1.Text = "��� ��� ����!";
                        step = -step;
                    }
                }
            }
            else    // ����� ��� �������������
                this.Opacity -= step;
        }
    }
}