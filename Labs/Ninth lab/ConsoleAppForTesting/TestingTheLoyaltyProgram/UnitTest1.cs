using РРУК_01;
namespace TestingTheLoyaltyProgram
{
    public class Tests
    {
        private string nameHtmlSource = "BillInfo.html";
        private string nameYamlSource = "BillInfo.yaml";
        private IFileSource fileSourceHtml;
        private IFileSource fileSourceYaml;
        private BillFactory billFactoryHtml;
        private BillFactory billFactoryYaml;
        [SetUp]
        public void Setup()
        {
                    
        IView view = new TxtView();
            fileSourceHtml = FileSourceFactory.CreateFileSource(nameHtmlSource);
            billFactoryHtml = new BillFactory(fileSourceHtml);
            fileSourceYaml = FileSourceFactory.CreateFileSource(nameYamlSource);
            billFactoryYaml = new BillFactory(fileSourceYaml);
        }

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
                              "1: 1 5000 1"; // Покупка на 5000 рублей
            using (StringReader sr = new StringReader(testData))
            {
                BillGenerator billGenerator = billFactoryYaml.CreateBill(sr, "NewYearsSettings.json");
                var result = billGenerator.GenerateBill();
                // Ожидаем, что скидка не применяется, но бонусы начисляются 7% от 5000
                Assert.IsTrue(result.Contains("Сумма счета составляет 5000"));
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
                              "1: Razor_blades REG\r\n" +
                              "ItemsTotalCount: 1\r\n" +
                              "# ID: GID PRICE QTY\r\n" +
                              "1: 1 5000 1"; // Покупка на 5000 рублей
            using (StringReader sr = new StringReader(testData))
            {
                BillGenerator billGenerator = billFactoryYaml.CreateBill(sr, "RegularSettings.json");
                var result = billGenerator.GenerateBill();
                // Ожидаем, что скидка не применяется, но бонусы начисляются 5% от 5000
                Assert.IsTrue(result.Contains("Сумма счета составляет 5000"));
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
                var result = billGenerator.GenerateBill();
                // Ожидаем скидку 3% на товары со скидкой при покупке более чем на 2000 руб.
                Assert.IsTrue(result.Contains("Сумма счета составляет 3880,00")); // 4000 - 3% скидка
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
                var result = billGenerator.GenerateBill();
                // Ожидаем скидку 5% на акционные товары при покупке более чем на 3000 руб.
                Assert.IsTrue(result.Contains("Сумма счета составляет 3125,00")); // 3300 - 5% скидка
                Assert.IsTrue(result.Contains("Вы заработали 0 бонусных балов")); // Нет бонусов для акционных товаров
            }
        }
        [Test]
        public void Html_NewYearDiscountForThreeGoods()
        {
            string testData = "<html>\r\n<body>\r\n    " +
                "<customerName>Test</customerName>\r\n    " +
                "<customerBonus>10</customerBonus>\r\n    " +
                "<goodsCount>3</goodsCount>\r\n    " +
                "<good>\r\n        " +
                "<goodType>REG</goodType>\r\n        " +
                "<goodName>Cola</goodName>\r\n    " +
                "<goodType>SAL</goodType>\r\n        " +
                "<goodName>Pepsi</goodName>\r\n    " +
                "<goodType>SPO</goodType>\r\n        " +
                "<goodName>Fanta</goodName>\r\n    " +
                "</good>\r\n    " +
                "<itemsCount>3</itemsCount>\r\n    " +
                "<item>\r\n        " +
                "<itemId>1</itemId>\r\n        " +
                "<itemPrice>90</itemPrice>\r\n        " +
                "<itemQty>60</itemQty>\r\n" +
                "<itemId>2</itemId>\r\n        " +
                "<itemPrice>50</itemPrice>\r\n        " +
                "<itemQty>44</itemQty>\r\n\r\n        " +
                "<itemId>3</itemId>\r\n        " +
                "<itemPrice>76</itemPrice>\r\n        " +
                "<itemQty>40</itemQty>\r\n    " +
                "</item>\r\n" +
                "</body>\r\n" +
                "</html>\r\n"; // Покупка на 3300 рублей
            using (StringReader sr = new StringReader(testData))
            {
                BillGenerator billGenerator = billFactoryHtml.CreateBill(sr, "NewYearsSettings.json");
                var result = billGenerator.GenerateBill();
                // Ожидаем скидку 5% на акционные товары при покупке более чем на 3000 руб.
                Assert.IsTrue(result.Contains("Сумма счета составляет 10250,00")); // 3300 - 5% скидка
                Assert.IsTrue(result.Contains("Вы заработали 400 бонусных балов")); // Нет бонусов для акционных товаров
            }
        }
        [Test]
        public void Html_RegularDiscountForThreeGoods()
        {
            string testData = "<html>\r\n<body>\r\n    " +
                "<customerName>Test</customerName>\r\n    " +
                "<customerBonus>10</customerBonus>\r\n    " +
                "<goodsCount>3</goodsCount>\r\n    " +
                "<good>\r\n        " +
                "<goodType>REG</goodType>\r\n        " +
                "<goodName>Cola</goodName>\r\n    " +
                "<goodType>SAL</goodType>\r\n        " +
                "<goodName>Pepsi</goodName>\r\n    " +
                "<goodType>SPO</goodType>\r\n        " +
                "<goodName>Fanta</goodName>\r\n    " +
                "</good>\r\n    " +
                "<itemsCount>3</itemsCount>\r\n    " +
                "<item>\r\n        " +
                "<itemId>1</itemId>\r\n        " +
                "<itemPrice>90</itemPrice>\r\n        " +
                "<itemQty>60</itemQty>\r\n" +
                "<itemId>2</itemId>\r\n        " +
                "<itemPrice>50</itemPrice>\r\n        " +
                "<itemQty>44</itemQty>\r\n\r\n        " +
                "<itemId>3</itemId>\r\n        " +
                "<itemPrice>76</itemPrice>\r\n        " +
                "<itemQty>40</itemQty>\r\n    " +
                "</item>\r\n" +
                "</body>\r\n" +
                "</html>\r\n"; // Покупка на 3300 рублей
            using (StringReader sr = new StringReader(testData))
            {
                BillGenerator billGenerator = billFactoryHtml.CreateBill(sr, "RegularSettings.json");
                var result = billGenerator.GenerateBill();
                // Ожидаем скидку 5% на акционные товары при покупке более чем на 3000 руб.
                Assert.IsTrue(result.Contains("Сумма счета составляет 10430,800")); // 3300 - 5% скидка
                Assert.IsTrue(result.Contains("Вы заработали 292 бонусных балов")); // Нет бонусов для акционных товаров
            }
        }
    }
}