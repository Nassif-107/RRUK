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
        public void EmptyBillTest()
        {
            var result = bill.statement();
            var expectedFooter = "Сумма счета составляет 0\nВы заработали 0 бонусных балов";
            Assert.IsTrue(result.Contains(expectedFooter));
        }
        [Test]
        public void BillSingleItem()
        {
            bill.addGoods(new Item(new Goods("Товар 1", Goods.REGULAR), 1, 100));
            var result = bill.statement();
            Assert.IsTrue(result.Contains("Товар 1"));
            Assert.IsTrue(result.Contains("Сумма счета составляет 100\n"));
            Assert.IsTrue(result.Contains("Вы заработали 5 бонусных балов"));

        }
        [Test]
        public void BIllMultipleItems()
        {
            bill.addGoods(new Item(new Goods("Товар 1", Goods.REGULAR), 3, 100));
            bill.addGoods(new Item(new Goods("Товар 2", Goods.SPECIAL_OFFER), 11, 50));
            var result = bill.statement();
            Assert.IsTrue(result.Contains("Сумма счета составляет 831"));
            Assert.IsTrue(result.Contains("Вы заработали 15 бонусных балов"));
        }
        [Test]
        public void DiscountsBonuses()
        {
            bill.addGoods(new Item(new Goods("Товар со скидкой", Goods.SALE), 11, 200));
            var result = bill.statement();
            Assert.IsTrue(result.Contains("Сумма счета составляет 2178"));
            Assert.IsTrue(result.Contains("Вы заработали 22 бонусных балов"));
        }
        [Test]
        public void Statement_UsingCustomerBonuses_ReturnsCorrectDiscount()
        {
            customer.receiveBonus(100);
            bill.addGoods(new Item(new Goods("Товар с использованием бонусов", Goods.REGULAR), 6, 100));
            var result = bill.statement();
            Assert.IsTrue(result.Contains("Вы заработали 30 бонусных балов"));
        }
    }
}