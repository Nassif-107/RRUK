using System.Diagnostics.Eventing.Reader;
using РРУК_01;

namespace WinForms_TheLoayaltyProgram
{
    public partial class Form1 : Form
    {
        string billOutput;
        string filename;
        IView view;
        public Form1()
        {
            InitializeComponent();
            comboBox.Items.Add("txt");
            comboBox.Items.Add("html");
            comboBox.SelectedIndex = 0;
        }
        public void Proccess()
        {
            if (comboBox.Text == "html")
            {
                view = new HtmlView();
            }
            else if (comboBox.Text == "txt")
            {
                view = new TxtView();
            }
            else
            {
                MessageBox.Show("Выберите формат файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(filename != null)
            {
                IFileSource fileSource = FileSourceFactory.CreateFileSource(filename);

                using (FileStream fs = new FileStream(filename, FileMode.Open))
                using (StreamReader sr = new StreamReader(fs))
                {
                    if (view != null)
                    {
                        BillFactory factory = new BillFactory(fileSource);
                        BillGenerator bill = factory.CreateBill(sr, "NewYearsSettings.json", view);
                        billOutput = bill.GenerateBill();
                        if (view.GetType() == typeof(HtmlView))
                        {
                            HtmlForm htmlForm = new HtmlForm(billOutput);
                            htmlForm.Show();
                        }
                        else
                        {
                            TxtForm txtForm = new TxtForm(billOutput);
                            txtForm.Show();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите файл","Файл не выбран", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowBill_Click(object sender, EventArgs e)
        {
            Proccess();
        }
        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button_ToSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"D:\GIT\RRUK\Labs\Ninth lab\WinForms_TheLoayaltyProgram\WinForms_TheLoayaltyProgram\bin\Debug\net8.0-windows",
                Filter = "Yaml файлы (*.yaml)|*.yaml|HTML файлы (*.html;*.htm)|*.html;*.htm",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Получаем путь к выбранному файлу
                string filePath = openFileDialog.FileName;
                filename = Path.GetFileName(filePath);
                TB_FileName.Text = filename;
                // Здесь можно выполнить операции с выбранным файлом
                MessageBox.Show($"Выбраный файл: {filename}", "Файл выбран", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
