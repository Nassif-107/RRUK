using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    public class SaleGoods : Goods
    {
        // Метод для получения бонуса
        public override int GetBonus(int _quantity, double _price)
        {
            switch (_priceCode)
            {
                case Goods.REGULAR:
                    return (int)(_quantity * _price * 0.05);
                case Goods.SALE:
                    return (int)(_quantity * _price * 0.01);
            }
            return 0;
        }
        // Метод для получения скидки
        public double GetDiscount(int _quantity, double _price)
        {
            double discount = 0;
            switch (_priceCode)
            {
                case Goods.REGULAR:
                    if (_quantity > 2)
                        discount = (_quantity * _price) * 0.03; // 3%
                    break;
                case Goods.SPECIAL_OFFER:
                    if (_quantity > 10)
                        discount = (_quantity * _price) * 0.005; // 0.5%
                    break;
                case Goods.SALE:
                    if (_quantity > 3)
                        discount = (_quantity * _price) * 0.01; // 0.1%
                    break;
            }
            return discount;
        }
    }
}
