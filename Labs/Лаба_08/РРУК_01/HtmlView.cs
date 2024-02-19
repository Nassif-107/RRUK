using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    public class HtmlView : IView
    {
        // Метод для вывода оглавления
        public string GetHeader(Customer _customer)
        {
            throw new NotImplementedException();
        }
        // Метод для вывода результата
        public string GetFooter(double totalAmount, int totalBonus)
        {
            throw new NotImplementedException();
        }
        // Метод для вывода списка товаров
        public string GetItemString(Item each, double discount,
            double totalAmount, int bonus)
        {
            throw new NotImplementedException();
        }
    }
}
