using РРУК_01;

namespace regressionTesting
{
    public class Tests
    {
        private BillGenerator bill;
        private Customer customer;

        [SetUp]
        public void Setup()
        {
            customer = new Customer("Тестовый клиент",10);
            IView view = new TxtView();
            bill = new BillGenerator(customer, view);
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
            bill.addGoods(new Item(new RegularGoods("Товар 1"), 1, 100));
            var result = bill.GetBIll();
            Assert.IsTrue(result.Contains("Сумма счета составляет 100\n"));
            Assert.IsTrue(result.Contains("Вы заработали 5 бонусных балов"));

        }
        [Test]
        public void test3()
        {
            bill.addGoods(new Item(new SpecialGoods("Товар 2"), 11, 50));
            var result = bill.GetBIll();
            Assert.IsTrue(result.Contains("Сумма счета составляет 537,25"));
            Assert.IsTrue(result.Contains("Вы заработали 0 бонусных балов"));
        }
        [Test]
        public void test4()
        {
            bill.addGoods(new Item(new SaleGoods("Товар со скидкой"), 11, 200));
            var result = bill.GetBIll();
            Assert.IsTrue(result.Contains("Сумма счета составляет 2178"));
            Assert.IsTrue(result.Contains("Вы заработали 22 бонусных балов"));
        }
        [Test]
        public void test5()
        {
            bill.addGoods(new Item(new SpecialGoods("Товар 2"), 5, 50));
            var result = bill.GetBIll();
            Assert.IsTrue(result.Contains("Сумма счета составляет 240"));
            Assert.IsTrue(result.Contains("Вы заработали 0 бонусных балов"));
        }
        [Test]
        public void test6()
        {
            bill.addGoods(new Item(new SaleGoods("Товар со скидкой"), 2, 200));
            var result = bill.GetBIll();
            Assert.IsTrue(result.Contains("Сумма счета составляет 400"));
            Assert.IsTrue(result.Contains("Вы заработали 4 бонусных балов"));
        }
        [Test]
        public void test7()
        {
            bill.addGoods(new Item(new RegularGoods("Товар 1"), 3, 100));
            var result = bill.GetBIll();
            Assert.IsTrue(result.Contains("Сумма счета составляет 291\n"));
            Assert.IsTrue(result.Contains("Вы заработали 15 бонусных балов"));
        }
        [Test]
        public void test8()
        {
            bill.addGoods(new Item(new RegularGoods("Товар 1"), 2, 100));
            var result = bill.GetBIll();
            Assert.IsTrue(result.Contains("Сумма счета составляет 200\n"));
            Assert.IsTrue(result.Contains("Вы заработали 10 бонусных балов"));
        }
        [Test]
        public void test9()
        {
            bill.addGoods(new Item(new RegularGoods("Товар 1"), 0, 100));
            var result = bill.GetBIll();
            Assert.IsTrue(result.Contains("Сумма счета составляет 0"));
            Assert.IsTrue(result.Contains("Вы заработали 0 бонусных балов"));
        }
        [Test]
        public void test10()
        {
            bill.addGoods(new Item(new RegularGoods("Товар 1"), 6, 100));
            bill.addGoods(new Item(new SaleGoods("Товар со скидкой"), 11, 200));
            bill.addGoods(new Item(new SpecialGoods("Товар 2"), 15, 50));
            var result = bill.GetBIll();
            Assert.IsTrue(result.Contains("Сумма счета составляет 3496,25"));
            Assert.IsTrue(result.Contains("Вы заработали 52 бонусных балов"));
        }
    }
}