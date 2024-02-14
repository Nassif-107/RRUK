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
            return (int)(_quantity * _price * 0.05);
        }
        // Метод для получения скидки
        public override double GetDiscount(int _quantity, double _price)
        {
            if (_quantity > 2)
                return (_quantity * _price) * 0.03; // 3%
            return 0;
        }
    }
}
