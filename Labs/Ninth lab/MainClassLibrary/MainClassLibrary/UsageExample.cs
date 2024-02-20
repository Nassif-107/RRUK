namespace РРУК_01
{
    public class UsageExample
    {
        static void Example(string[] args)
        {
            IBonusStrategy bonusStrategy;
            IDiscountStrategy discountStrategy;
            Goods cola = new Goods("Cola", bonusStrategy=new RegularBonusStrategy(), discountStrategy=new RegularDiscountStrategy());
            Goods pepsi = new Goods("Pepsi",bonusStrategy=new SaleBonusStrategy(),discountStrategy = new SaleDiscountStrategy());
            Item i1 = new Item(cola, 6, 65);
            Item i2 = new Item(pepsi, 3, 50);
            Customer x = new Customer("test", 10);
            IView view = new TxtView();
            BillGenerator b1 = new BillGenerator(x, view);
            b1.addGoods(i1);
            b1.addGoods(i2);
            string bill = b1.GenerateBill();
            Console.WriteLine(bill);
        }
    }
}
