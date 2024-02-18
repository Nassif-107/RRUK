namespace РРУК_01
{
    public class Bill
    {
        private List<Item> _items;
        private Customer _customer;
        private IView view;
        public IView View
        {
            get { return view; }
            set { view = value; }
        }
        public Bill(Customer customer, IView view)
        {
            this._customer = customer;
            this._items = new List<Item>();
            this.view = view;
        }
        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }        
        // Метод для вычисления суммы
        public double GetSum(Item each)
        {
            return each.getQuantity() * each.getPrice();
        }
        //---Метод получения использованных бонусов
        public double GetUsedBonus(Item each, double sumWithDiscount)
        {
            double usedBonus = 0;
            if (each.getGoods().GetType() == typeof(RegularGoods))
            {
                if (each.getQuantity() > 5)
                    usedBonus = _customer.useBonus((int)(sumWithDiscount));
            } else if (each.getGoods().GetType() == typeof(SpecialGoods))
            {
                if (each.getQuantity() > 1)
                    usedBonus = _customer.useBonus((int)(sumWithDiscount));
            }
            return usedBonus;
        }
        public BillSummary Process()
        {
            BillSummary billSummary = new BillSummary();
            List<Item>.Enumerator items = _items.GetEnumerator();
            while (items.MoveNext())
            {
                Item each = (Item)items.Current;
                
                //определить сумму для каждой строки
                double discount = each.GetDiscount();
                int bonus = each.GetBonus();
                double sumWithDiscount = GetSum(each) - discount;
                double usedBonus = GetUsedBonus(each, sumWithDiscount);
                double thisAmount = sumWithDiscount - usedBonus;

                ItemSummary itemSummary = new ItemSummary(
                    name: each.getGoods().getTitle(),
                    price: each.getPrice(),
                    quantity: each.getQuantity(),
                    sum: sumWithDiscount,
                    discount: discount,
                    bonus: bonus
                );
                billSummary.ItemSummaries.Add(itemSummary);

                billSummary.TotalAmount += thisAmount;
                billSummary.TotalDiscount += discount;
                billSummary.TotalBonus += bonus;
            }
            //Запомнить бонус клиента
            _customer.receiveBonus(billSummary.TotalBonus);
            return billSummary;
        }
    }
}
