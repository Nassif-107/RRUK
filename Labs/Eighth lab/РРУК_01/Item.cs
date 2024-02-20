using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    // Класс, представляющий данные о чеке
    public class Item
    {
        private Goods _Goods;
        private int _quantity;
        private decimal _price;
        public Item(Goods Goods, int quantity, decimal price)
        {
            _Goods = Goods;
            _quantity = quantity;
            _price = price;
        }
        public int getQuantity()
        {
            return _quantity;
        }
        public decimal getPrice()
        {
            return _price;
        }
        public Goods getGoods()
        {
            return _Goods;
        }
        //---Метод для сокрытия делегирования GetBonus()
        public int GetBonus()
        {
            return _Goods.GetBonus(_quantity, _price);
        }
        //---Метод для сокрытия делегирования GetDiscount()
        public decimal GetDiscount()
        {
            return _Goods.GetDiscount(_quantity, _price);
        }
    }
}
