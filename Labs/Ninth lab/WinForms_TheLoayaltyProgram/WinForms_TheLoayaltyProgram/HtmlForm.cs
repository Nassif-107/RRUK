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
    public partial class HtmlForm : Form
    {
        private WebBrowser webBrowser;
        public HtmlForm(string htmlContent)
        {
            InitializeComponent();

            webBrowser = new WebBrowser();
            webBrowser.Dock = DockStyle.Fill;
            Controls.Add(webBrowser);

            // Загружаем HTML контент в WebBrowser
            webBrowser.DocumentText = htmlContent;
        }
    }
}
