using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    //Класс специального продукат
    public class SpecialGoods : Goods 
    {
        public SpecialGoods(string title) : base(title)
        {
        }
        //---Метод для получения бонусов
        public override int GetBonus(int _quantity, decimal _price)
        {
            return 0;
        }
        //---Метод для получения скидки
        public override decimal GetDiscount(int _quantity, decimal _price)
        {
            if (_quantity > 10)
                return (_quantity * _price) * 0.005m; // 0.5%
            return 0;
        }
    }
}
