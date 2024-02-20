using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    //Класс отвечающий за определения типа файла
    public class GoodsFactory
    {
        public Goods Create(string type, string title)
        {
            switch (type)
            {
                case "REG":
                    return new RegularGoods(title);
                case "SAL":
                    return new SaleGoods(title);
                case "SPO":
                    return new SpecialGoods(title);
                default:
                    throw new ArgumentException("Неизвестный тип товара");
            }
        }
    }
}
