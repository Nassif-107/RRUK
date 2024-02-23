using РРУК_01;

namespace regressionTesting
{
    public class Tests
    {
        private BillGenerator bill;
        private Customer customer;
        private BillFactory billFactoryHtml;
        private BillFactory billFactoryYaml;
        private string nameHtmlSource = "BillInfo.html";
        private string nameYamlSource = "BillInfo.yaml";
        IFileSource fileSourceHtml;
        IFileSource fileSourceYaml;

        [SetUp]
        public void Setup()
        {
            fileSourceHtml = FileSourceFactory.CreateFileSource(nameHtmlSource);
            billFactoryHtml = new BillFactory(fileSourceHtml);
            fileSourceYaml = FileSourceFactory.CreateFileSource(nameYamlSource);
            billFactoryYaml = new BillFactory(fileSourceYaml);

            customer = new Customer("Тестовый клиент",10);
            IView view = new TxtView();
            bill = new BillGenerator(customer, view);
        }
        // ЛАБА 8
        [Test]
        public void NewYearDiscountAndBonusForRegularGoods()
        {
            // Предположим, что даты предновогодних недель учитываются внутри стратегий
            string testData = "CustomerName: Test\r\n" +
                              "CustomerBonus: 10\r\n" +
                              "GoodsTotalCount: 1\r\n" +
                              "# ID: NAME TYPE(REG/SAL/SPO)\r\n" +
                              "1: Milk REG\r\n" +
                              "ItemsTotalCount: 1\r\n" +
                              "# ID: GID PRICE QTY\r\n" +
                              "1: 1 100 50"; // Покупка на 5000 рублей
            using (StringReader sr = new StringReader(testData))
            {
                BillGenerator billGenerator = billFactoryYaml.CreateBill(sr, "NewYearsSettings.json");
                var result = billGenerator.GetBIll();
                // Ожидаем, что скидка не применяется, но бонусы начисляются 7% от 5000
                Assert.IsTrue(result.Contains("Сумма счета составляет 4840"));
                Assert.IsTrue(result.Contains("Вы заработали 350 бонусных балов"));
            }
        }
        [Test]
        public void UsualDiscountAndBonusForRegularGoods()
        {
            // Предположим, что даты предновогодних недель учитываются внутри стратегий
            string testData = "CustomerName: Test\r\n" +
                              "CustomerBonus: 10\r\n" +
                              "GoodsTotalCount: 1\r\n" +
                              "# ID: NAME TYPE(REG/SAL/SPO)\r\n" +
                              "1: Milk REG\r\n" +
                              "ItemsTotalCount: 1\r\n" +
                              "# ID: GID PRICE QTY\r\n" +
                              "1: 1 100 50"; // Покупка на 5000 рублей
            using (StringReader sr = new StringReader(testData))
            {
                BillGenerator billGenerator = billFactoryYaml.CreateBill(sr, "RegularSettings.json");
                var result = billGenerator.GetBIll();
                // Ожидаем, что скидка не применяется, но бонусы начисляются 7% от 5000
                Assert.IsTrue(result.Contains("Сумма счета составляет 4840"));
                Assert.IsTrue(result.Contains("Вы заработали 250 бонусных балов"));
            }
        }
        [Test]
        public void NewYearDiscountForSaleGoods()
        {
            string testData = "CustomerName: Test\r\n" +
                              "CustomerBonus: 10\r\n" +
                              "GoodsTotalCount: 1\r\n" +
                              "# ID: NAME TYPE(REG/SAL/SPO)\r\n" +
                              "1: Christmas_Tree SAL\r\n" +
                              "ItemsTotalCount: 1\r\n" +
                              "# ID: GID PRICE QTY\r\n" +
                              "1: 1 2000 2"; // Покупка на 4000 рублей
            using (StringReader sr = new StringReader(testData))
            {
                BillGenerator billGenerator = billFactoryYaml.CreateBill(sr, "NewYearsSettings.json");
                var result = billGenerator.GetBIll();
                // Ожидаем скидку 3% на товары со скидкой при покупке более чем на 2000 руб.
                Assert.IsTrue(result.Contains("Сумма счета составляет 3880")); // 4000 - 3% скидка
                Assert.IsTrue(result.Contains("Вы заработали 40 бонусных балов")); // 1% от 4000
            }
        }
        [Test]
        public void NewYearDiscountForSpecialGoods()
        {
            string testData = "CustomerName: Test\r\n" +
                              "CustomerBonus: 10\r\n" +
                              "GoodsTotalCount: 1\r\n" +
                              "# ID: NAME TYPE(REG/SAL/SPO)\r\n" +
                              "1: New_Year_Candy SPO\r\n" +
                              "ItemsTotalCount: 1\r\n" +
                              "# ID: GID PRICE QTY\r\n" +
                              "1: 1 300 11"; // Покупка на 3300 рублей
            using (StringReader sr = new StringReader(testData))
            {
                BillGenerator billGenerator = billFactoryYaml.CreateBill(sr, "NewYearsSettings.json");
                var result = billGenerator.GetBIll();
                // Ожидаем скидку 5% на акционные товары при покупке более чем на 3000 руб.
                Assert.IsTrue(result.Contains("Сумма счета составляет 3125")); // 3300 - 5% скидка
                Assert.IsTrue(result.Contains("Вы заработали 0 бонусных балов")); // Нет бонусов для акционных товаров
            }
        }

