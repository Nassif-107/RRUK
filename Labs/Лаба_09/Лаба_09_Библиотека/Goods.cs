using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    public class Goods
    {
        protected String title;
        protected int _priceCode;
        public IBonusStrategy bonusStrategy;
        protected IDiscountStrategy discountStrategy;
        public Goods(string title, 
            IBonusStrategy bonusStrategy, 
            IDiscountStrategy discountStrategy)
        {
            this.title = title;
            this.bonusStrategy = bonusStrategy;
            this.discountStrategy = discountStrategy;
        }
        public String getTitle()
        {
            return title;
        }
        // method to get bonus
        public virtual int GetBonus(int quantity, double price)
        {
            return bonusStrategy.CalculateBonus(quantity, price);
        }
        // method to get discount
        public virtual double GetDiscount(int quantity, double price)
        {
            return discountStrategy.CalculateDiscount(quantity, price);
        }
    }
}
