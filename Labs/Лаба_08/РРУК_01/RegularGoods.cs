using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    public class RegularGoods : Goods
    {

        public RegularGoods(string title) : base(title)
        {
        }

        public override int GetBonus(int _quantity, double _price)
        {
            int totalAmount = (int)(_quantity * _price);
            int bonusTotalAmount = (int)(_quantity * _price * 0.05);
            return _bonusStrategy.CalculateBonus(totalAmount, bonusTotalAmount);
        }
        // Метод для получения скидки
        public override double GetDiscount(int _quantity, double _price)
        {
            int totalAmount = (int)(_quantity * _price);
            int discountTotalAmount = (int)(_quantity * _price);
            if (_quantity > 2)
            {
                discountTotalAmount = (int)(_quantity * _price * 0.03); // 3%
                return _discountStrategy.CalculateDiscount(totalAmount, discountTotalAmount);
            }
            return _discountStrategy.CalculateDiscount(totalAmount, discountTotalAmount);
        }
    }
}
