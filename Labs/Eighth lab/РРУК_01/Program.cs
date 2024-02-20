using System.Text;
using РРУК_01;

namespace РРУК_01
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filename = "BillInfo.yaml";
            if (args.Length == 1)
                filename = args[0];
            IFileSource fileSource = FileSourceFactory.CreateFileSource(filename);

            using (FileStream fs = new FileStream(filename, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                BillFactory factory = new BillFactory(fileSource);
                BillGenerator bill = factory.CreateBill(sr, "NewYearsSettings.json");
                string billOutput = bill.GenerateBill();
                Console.WriteLine(billOutput);
            }


            //string testData = "CustomerName: Test\r\n" +
            //                  "CustomerBonus: 10\r\n" +
            //                  "GoodsTotalCount: 1\r\n" +
            //                  "# ID: NAME TYPE(REG/SAL/SPO)\r\n" +
            //                  "1: Milk REG\r\n" +
            //                  "ItemsTotalCount: 1\r\n" +
            //                  "# ID: GID PRICE QTY\r\n" +
            //                  "1: 1 100 50"; // Покупка на 5000 рублей
            //string filename = "BillInfo.yaml";
            //IFileSource fileSource = FileSourceFactory.CreateFileSource(filename);
            //BillFactory factory = new BillFactory(fileSource);
            //using (StringReader sr = new StringReader(testData))
            //{
            //    BillGenerator billGenerator = factory.CreateBill(sr, "RegularSettings.json");
            //    var result = billGenerator.GenerateBill();
            //    Console.WriteLine(result);
            //}

            //Customer customer = new Customer("Тестовый клиент", 10);
            //IView view = new TxtView();
            //var bill = new BillGenerator(customer, view);
            //GoodsFactory goodsFactory = new GoodsFactory();
            //// Создаем товар с использованием GoodsFactory и обычной стратегии (strategyType = 0)
            //Goods goods = goodsFactory.Create("REG", "Товар 1", 0);
            //bill.addGoods(new Item(goods, 1, 100));
            //var result = bill.GenerateBill();
            //Console.WriteLine(result);
        }
    }
}


//string filename = "BillInfo.yaml";
//if (args.Length == 1)
//    filename = args[0];
//using (FileStream fs = new FileStream(filename, FileMode.Open))
//using (StreamReader sr = new StreamReader(fs))
//{
//    YamlFileSource readContent = new YamlFileSource();
//    readContent.SetSource(sr);
//    // Чтение покупателя
//    Customer customer = readContent.GetCustomer();
//    IView view = new TxtView();
//    BillGenerator billGenerator = new BillGenerator(customer, view);
//    //Чтение количества продуктов
//    int goodsQty = readContent.GetGoodsCount();
//    Goods[] g = new Goods[goodsQty];
//    //Чтение каждого продукта
//    for (int i = 0; i < g.Length; i++)
//    {
//        g[i] = readContent.GetNextGood();
//    }
//    //Чтение количества товаров
//    int itemsQty = readContent.GetItemsCount();
//    //Чтение каждого товара
//    for (int i = 0; i < itemsQty; i++)
//    {
//        billGenerator.addGoods(readContent.GetNextItem(g));
//    }
//    string billOutput = billGenerator.GenerateBill();
//    Console.WriteLine(billOutput);
//}











