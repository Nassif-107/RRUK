using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    // interface for discount strategy
    public interface IDiscountStrategy
    {
        double CalculateDiscount(int quantity, double price);
    }
    // discount strategy for regular goods
    public class RegularDiscountStrategy : IDiscountStrategy
    {
        public double CalculateDiscount(int quantity, double price)
        {
            if (quantity > 2)
                return (quantity * price) * 0.03; // 3%
            return 0;
        }
    }
    // discount strategy for sale goods
    public class SaleDiscountStrategy : IDiscountStrategy
    {
        public double CalculateDiscount(int quantity, double price)
        {
            if (quantity > 3)
                return (quantity * price) * 0.01; // 0.1%
            return 0;
        }
    }
    // discount strategy for regular goods
    public class SpecialDiscountStrategy : IDiscountStrategy
    {
        public double CalculateDiscount(int quantity, double price)
        {
            if (quantity > 10)
                return (quantity * price) * 0.005; // 0.5% скидка
            return 0;
        }
    }
    // discount strategy for new year sale goods
    public class NewYearSaleDiscountStrategy : IDiscountStrategy
    {
        public double CalculateDiscount(int quantity, double price)
        {
            var total = quantity * price;
            if (total > 2000)
                return total * 0.03; // 3%
            if (quantity > 3)
                return (quantity * price) * 0.01; // 0.1%
            return 0;
        }
    }
    // discount strategy for new year special goods
    public class NewYearSpecialDiscountStrategy : IDiscountStrategy
    {
        public double CalculateDiscount(int quantity, double price)
        {
            var total = quantity * price;
            if (total > 3000)
                return total * 0.05; // 5%
            return 0;
        }
    }

}
