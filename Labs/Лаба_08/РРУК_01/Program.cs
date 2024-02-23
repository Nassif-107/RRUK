using System.Text;

namespace РРУК_01
{
    public class Program
    {
        static void Main(string[] args)
        {
            //string filename = "BillInfo.yaml";
            //if (args.Length == 1)
            //    filename = args[0];
            //IFileSource fileSource = FileSourceFactory.CreateFileSource(filename);

            //using (FileStream fs = new FileStream(filename, FileMode.Open))
            //using (StreamReader sr = new StreamReader(fs))
            //{
            //    BillFactory factory = new BillFactory(fileSource);
            //    BillGenerator bill = factory.CreateBill(sr, "NewYearsSettings.json");
            //    string billOutput = bill.GetBIll();
            //    Console.WriteLine(billOutput);
            //}

            Customer customer = new Customer("Тестовый клиент", 10);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            GoodsFactory goodsFactory = new GoodsFactory();
            Goods goods = goodsFactory.Create("REG", "Товар 1", 0);
            bill.addGoods(new Item(goods, 1, 100));
            var result = bill.GetBIll();
            Console.WriteLine(result);
        }
    }
}