using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    public class TxtView : IView
    {
        // Метод для вывода оглавления
        public string GetHeader(Customer _customer)
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
                "\t" + (each.getQuantity() * each.getPrice()).ToString() +
                "\t" + discount.ToString() + "\t" + totalAmount.ToString() +
                "\t" + bonus.ToString() + "\n";
        }
    }
}
