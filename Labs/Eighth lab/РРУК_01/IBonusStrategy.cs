using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    //---Интерфейс стратегии для бонуса
    public interface IBonusStrategy
    {
        int CalculateBonus(int quantity, decimal price);
    }
    // Реализация стратегии для обычных товаров
    public class RegularBonusStrategy : IBonusStrategy
    {
        public int CalculateBonus(int quantity, decimal price)
        {
            return (int)(quantity * price * 0.05m);// 5% от суммы покупки

        }
    }
    // Реализация стратегии для товаров со скидкой
    public class SaleBonusStrategy : IBonusStrategy
    {
        public int CalculateBonus(int quantity, decimal price)
        {
            return (int)(quantity * price * 0.01m); // 1% от суммы покупки
        }
    }
    // Реализация стратегии для специальных товаров
    public class SpecialBonusStrategy : IBonusStrategy
    {
        public int CalculateBonus(int quantity, decimal price)
        {
            // Нет бонусов для специальных товаров
            return 0;
        }
    }
    // Реализация стратегии для новогоднего периода обычных товаров
    public class NewYearRegularBonusStrategy : IBonusStrategy
    {
        public int CalculateBonus(int quantity, decimal price)
        {
            // 7% от суммы покупки при покупке от 5000 руб.
            var total = quantity * price;
            if (total >= 5000)
                return (int)(total * 0.07m);
            else if (quantity > 2)
                return (int)(quantity * price * 0.05m); // 5% от суммы покупки в обычном случае
            return 0;
        }
    }
}
