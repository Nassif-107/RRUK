using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    public interface IBonusStrategy
    {
        int CalculateBonus(int totalAmount, int bonusTotalAmount);
    }
    public class DefaultBonusStrategy : IBonusStrategy
    {
        // without bonus
        public int CalculateBonus(int totalAmount, int bonusTotalAmount)
        {
            return bonusTotalAmount;
        }
    }
    public class FirstBonusStrategy : IBonusStrategy
    {
        // with bonus
        public int CalculateBonus(int totalAmount, int bonusTotalAmount)
        {
            double bonus = totalAmount * 0.07;
            return (int)(bonus + bonusTotalAmount);
        }
    }
}
