using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    public class ItemSummary
    {
        public string Name;
        public double Price;
        public double Quantity;
        public double Sum;
        public double Discount;
        public int Bonus;

        public ItemSummary(string name, double price, double quantity,
            double sum, double discount, int bonus)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Sum = sum;
            Discount = discount;
            Bonus = bonus;
        }
    }
}
