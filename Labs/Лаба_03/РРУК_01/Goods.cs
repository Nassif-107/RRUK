using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    public class Goods
    {
        public const int REGULAR = 0;
        public const int SALE = 1;
        public const int SPECIAL_OFFER = 2;
        private String _title;
        private int _priceCode;
        public Goods(String title, int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }
        public int getPriceCode()
        {
            return _priceCode;
        }
        public void setPriceCode(int arg)
        {
            _priceCode = arg;
        }
        public String getTitle()
        {
            return _title;
        }
        // Метод для получения бонуса
        public virtual int GetBonus(int _quantity,double _price) 
        {

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
