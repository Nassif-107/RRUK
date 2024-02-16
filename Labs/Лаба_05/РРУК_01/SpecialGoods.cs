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
            return 0;
        }
        // Метод для получения скидки
        public override double GetDiscount(int _quantity, double _price)
        {
            if (_quantity > 10)
                return (_quantity * _price) * 0.005; // 0.5%
            return 0;
        }

    }
}