        // ЛАБА 7
        [Test]
        public void htmlFile()
        {
            using (FileStream fs = new FileStream(nameHtmlSource, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                BillGenerator bill = billFactoryHtml.CreateBill(sr, "RegularSettings.json");
                string result = bill.GetBIll();
                Assert.IsTrue(result.Contains("Сумма счета составляет 553,3"));
                Assert.IsTrue(result.Contains("Вы заработали 20 бонусных балов"));
            }
        }
        [Test]
        public void yamlFile()
        {
            using (FileStream fs = new FileStream(nameYamlSource, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                BillGenerator bill = billFactoryYaml.CreateBill(sr, "RegularSettings.json");
                string result = bill.GetBIll();
                Assert.IsTrue(result.Contains("Сумма счета составляет 553,3"));
                Assert.IsTrue(result.Contains("Вы заработали 20 бонусных балов"));
            }
        }
        // ЛАБА 6

        [Test]
        public void OneGoodTestCreateBill()
        {
            string testData = "CustomerName: Test\r\n" +
                "CustomerBonus: 10\r\n" +
                "GoodsTotalCount: 1\r\n" +
                "# ID: NAME TYPE(REG/SAL/SPO)\r\n" +
                "1: Cola REG\r\n" +
                "ItemsTotalCount: 1\r\n" +
                "# ID: GID PRICE QTY\r\n" +
                "1: 1 80 20";
            using (StringReader sr = new StringReader(testData))
            {
                BillGenerator billGenerator = billFactoryYaml.CreateBill(sr);
                var result = billGenerator.GetBIll();
                Assert.IsTrue(result.Contains("Сумма счета составляет 1542"));
                Assert.IsTrue(result.Contains("Вы заработали 80 бонусных балов"));
            }
        }
        [Test]
        public void TestBillGeneratorCreation()
        {
            string testData = "CustomerName: Test\r\n" +
                "CustomerBonus: 10\r\n" +
                "GoodsTotalCount: 3\r\n" +
                "# ID: NAME TYPE(REG/SAL/SPO)\r\n" +
                "1: Cola REG\r\n" +
                "2: Pepsi SAL\r\n" +
                "3: Fanta SPO\r\n" +
                "ItemsTotalCount: 3\r\n" +
                "# ID: GID PRICE QTY\r\n" +
                "1: 1 65 6\r\n" +
                "2: 2 50 3\r\n" +
                "3: 3 35 1";
            using (StringReader sr = new StringReader(testData))
            {
                BillGenerator billGenerator = billFactoryYaml.CreateBill(sr);
                var result = billGenerator.GetBIll();
                Assert.IsTrue(result.Contains("Сумма счета составляет 553,3"));
                Assert.IsTrue(result.Contains("Вы заработали 20 бонусных балов"));
            }
        }

        [Test]
        public void test1()
        {
            var result = bill.GetBIll();
            var expectedFooter = "Сумма счета составляет 0\nВы заработали 0 бонусных балов";
            Assert.IsTrue(result.Contains(expectedFooter));
        }
        [Test]
        public void test2()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            Goods goods = goodsFactory.Create("REG", "Товар 1", 0);
            bill.addGoods(new Item(goods, 1, 100));
            var result = bill.GetBIll();
            Assert.IsTrue(result.Contains("Сумма счета составляет 100\n"));
            Assert.IsTrue(result.Contains("Вы заработали 5 бонусных балов"));

        }
        [Test]
        public void test3()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            Goods goods = goodsFactory.Create("SPO", "Товар 2", 0); // Создаем специальный товар
            bill.addGoods(new Item(goods, 11, 50));
            var result = bill.GetBIll();
            Assert.IsTrue(result.Contains("Сумма счета составляет 537,25"));
            Assert.IsTrue(result.Contains("Вы заработали 0 бонусных балов"));
        }
        [Test]
        public void test4()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            Goods goods = goodsFactory.Create("SAL", "Товар со скидкой", 0); // Создаем товар со скидкой
            bill.addGoods(new Item(goods, 11, 200));
            var result = bill.GetBIll();
            Assert.IsTrue(result.Contains("Сумма счета составляет 2178"));
            Assert.IsTrue(result.Contains("Вы заработали 22 бонусных балов"));
        }
        [Test]
        public void test5()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            Goods goods = goodsFactory.Create("SPO", "Товар 2", 0); // Создаем специальный товар
            bill.addGoods(new Item(goods, 5, 50));
            var result = bill.GetBIll();
            Assert.IsTrue(result.Contains("Сумма счета составляет 240"));
            Assert.IsTrue(result.Contains("Вы заработали 0 бонусных балов"));
        }
        [Test]
        public void test6()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            Goods goods = goodsFactory.Create("SAL", "Товар со скидкой", 0); // Создаем товар со скидкой
            bill.addGoods(new Item(goods, 2, 200));
            var result = bill.GetBIll();
            Assert.IsTrue(result.Contains("Сумма счета составляет 400"));
            Assert.IsTrue(result.Contains("Вы заработали 4 бонусных балов"));
        }
        [Test]
        public void test7()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            Goods goods = goodsFactory.Create("REG", "Товар 1", 0); // Создаем обычный товар
            bill.addGoods(new Item(goods, 3, 100));
            var result = bill.GetBIll();
            Assert.IsTrue(result.Contains("Сумма счета составляет 291\n"));
            Assert.IsTrue(result.Contains("Вы заработали 15 бонусных балов"));
        }
        [Test]
        public void test8()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            Goods goods = goodsFactory.Create("REG", "Товар 1", 0); // Создаем обычный товар
            bill.addGoods(new Item(goods, 2, 100));
            var result = bill.GetBIll();
            Assert.IsTrue(result.Contains("Сумма счета составляет 200\n"));
            Assert.IsTrue(result.Contains("Вы заработали 10 бонусных балов"));
        }

        [Test]
        public void test9()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            Goods goods = goodsFactory.Create("REG", "Товар 1", 0); // Создаем обычный товар
            bill.addGoods(new Item(goods, 0, 100));
            var result = bill.GetBIll();
            Assert.IsTrue(result.Contains("Сумма счета составляет 0"));
            Assert.IsTrue(result.Contains("Вы заработали 0 бонусных балов"));
        }
        [Test]
        public void test10()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            Goods goodsReg = goodsFactory.Create("REG", "Товар 1", 0); // Создаем обычный товар
            Goods goodsSal = goodsFactory.Create("SAL", "Товар со скидкой", 0); // Создаем товар со скидкой
            Goods goodsSpo = goodsFactory.Create("SPO", "Товар 2", 0); // Создаем специальный товар
            bill.addGoods(new Item(goodsReg, 6, 100));
            bill.addGoods(new Item(goodsSal, 11, 200));
            bill.addGoods(new Item(goodsSpo, 15, 50));
            var result = bill.GetBIll();
            Assert.IsTrue(result.Contains("Сумма счета составляет 3496,25"));
            Assert.IsTrue(result.Contains("Вы заработали 52 бонусных балов"));
        }
    }
}