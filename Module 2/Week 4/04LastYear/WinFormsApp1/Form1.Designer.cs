namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            buttonPrintSquare = new Button();
            textBox1 = new TextBox();
            labelResult = new Label();
            buttonOpenHome = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(26, 41);
            label1.Name = "label1";
            label1.Size = new Size(212, 21);
            label1.TabIndex = 0;
            label1.Text = "Возведение числа в квадрат";
            label1.Click += label1_Click;
            // 
            // buttonPrintSquare
            // 
            buttonPrintSquare.Location = new Point(26, 125);
            buttonPrintSquare.Name = "buttonPrintSquare";
            buttonPrintSquare.Size = new Size(166, 48);
            buttonPrintSquare.TabIndex = 1;
            buttonPrintSquare.Text = "Посчитать";
            buttonPrintSquare.UseVisualStyleBackColor = true;
            buttonPrintSquare.Click += buttonPrintSquare_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(26, 81);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(223, 23);
            textBox1.TabIndex = 2;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelResult.ForeColor = SystemColors.Highlight;
            labelResult.Location = new Point(40, 194);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(0, 21);
            labelResult.TabIndex = 3;
            // 
            // buttonOpenHome
            // 
            buttonOpenHome.Location = new Point(376, 41);
            buttonOpenHome.Name = "buttonOpenHome";
            buttonOpenHome.Size = new Size(166, 71);
            buttonOpenHome.TabIndex = 5;
            buttonOpenHome.Text = "Open Home";
            buttonOpenHome.UseVisualStyleBackColor = true;
            buttonOpenHome.Click += buttonOpenHome_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 386);
            Controls.Add(buttonOpenHome);
            Controls.Add(labelResult);
            Controls.Add(textBox1);
            Controls.Add(buttonPrintSquare);
            Controls.Add(label1);
            IsMdiContainer = true;
            Name = "Form1";
            Text = "My first application";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button buttonPrintSquare;
        private TextBox textBox1;
        private Label labelResult;
        private Button buttonOpenHome;
    }
}