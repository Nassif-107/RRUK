using System.Windows.Forms;
using РРУК_01;

namespace Лаба_09_WindowsForms
{
    public partial class Form1 : Form
    {
        string fileName;
        string seasonName;
        string billResult;
        IView view;
        ViewForm viewForm;
        public Form1()
        {
            InitializeComponent();
            cbFormat.SelectedIndex = 0;
            cbSeason.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\Users\basma\Desktop\3 year\6 semester\Рефакторинг и работа с унаследованным 
                                    кодом\Лабы\Лаба_09\Лаба_09_WindowsForms\bin\Debug\net8.0-windows",
                Filter = "Выберите файл: (*.yaml;*.html;.htm)|*.yaml;*.html;*.htm|" +
                "HTML файл: (*.html;*.htm)|*.html;*.htm|" +
                "Yaml файл: (*.yaml)|*.yaml",
                FilterIndex = 0,
                RestoreDirectory = true,
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                fileName = Path.GetFileName(filePath);
                tbFileName.Text = fileName;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            ChooseFortmat();
            ChooseSeason();
            if (fileName != null && seasonName != null)
            {
                IFileSource fileSource = FileSourceFactory.CreateFileSource(fileName);

                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                using (StreamReader sr = new StreamReader(fs))
                {
                    if (view != null)
                    {
                        BillFactory factory = new BillFactory(fileSource);
                        BillGenerator bill = factory.CreateBill(sr, seasonName, view);
                        billResult = bill.GetBIll();
                        if (view.GetType() == typeof(HtmlView))
                        {
                            viewForm = new ViewForm(billResult, "html");
                            viewForm.Show();
                        }
                        else
                        {
                            viewForm = new ViewForm(billResult, "txt");
                            viewForm.Show();
                        }
                    }
                }
            }
        }
        private void ChooseFortmat()
        {
            if (cbFormat.SelectedIndex == 0)
            {
                // txt
                view = new TxtView();
            } 
            else if (cbFormat.SelectedIndex == 1)
            {
                // html
                view = new HtmlView();
            }
        }
        private void ChooseSeason()
        {
            if (cbSeason.SelectedIndex == 0)
            {
                // normal
                seasonName = "RegularSettings.json";
            }
            else if (cbSeason.SelectedIndex == 1)
            {
                // new year
                seasonName = "NewYearsSettings.json";
            }
        }
    }
}