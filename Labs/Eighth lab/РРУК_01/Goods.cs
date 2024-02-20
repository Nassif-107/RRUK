using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    public class Goods
    {
        protected string title;
        protected int priceCode;
        protected IBonusStrategy bonusStrategy;
        protected IDiscountStrategy discountStrategy;
        public Goods(string title, IBonusStrategy bonusStrategy, IDiscountStrategy discountStrategy)
        {
            this.title = title;
            this.bonusStrategy = bonusStrategy;
            this.discountStrategy = discountStrategy;
        }
        public string getTitle()
        {
            return title;
        }
        //---Метод для получения бонусов
        public virtual int GetBonus(int quantity, decimal price)
        {
            return bonusStrategy.CalculateBonus(quantity, price);
        }
        //---Метод для получения скидки
        public virtual decimal GetDiscount(int quantity, decimal price)
        {
            return discountStrategy.CalculateDiscount(quantity, price);
        }
    }
}
