using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    //Класс отвечающий за чтение и обработку Html файлов
    public class HtmlFileSource : IFileSource
    {
        private TextReader reader;
        private string line;
        private int strategyType;
        //---Метод отвечающий за получение источника
        public void SetSource(TextReader reader,int strategyType)
        {
            this.reader = reader;
            this.strategyType = strategyType;
        }
        //---Метод отвечающий за чтение покупателя
        public Customer GetCustomer()
        {
            string name = ExtractValue("customerName");
            int bonus = Convert.ToInt32(ExtractValue("customerBonus"));
            return new Customer(name, bonus);
        }
        //---Метод отвечающий за чтение количества продуктов
        public int GetGoodsCount()
        {
            return Convert.ToInt32(ExtractValue("goodsCount"));
        }
        //---Метод отвечающий за чтение каждого продукта
        public Goods GetNextGood()
        {
            GoodsFactory factory = new GoodsFactory();
            string type = ExtractValue("goodType");
            string name = ExtractValue("goodName");
            return factory.Create(type, name, strategyType);
        }
        //---Метод отвечающий за чтение количества товаров
        public int GetItemsCount()
        {
            return Convert.ToInt32(ExtractValue("itemsCount"));
        }
        //---Метод отвечающий за чтение каждого товара
        public Item GetNextItem(Goods[] g)
        {
            int gid = Convert.ToInt32(ExtractValue("itemId"));
            decimal price = Convert.ToDecimal(ExtractValue("itemPrice"));
            int qty = Convert.ToInt32(ExtractValue("itemQty"));
            return new Item(g[gid - 1], qty, price);
        }
        //---Метод поиска строки с первым и последним тегами, чтобы получить внутренний текст
        private string ExtractValue(string tagName)
        {
            string startTag = $"<{tagName}>";
            string endTag = $"</{tagName}>";
            string value = "";
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains(startTag))
                {
                    int startIndex = line.IndexOf(startTag) + startTag.Length;
                    int endIndex = line.IndexOf(endTag);
                    value = line.Substring(startIndex, endIndex - startIndex).Trim();
                    break;
                }
            }
            return value;
        }
        public void GetNextLine()
        {
            // Этот метод не используется в текущей реализации, но должен быть определен
        }
    }
}
