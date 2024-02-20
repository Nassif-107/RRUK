using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    //Класс хранения параметров одного продукта
    public class ItemSummary
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Quantity { get; set; }
        public decimal Sum { get; set; }
        public decimal Discount { get; set; }
        public int Bonus { get; set; }
    }
}
