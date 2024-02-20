using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    //---Интерфейс стратегии для расчета скидок
    public interface IDiscountStrategy
    {
        decimal CalculateDiscount(int quantity, decimal price);
    }

    // Реализация стратегии для обычных товаров
    public class RegularDiscountStrategy : IDiscountStrategy
    {
        public decimal CalculateDiscount(int quantity, decimal price)
        {
            if (quantity > 2)
                return (quantity * price) * 0.03m; // 3% скидка
            return 0;
        }
    }

    // Реализация стратегии для товаров со скидкой
    public class SaleDiscountStrategy : IDiscountStrategy
    {
        public decimal CalculateDiscount(int quantity, decimal price)
        {
            if (quantity > 3)
                return (quantity * price) * 0.01m; // 0.1% скидка
            return 0;
        }
    }

    // Реализация стратегии для специальных товаров
    public class SpecialDiscountStrategy : IDiscountStrategy
    {
        public decimal CalculateDiscount(int quantity, decimal price)
        {
            if (quantity > 10)
                return (quantity * price) * 0.005m; // 0.5% скидка
            return 0;
        }
    }
    // Реализация стратегии для новогоднего периода для товаров со скидкой
    public class NewYearSaleDiscountStrategy : IDiscountStrategy
    {
        public decimal CalculateDiscount(int quantity, decimal price)
        {
            var total = quantity * price;
            if (total > 2000)
                return total * 0.03m; // 3% скидка при покупке на сумму свыше 2000 руб.
            else if (quantity > 3)
                return (quantity * price) * 0.01m; // 0.1% скидка
            return 0;
        }
    }
    // Реализация стратегии для новогоднего периода для акционных товаров
    public class NewYearSpecialDiscountStrategy : IDiscountStrategy
    {
        public decimal CalculateDiscount(int quantity, decimal price)
        {
            var total = quantity * price;
            if (total > 3000)
                return total * 0.05m; // 5% скидка при покупке на сумму свыше 3000 руб.
            return 0;
        }
    }
}
