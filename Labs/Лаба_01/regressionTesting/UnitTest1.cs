using РРУК_01;

namespace regressionTesting
{
    public class Tests
    {
        private Bill bill;
        private Customer customer;

        [SetUp]
        public void Setup()
        {
            customer = new Customer("Тестовый клиент",10);
            bill = new Bill(customer);
        }
        [Test]
        public void test1()
        {
            var result = bill.statement();
            var expectedFooter = "Сумма счета составляет 0\nВы заработали 0 бонусных балов";
            Assert.IsTrue(result.Contains(expectedFooter));
        }
        [Test]
        public void test2()
        {
            bill.addGoods(new Item(new Goods("Товар 1", Goods.REGULAR), 1, 100));
            var result = bill.statement();
            Assert.IsTrue(result.Contains("Сумма счета составляет 100\n"));
            Assert.IsTrue(result.Contains("Вы заработали 5 бонусных балов"));

        }
        [Test]
        public void test3()
        {
            bill.addGoods(new Item(new Goods("Товар 2", Goods.SPECIAL_OFFER), 11, 50));
            var result = bill.statement();
            Assert.IsTrue(result.Contains("Сумма счета составляет 540"));
            Assert.IsTrue(result.Contains("Вы заработали 0 бонусных балов"));
        }
        [Test]
        public void test4()
        {
            bill.addGoods(new Item(new Goods("Товар со скидкой", Goods.SALE), 11, 200));
            var result = bill.statement();
            Assert.IsTrue(result.Contains("Сумма счета составляет 2178"));
            Assert.IsTrue(result.Contains("Вы заработали 22 бонусных балов"));
        }
        [Test]
        public void test5()
        {
            bill.addGoods(new Item(new Goods("Товар 2", Goods.SPECIAL_OFFER), 5, 50));
            var result = bill.statement();
            Assert.IsTrue(result.Contains("Сумма счета составляет 240"));
            Assert.IsTrue(result.Contains("Вы заработали 0 бонусных балов"));
        }
        [Test]
        public void test6()
        {
            bill.addGoods(new Item(new Goods("Товар со скидкой", Goods.SALE), 2, 200));
            var result = bill.statement();
            Assert.IsTrue(result.Contains("Сумма счета составляет 400"));
            Assert.IsTrue(result.Contains("Вы заработали 4 бонусных балов"));
        }
        [Test]
        public void test7()
        {
            bill.addGoods(new Item(new Goods("Товар 1", Goods.REGULAR), 3, 100));
            var result = bill.statement();
            Assert.IsTrue(result.Contains("Сумма счета составляет 291\n"));
            Assert.IsTrue(result.Contains("Вы заработали 15 бонусных балов"));
        }
        [Test]
        public void test8()
        {
            bill.addGoods(new Item(new Goods("Товар 1", Goods.REGULAR), 2, 100));
            var result = bill.statement();
            Assert.IsTrue(result.Contains("Сумма счета составляет 200\n"));
            Assert.IsTrue(result.Contains("Вы заработали 10 бонусных балов"));
        }
        [Test]
        public void test9()
        {
            bill.addGoods(new Item(new Goods("Товар 1", Goods.REGULAR), 0, 100));
            var result = bill.statement();
            Assert.IsTrue(result.Contains("Сумма счета составляет 0"));
            Assert.IsTrue(result.Contains("Вы заработали 0 бонусных балов"));
        }
        [Test]
        public void test10()
        {
            bill.addGoods(new Item(new Goods("Товар 1", Goods.REGULAR), 6, 100));
            bill.addGoods(new Item(new Goods("Товар со скидкой", Goods.SALE), 11, 200));
            bill.addGoods(new Item(new Goods("Товар 2", Goods.SPECIAL_OFFER), 15, 50));
            var result = bill.statement();
            Assert.IsTrue(result.Contains("Сумма счета составляет 3500"));
            Assert.IsTrue(result.Contains("Вы заработали 52 бонусных балов"));
        }
    }
}