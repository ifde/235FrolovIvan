namespace Task05
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
            buttonInit = new Button();
            buttonShow = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // buttonInit
            // 
            buttonInit.Location = new Point(109, 55);
            buttonInit.Name = "buttonInit";
            buttonInit.Size = new Size(195, 35);
            buttonInit.TabIndex = 0;
            buttonInit.Text = "Вывести исходный список";
            buttonInit.UseVisualStyleBackColor = true;
            buttonInit.Click += buttonInit_Click;
            // 
            // buttonShow
            // 
            buttonShow.Location = new Point(109, 200);
            buttonShow.Name = "buttonShow";
            buttonShow.Size = new Size(195, 35);
            buttonShow.TabIndex = 1;
            buttonShow.Text = "Показать измененный список";
            buttonShow.UseVisualStyleBackColor = true;
            buttonShow.Click += ButtonShow_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(111, 98);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(193, 96);
            textBox1.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 294);
            Controls.Add(textBox1);
            Controls.Add(buttonShow);
            Controls.Add(buttonInit);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TextBox";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonInit;
        private Button buttonShow;
        private TextBox textBox1;
    }
}