using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    public class HtmlFileSource : IFileSource
    {
        private TextReader reader;
        private string line;
        private int strategyType;
        // выбор типа файла
        public void SetSource(TextReader reader, int strategyType)
        {
            this.reader = reader;
            this.strategyType = strategyType;
        }
        // read customer info
        public Customer GetCustomer()
        {
            string name = ExtractValue("customerName");
            int bonus = Convert.ToInt32(ExtractValue("customerBonus"));
            return new Customer(name, bonus);
        }
        // get goods count
        public int GetGoodsCount()
        {
            return Convert.ToInt32(ExtractValue("goodsCount"));
        }
        // next product
        public Goods GetNextGood()
        {
            GoodsFactory factory = new GoodsFactory();
            string type = ExtractValue("goodType");
            string name = ExtractValue("goodName");
            return factory.Create(type, name, strategyType);
        }
        // get items amount
        public int GetItemsCount()
        {
            return Convert.ToInt32(ExtractValue("itemsCount"));
        }
        // get next item
        public Item GetNextItem(Goods[] g)
        {
            int gid = Convert.ToInt32(ExtractValue("itemId"));
            double price = Convert.ToDouble(ExtractValue("itemPrice"));
            int qty = Convert.ToInt32(ExtractValue("itemQty"));
            return new Item(g[gid - 1], qty, price);
        }
        // searches for lines with given first and last tags to get the text in between
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