//string filename = "BillInfo.yaml";
//if (args.Length == 1)
//    filename = args[0];
//FileStream fs = new FileStream(filename, FileMode.Open);
//StreamReader sr = new StreamReader(fs);
//// read customer
//string line = sr.ReadLine();
//string[] result = line.Split(':');
//string name = result[1].Trim();
//// read bonus
//line = sr.ReadLine();
//result = line.Split(':');
//int bonus = Convert.ToInt32(result[1].Trim());
//Customer customer = new Customer(name, bonus);
//IView view = new TxtView();
//BillGenerator b = new BillGenerator(customer, view);
//// read goods count
//line = sr.ReadLine();
//result = line.Split(':');
//int goodsQty = Convert.ToInt32(result[1].Trim());
//Goods[] g = new Goods[goodsQty];
//for (int i = 0; i < g.Length; i++)
//{
//    // Пропустить комментарии
//    do
//    {
//        line = sr.ReadLine();
//    } while (line.StartsWith("#"));
//    result = line.Split(':');
//    result = result[1].Trim().Split();
//    string type = result[1].Trim();
//    switch (type)
//    {
//        case "REG":
//            g[i] = new RegularGoods(result[0]);
//            break;
//        case "SAL":
//            g[i] = new SaleGoods(result[0]);
//            break;
//        case "SPO":
//            g[i] = new SpecialGoods(result[0]);
//            break;
//    }
//}
//// read items count
//// Пропустить комментарии
//do
//{
//    line = sr.ReadLine();
//} while (line.StartsWith("#"));
//result = line.Split(':');
//int itemsQty = Convert.ToInt32(result[1].Trim());
//for (int i = 0; i < itemsQty; i++)
//{
//    // Пропустить комментарии
//    do
//    {
//        line = sr.ReadLine();
//    } while (line.StartsWith("#"));
//    result = line.Split(':');
//    result = result[1].Trim().Split();
//    int gid = Convert.ToInt32(result[0].Trim());
//    decimal price = Convert.ToDecimal(result[1].Trim());
//    int qty = Convert.ToInt32(result[2].Trim());
//    b.addGoods(new Item(g[gid - 1], qty, price));
//}
//string bill = b.GenerateBill();
//Console.WriteLine(bill);




//string filename = "BillInfo.yaml";
//if (args.Length == 1)
//    filename = args[0];
//FileStream fs = new FileStream(filename, FileMode.Open);
//StreamReader sr = new StreamReader(fs);
//// read customer
//string line = sr.ReadLine();
//string[] result = line.Split(':');
//string name = result[1].Trim();
//// read bonus
//line = sr.ReadLine();
//result = line.Split(':');
//int bonus = Convert.ToInt32(result[1].Trim());
//Customer customer = new Customer(name, bonus);
//Bill b = new Bill(customer);
//// read goods count
//line = sr.ReadLine();
//result = line.Split(':');
//int goodsQty = Convert.ToInt32(result[1].Trim());
//Goods[] g = new Goods[goodsQty];
//for (int i = 0; i < g.Length; i++)
//{
//    // Пропустить комментарии
//    do
//    {
//        line = sr.ReadLine();
//    } while (line.StartsWith("#"));
//    result = line.Split(':');
//    result = result[1].Trim().Split();
//    string type = result[1].Trim();
//    int t = 0;
//    switch (type)
//    {
//        case "REG":
//            t = Goods.REGULAR;
//            break;
//        case "SAL":
//            t = Goods.SALE;
//            break;
//        case "SPO":
//            t = Goods.SPECIAL_OFFER;
//            break;
//    }
//    g[i] = new Goods(result[0], t);
//}
//// read items count
//// Пропустить комментарии
//do
//{
//    line = sr.ReadLine();
//} while (line.StartsWith("#"));
//result = line.Split(':');
//int itemsQty = Convert.ToInt32(result[1].Trim());
//for (int i = 0; i < itemsQty; i++)
//{
//    // Пропустить комментарии
//    do
//    {
//        line = sr.ReadLine();
//    } while (line.StartsWith("#"));
//    result = line.Split(':');
//    result = result[1].Trim().Split();
//    int gid = Convert.ToInt32(result[0].Trim());
//    double price = Convert.ToDouble(result[1].Trim());
//    int qty = Convert.ToInt32(result[2].Trim());
//    b.addGoods(new Item(g[gid - 1], qty, price));
//}
//string bill = b.statement();
//Console.WriteLine(bill);