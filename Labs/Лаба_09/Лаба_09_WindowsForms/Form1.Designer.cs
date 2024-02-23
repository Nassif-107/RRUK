namespace Лаба_09_WindowsForms
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
            label2 = new Label();
            tbFileName = new TextBox();
            btnChoose = new Button();
            label3 = new Label();
            cbFormat = new ComboBox();
            btnRun = new Button();
            btnClose = new Button();
            cbSeason = new ComboBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(348, 46);
            label1.Name = "label1";
            label1.Size = new Size(203, 33);
            label1.TabIndex = 0;
            label1.Text = "Генерация чека ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(77, 114);
            label2.Name = "label2";
            label2.Size = new Size(129, 22);
            label2.TabIndex = 1;
            label2.Text = "Выбор файла:";
            // 
            // tbFileName
            // 
            tbFileName.BorderStyle = BorderStyle.None;
            tbFileName.Location = new Point(77, 154);
            tbFileName.Name = "tbFileName";
            tbFileName.Size = new Size(284, 23);
            tbFileName.TabIndex = 2;
            // 
            // btnChoose
            // 
            btnChoose.FlatStyle = FlatStyle.Flat;
            btnChoose.Location = new Point(77, 197);
            btnChoose.Name = "btnChoose";
            btnChoose.Size = new Size(284, 36);
            btnChoose.TabIndex = 3;
            btnChoose.Text = "ВЫБРАТЬ";
            btnChoose.UseVisualStyleBackColor = true;
            btnChoose.Click += btnChoose_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(471, 114);
            label3.Name = "label3";
            label3.Size = new Size(149, 22);
            label3.TabIndex = 4;
            label3.Text = "Выбор формата:";
            // 
            // cbFormat
            // 
            cbFormat.FlatStyle = FlatStyle.Flat;
            cbFormat.FormattingEnabled = true;
            cbFormat.Items.AddRange(new object[] { "txt", "html" });
            cbFormat.Location = new Point(641, 111);
            cbFormat.Name = "cbFormat";
            cbFormat.Size = new Size(151, 30);
            cbFormat.TabIndex = 5;
            // 
            // btnRun
            // 
            btnRun.FlatStyle = FlatStyle.Flat;
            btnRun.Location = new Point(301, 288);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(284, 36);
            btnRun.TabIndex = 6;
            btnRun.Text = "ВЫВОД ЧЕКА";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Red;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(824, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(25, 25);
            btnClose.TabIndex = 7;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // cbSeason
            // 
            cbSeason.FlatStyle = FlatStyle.Flat;
            cbSeason.FormattingEnabled = true;
            cbSeason.Items.AddRange(new object[] { "Обычный", "Новый год" });
            cbSeason.Location = new Point(641, 197);
            cbSeason.Name = "cbSeason";
            cbSeason.Size = new Size(151, 30);
            cbSeason.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(471, 200);
            label4.Name = "label4";
            label4.Size = new Size(133, 22);
            label4.TabIndex = 8;
            label4.Text = "Выбор сезона:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(861, 375);
            Controls.Add(cbSeason);
            Controls.Add(label4);
            Controls.Add(btnClose);
            Controls.Add(btnRun);
            Controls.Add(cbFormat);
            Controls.Add(label3);
            Controls.Add(btnChoose);
            Controls.Add(tbFileName);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tbFileName;
        private Button btnChoose;
        private Label label3;
        private ComboBox cbFormat;
        private Button btnRun;
        private Button btnClose;
        private ComboBox cbSeason;
        private Label label4;
    }
}
