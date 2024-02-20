using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_TheLoayaltyProgram
{
    public partial class TxtForm : Form
    {
        private RichTextBox richTextBox;

        public TxtForm(string content)
        {
            richTextBox = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true, // Делаем поле только для чтения
                Font = new System.Drawing.Font("Consolas", 10) // Устанавливаем шрифт и размер шрифта
            };
            Controls.Add(this.richTextBox);
            richTextBox.Text = content;
        }
    }
}
