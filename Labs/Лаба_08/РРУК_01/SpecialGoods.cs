using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    public class SpecialGoods : Goods
    {
        public SpecialGoods(string title) : base(title)
        {
        }

        public override int GetBonus(int _quantity, double _price)
        {
            int totalAmount = (int)(_quantity * _price);
            int bonusTotalAmount = (int)(_quantity * _price);
            return _bonusStrategy.CalculateBonus(totalAmount, bonusTotalAmount);
        }
        // Метод для получения скидки
        public override double GetDiscount(int _quantity, double _price)
        {
            int totalAmount = (int)(_quantity * _price);
            int discountTotalAmount = (int)(_quantity * _price);
            if (_quantity > 10)
            {
                discountTotalAmount = (int)(_quantity * _price * 0.005);
                return _discountStrategy.CalculateDiscount(totalAmount, discountTotalAmount);
            }
            return _discountStrategy.CalculateDiscount(totalAmount, discountTotalAmount);
        }
    }
}
