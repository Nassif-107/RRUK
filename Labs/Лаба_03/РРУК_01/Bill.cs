namespace РРУК_01
{
    public class Bill
    {
        private List<Item> _items;
        private Customer _customer;
        public Bill(Customer customer)
        {
            this._customer = customer;
            this._items = new List<Item>();
        }
        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }
        // Метод для вывода оглавления
        public string GetHeader()
        {
            return "Счет для " + _customer.getName() + "\n" +
                "\t" + "Название" + "\t" + "Цена" +
                "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" +
                "\t" + "Сумма" + "\t" + "Бонус" + "\n";
        }
        // Метод для вывода результата
        public string GetFooter(double totalAmount, int totalBonus)
        {
            return "Сумма счета составляет " + 
                totalAmount.ToString() + "\n" + 
                "Вы заработали " + totalBonus.ToString() + 
                " бонусных балов";
        }
        // Метод для вывода списка товаров
        public string GetItemString(Item each, double discount,
            double totalAmount, int bonus)
        {
            return "\t" + each.getGoods().getTitle() + "\t" +
                "\t" + each.getPrice() + "\t" + each.getQuantity() +
                "\t" + (GetSum(each)).ToString() +
                "\t" + discount.ToString() + "\t" + totalAmount.ToString() +
                "\t" + bonus.ToString() + "\n";
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
        public String statement()
        {
            double totalAmount = 0;
            int totalBonus = 0;
            List<Item>.Enumerator items = _items.GetEnumerator();
            String result = GetHeader();
            while (items.MoveNext())
            {
                Item each = (Item)items.Current;
                
                //определить сумму для каждой строки
                double discount = each.GetDiscount();
                int bonus = each.GetBonus();

                //показать результаты
                double sumWithDiscount = GetSum(each) - discount;
                double usedBonus = GetUsedBonus(each, sumWithDiscount);
                double thisAmount = sumWithDiscount - usedBonus;
                result += GetItemString(each, discount, thisAmount, bonus);
                totalAmount += thisAmount;
                totalBonus += bonus;
            }
            //добавить нижний колонтитул
            result += GetFooter(totalAmount, totalBonus);
            //Запомнить бонус клиента
            _customer.receiveBonus(totalBonus);
            return result;
        }
    }
}
