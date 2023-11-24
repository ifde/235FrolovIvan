using System.Diagnostics.Eventing.Reader;

namespace Task02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double step;

        private void Form1_Load(object sender, EventArgs e)
        {
            step = 0.1;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (step > 0)
            {
                if (label1.Text.Length > 0)
                {
                    label1.Text = label1.Text.Substring(0, label1.Text.Length - 1);
                }
                else
                {
                    if (Opacity > 0) Opacity -= step;
                    else
                    {
                        step = -step;
                        label1.Text = "Кот уже прошел!";
                    }
                }
            }
            else
            {
                Opacity -= step;
            }
        }
    }
}