using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    public class GoodsFactory
    {
        public Goods Create(string type, string title, int strategyType)
        {
            IBonusStrategy bonusStrategy;
            IDiscountStrategy discountStrategy;
            switch (strategyType)
            {
                case 0: // default strategies
                    switch (type)
                    {
                        case "REG":
                            bonusStrategy = new RegularBonusStrategy();
                            discountStrategy = new RegularDiscountStrategy();
                            break;
                        case "SAL":
                            bonusStrategy = new SaleBonusStrategy();
                            discountStrategy = new SaleDiscountStrategy();
                            break;
                        case "SPO":
                            bonusStrategy = new SpecialBonusStrategy();
                            discountStrategy = new SpecialDiscountStrategy();
                            break;
                        default:
                            throw new ArgumentException("Неизвестный тип товара");
                    }
                    break;
                case 1: // new year strategies
                    switch (type)
                    {
                        case "REG":
                            bonusStrategy = new NewYearRegularBonusStrategy();
                            discountStrategy = new RegularDiscountStrategy(); // Предполагается, что для RegularGoods скидка остаётся такой же как в обычный период
                            break;
                        case "SAL":
                            bonusStrategy = new SaleBonusStrategy(); // Бонусы для товаров со скидкой остаются неизменными даже в новогодний период
                            discountStrategy = new NewYearSaleDiscountStrategy();
                            break;
                        case "SPO":
                            bonusStrategy = new SpecialBonusStrategy(); // Предполагается, что для SpecialGoods бонусы не изменяются
                            discountStrategy = new NewYearSpecialDiscountStrategy();
                            break;
                        default:
                            throw new ArgumentException("Неизвестный тип товара");
                    }
                    break;
                default:
                    throw new ArgumentException("Неизвестный тип стратегии");
            }
            return new Goods(title, bonusStrategy, discountStrategy);
        }
    }
}
