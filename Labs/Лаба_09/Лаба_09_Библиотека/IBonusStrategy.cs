using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    // interface for bonus strategy
    public interface IBonusStrategy
    {
        int CalculateBonus(int quantity, double price);
    }
    // bonus strategy for regular goods
    public class RegularBonusStrategy : IBonusStrategy
    {
        public int CalculateBonus(int quantity, double price)
        {
            return (int)(quantity * price * 0.05);// 5%
        }
    }
    // bonus strategy for sale goods
    public class SaleBonusStrategy : IBonusStrategy
    {
        public int CalculateBonus(int quantity, double price)
        {
            return (int)(quantity * price * 0.01); // 1%
        }
    }
    // bonus strategy for special goods
    public class SpecialBonusStrategy : IBonusStrategy
    {
        public int CalculateBonus(int quantity, double price)
        {
            return 0;
        }
    }
    // bonus strategy for new year regular goods
    public class NewYearRegularBonusStrategy : IBonusStrategy
    {
        public int CalculateBonus(int quantity, double price)
        {
            var total = quantity * price;
            if (total >= 5000)
                return (int)(total * 0.07); // 7%
            if (quantity > 2)
                return (int)(quantity * price * 0.05); // 5% 
            return 0;
        }
    }

}
