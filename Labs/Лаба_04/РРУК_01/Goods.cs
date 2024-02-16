using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    public class Goods
    {
        protected String _title;
        protected int _priceCode;
        public Goods(String title)
        {
            _title = title;
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
            return 0;
        }
        // Метод для получения скидки
        public virtual double GetDiscount(int _quantity, double _price)
        {
            return 0;
        }
    }
}
