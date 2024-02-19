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
        protected IBonusStrategy _bonusStrategy;
        protected IDiscountStrategy _discountStrategy;
        public Goods(String title)
        {
            _title = title;
        }
        public void SetStrategy(int totalAmount)
        {
            // automatically chooses the needed strategy for discount
            if (totalAmount >= 2000 && totalAmount < 3000)
            {
                this._discountStrategy = new FirstDiscountStrategy();
            }
            else if (totalAmount >= 3000)
            {
                this._discountStrategy = new SecondDiscountStrategy();
            }
            else this._discountStrategy = new DefaultDiscountStrategy();

            // automatically chooses the needed strategy for bonus
            if (totalAmount >= 5000)
            {
                this._bonusStrategy = new FirstBonusStrategy();
            }
            else this._bonusStrategy = new DefaultBonusStrategy();
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
