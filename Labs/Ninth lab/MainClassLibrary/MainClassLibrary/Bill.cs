using System.Dynamic;

namespace РРУК_01
{
    //Класс вычислений чека 
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
        //---Метод получения использованных бонусов
        public int GetUsedBonus(Item each, decimal sumWithDiscount)
        {
            int usedBonus = 0;
            switch (each.getGoods().bonusStrategy.GetType())
            {
                //Обычный товав
                case Type t when (t == typeof(RegularBonusStrategy) || t == typeof(NewYearRegularBonusStrategy)):
                    if (each.getQuantity() > 5)
                        usedBonus = _customer.useBonus((int)(sumWithDiscount));
                    break;
                //Специальное предложение
                case Type t when t == typeof(SpecialBonusStrategy):
                    if (each.getQuantity() > 1)
                        usedBonus = _customer.useBonus((int)(sumWithDiscount));
                    break;
            }
            return usedBonus;
        }
        //---Метод получения цены с учётом количества
        public decimal GetSum(Item each)
        {
            return each.getQuantity() * each.getPrice();
        }
        public BillSummary Process()
        {
            List<Item>.Enumerator items = _items.GetEnumerator();
            var billSummary = new BillSummary
            {
                CustomerName = _customer.getName(),
                ItemSummaries = new List<ItemSummary>()
            };

            while (items.MoveNext())
            {
                Item each = items.Current;
                //------Определить сумму для каждой строки
                //---Получаем скидку
                decimal discount = each.GetDiscount();

                //---Получаем бонусы
                int bonus = each.GetBonus();

                //---Учитываем скидку и бонусы
                decimal itemSum = GetSum(each);
                decimal sumWithDiscount = itemSum - discount;
                int usedBonus = GetUsedBonus(each, sumWithDiscount);
                decimal thisAmount = sumWithDiscount - usedBonus;
                ItemSummary itemSummary = new ItemSummary
                {
                    Name = each.getGoods().getTitle(),
                    Price = each.getPrice(),
                    Quantity = each.getQuantity(),
                    Sum = thisAmount,
                    Discount = discount,
                    Bonus = bonus
                };
                billSummary.ItemSummaries.Add(itemSummary);
                //---Добавление суммы и Накопление бонусов
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
