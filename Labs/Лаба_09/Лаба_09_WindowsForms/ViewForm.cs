using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаба_09_WindowsForms
{
    public partial class ViewForm : Form
    {
        private RichTextBox richTextBox;
        private WebBrowser webBrowser;
        public ViewForm(string content, string choice)
        {
            InitializeComponent();

            if (choice == "txt")
            {
                richTextBox = new RichTextBox
                {
                    Dock = DockStyle.Fill,
                    ReadOnly = true,
                };
                Controls.Add(richTextBox);
                richTextBox.Text = content;
            }
            else if (choice == "html")
            {
                webBrowser = new WebBrowser();
                webBrowser.Dock = DockStyle.Fill;
                Controls.Add(webBrowser);
                webBrowser.DocumentText = content;
            }

        }
    }
}
