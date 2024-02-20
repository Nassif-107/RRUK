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
            throw new NotImplementedException();
        }
        public string GetItemString(Item each, decimal discount, decimal thisAmount, int bonus)
        {
            throw new NotImplementedException();
        }
        public string GetFooter(decimal totalAmount, int totalBonus)
        {
            throw new NotImplementedException();
        }
    }
}
