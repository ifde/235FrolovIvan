namespace Task04
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
            buttonDelete = new Button();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // buttonInit
            // 
            buttonInit.Location = new Point(93, 41);
            buttonInit.Name = "buttonInit";
            buttonInit.Size = new Size(275, 29);
            buttonInit.TabIndex = 0;
            buttonInit.Text = "Отобразить начальный список";
            buttonInit.UseVisualStyleBackColor = true;
            buttonInit.Click += buttonInit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(93, 272);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(275, 25);
            buttonDelete.TabIndex = 1;
            buttonDelete.Text = "Удалить выбранный элемент";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(93, 82);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(275, 169);
            listBox1.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 450);
            Controls.Add(listBox1);
            Controls.Add(buttonDelete);
            Controls.Add(buttonInit);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ListBox";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonInit;
        private Button buttonDelete;
        private ListBox listBox1;
    }
}