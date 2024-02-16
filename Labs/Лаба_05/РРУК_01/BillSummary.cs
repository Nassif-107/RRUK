using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    public class BillSummary
    {
        public double TotalAmount;
        public double TotalDiscount;
        public string CustomerName;
        public int TotalBonus;
        public List<ItemSummary> ItemSummaries { get; } = new List<ItemSummary>();

        public BillSummary(double TotalAmount, double TotalDiscount, 
            string CustomerName, int TotalBonus)
        {
            this.TotalAmount = TotalAmount;
            this.TotalDiscount = TotalDiscount;
            this.CustomerName = CustomerName;
            this.TotalBonus = TotalBonus;
        }
        public BillSummary() { }
    }
}
