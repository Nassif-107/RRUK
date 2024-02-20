using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    //Класс хранения параметров одного чека
    public class BillSummary
    {
        public decimal TotalAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public string CustomerName { get; set; }
        public int TotalBonus { get; set; }
        public List<ItemSummary> ItemSummaries { get; set; }
    }
}
