namespace Task04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = "ListBox";
            listBox1.Visible = false;
            buttonDelete.Visible = false;
        }

        // поля объекта класса Form1:
        string[] lines = new string[]
            { "один", "два", "три", "четыре", "пять", "шесть", "семь" };
        string[] newLines = null;

        private void buttonInit_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            listBox1.Items.Clear();
            listBox1.Items.AddRange(lines);
            newLines = lines;
            buttonDelete.Visible = true;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int n = listBox1.SelectedIndex;
            if (n == -1)
            {
                MessageBox.Show("Ошибка выделения.");
                return;
            }
            string[] temp = new string[newLines.Length - 1];
            int k = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (i != n) temp[k++] = newLines[i];
            }
            newLines = temp;
            listBox1.Items.Clear();
            listBox1.Items.AddRange(newLines);
        }
    }
}