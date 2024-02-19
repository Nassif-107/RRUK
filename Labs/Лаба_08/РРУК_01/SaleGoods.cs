using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    public class SaleGoods : Goods
    {
        public SaleGoods(string title) : base(title)
        {
        }

        // Метод для получения бонуса
        public override int GetBonus(int _quantity, double _price)
        {
            int totalAmount = (int)(_quantity * _price);
            int bonusTotalAmount = (int)(_quantity * _price * 0.01);
            return _bonusStrategy.CalculateBonus(totalAmount, bonusTotalAmount);
        }
        // Метод для получения скидки
        public override double GetDiscount(int _quantity, double _price)
        {
            int totalAmount = (int)(_quantity * _price);
            int discountTotalAmount = (int)(_quantity * _price);
            if (_quantity > 3)
            {
                discountTotalAmount = (int)(_quantity * _price * 0.01); // 0.1%
                return _discountStrategy.CalculateDiscount(totalAmount, discountTotalAmount);
            }
            return _discountStrategy.CalculateDiscount(totalAmount, discountTotalAmount);
        }
    }
}
