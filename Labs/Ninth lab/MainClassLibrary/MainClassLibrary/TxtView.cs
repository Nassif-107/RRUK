using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    //Класс отвечающий за представление в txt
    public class TxtView : IView
    {
        //---Метод для получения оглавлений чека
        public string GetHeader(Customer _customer)
        {
            return "Счет для " + _customer.getName() + "\n" +
                "\t" + "Название" + "\t" + "Цена" +
                "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" +
                "\t" + "Сумма" + "\t" + "Бонус" + "\n";
        }
        //---Метод для получения списка товаров
        public string GetItemString(Item each, decimal discount, decimal thisAmount, int bonus)
        {
            return "\t" + each.getGoods().getTitle() + "\t" +
                "\t" + each.getPrice() + "\t" + each.getQuantity() +
                "\t" + (each.getQuantity() * each.getPrice()).ToString() +
                "\t" + discount.ToString() + "\t" + thisAmount.ToString() +
                "\t" + bonus.ToString() + "\n"; ;
        }
        //---Метод для получения нижнего колонтитула чека
        public string GetFooter(decimal totalAmount, int totalBonus)
        {
            return "Сумма счета составляет " +
               totalAmount.ToString() + "\n" +
               "Вы заработали " + totalBonus.ToString() +
               " бонусных балов";
        }
    }
}
