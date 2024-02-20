using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    //Класс отвечающий за представление в html
    public class HtmlView : IView
    {
        public string GetHeader(Customer _customer)
        {
            return $"<html><head><title>Чек для {_customer.getName()}</title></head><body>" +
                   $"<h1>Чек для {_customer.getName()}</h1>" +
                   "<table border=\"1\"><tr><th>Название</th><th>Цена</th><th>Кол-во</th><th>Стоимость</th><th>Скидка</th><th>Сумма</th><th>Бонус</th></tr>";
        }

        public string GetItemString(Item each, decimal discount, decimal thisAmount, int bonus)
        {
            return $"<tr><td>{each.getGoods().getTitle()}</td>" +
                   $"<td>{each.getPrice()}</td>" +
                   $"<td>{each.getQuantity()}</td>" +
                   $"<td>{each.getQuantity() * each.getPrice()}</td>" +
                   $"<td>{discount}</td>" +
                   $"<td>{thisAmount}</td>" +
                   $"<td>{bonus}</td></tr>";
        }

        public string GetFooter(decimal totalAmount, int totalBonus)
        {
            return $"</table><p>Сумма счета составляет {totalAmount}</p>" +
                   $"<p>Вы заработали {totalBonus} бонусных балов</p></body></html>";
        }
    }
}
