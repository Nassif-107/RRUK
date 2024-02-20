namespace WinForms_TheLoayaltyProgram
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
            ShowBill = new Button();
            openFileDialog = new OpenFileDialog();
            comboBox = new ComboBox();
            label1 = new Label();
            button_Exit = new Button();
            button_ToSelect = new Button();
            TB_FileName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // ShowBill
            // 
            ShowBill.Location = new Point(339, 226);
            ShowBill.Name = "ShowBill";
            ShowBill.Size = new Size(117, 64);
            ShowBill.TabIndex = 0;
            ShowBill.Text = "Вывести чек";
            ShowBill.UseVisualStyleBackColor = true;
            ShowBill.Click += ShowBill_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // comboBox
            // 
            comboBox.FormattingEnabled = true;
            comboBox.Location = new Point(330, 166);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(136, 33);
            comboBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(154, 21);
            label1.MaximumSize = new Size(230, 0);
            label1.Name = "label1";
            label1.Size = new Size(220, 76);
            label1.TabIndex = 2;
            label1.Text = "Программа генерации чека";
            // 
            // button_Exit
            // 
            button_Exit.Location = new Point(174, 319);
            button_Exit.Name = "button_Exit";
            button_Exit.Size = new Size(184, 34);
            button_Exit.TabIndex = 3;
            button_Exit.Text = "Завершить работу";
            button_Exit.UseVisualStyleBackColor = true;
            button_Exit.Click += button_Exit_Click;
            // 
            // button_ToSelect
            // 
            button_ToSelect.Location = new Point(93, 150);
            button_ToSelect.Name = "button_ToSelect";
            button_ToSelect.Size = new Size(111, 63);
            button_ToSelect.TabIndex = 4;
            button_ToSelect.Text = "Выбрать файл";
            button_ToSelect.UseVisualStyleBackColor = true;
            button_ToSelect.Click += button_ToSelect_Click;
            // 
            // TB_FileName
            // 
            TB_FileName.Location = new Point(64, 259);
            TB_FileName.Name = "TB_FileName";
            TB_FileName.ReadOnly = true;
            TB_FileName.Size = new Size(170, 31);
            TB_FileName.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(330, 138);
            label2.Name = "label2";
            label2.Size = new Size(144, 25);
            label2.TabIndex = 6;
            label2.Text = "Формат вывода";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(64, 226);
            label3.Name = "label3";
            label3.Size = new Size(101, 25);
            label3.TabIndex = 7;
            label3.Text = "Имя файла";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 383);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(TB_FileName);
            Controls.Add(button_ToSelect);
            Controls.Add(button_Exit);
            Controls.Add(label1);
            Controls.Add(comboBox);
            Controls.Add(ShowBill);
            Name = "Form1";
            Text = "       ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ShowBill;
        private OpenFileDialog openFileDialog;
        private ComboBox comboBox;
        private Label label1;
        private Button button_Exit;
        private Button button_ToSelect;
        private TextBox TB_FileName;
        private Label label2;
        private Label label3;
    }
}
