using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    public interface IView
    {
        string GetHeader(Customer _customer);
        string GetFooter(double totalAmount, int totalBonus);
        string GetItemString(Item each, double discount,
            double totalAmount, int bonus);
    }
}
