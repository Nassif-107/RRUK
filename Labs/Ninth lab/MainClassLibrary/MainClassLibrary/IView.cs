using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    //Интерфейс представления
    public interface IView
    {
        string GetHeader(Customer _customer);
        string GetItemString(Item each, decimal discount, decimal thisAmount, int bonus);
        string GetFooter(decimal totalAmount, int totalBonus);
    }
}
