using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    public interface IDiscountStrategy
    {
        double CalculateDiscount(int totalAmount, int discountTotalAmount);
    }
    public class DefaultDiscountStrategy : IDiscountStrategy
    {
        // No discount
        public double CalculateDiscount(int totalAmount, int discountTotalAmount)
        {
            return discountTotalAmount;
        }
    }
    public class FirstDiscountStrategy : IDiscountStrategy
    {
        // 3% discount for more than 2000 units
        public double CalculateDiscount(int totalAmount, int discountTotalAmount)
        {
            double discount = totalAmount * 0.03;
            return discount + discountTotalAmount;
        }
    }
    public class SecondDiscountStrategy : IDiscountStrategy
    {
        // 5% discount for more than 3000 units
        public double CalculateDiscount(int totalAmount, int discountTotalAmount)
        {
            double discount = totalAmount * 0.05;
            return discount + discountTotalAmount;
        }
    }
}
