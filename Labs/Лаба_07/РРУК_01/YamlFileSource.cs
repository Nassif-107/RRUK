using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    public class YamlFileSource : IFileSource
    {
        private TextReader reader;
        string line;
        string[] result;
        // get source
        public void SetSource(TextReader reader)
        {
            this.reader = reader;
        }
        // read customer info
        public Customer GetCustomer()
        {
            // read customer
            GetNextLine();
            result = line.Split(':');
            string name = result[1].Trim();

            // read bonus
            GetNextLine();
            result = line.Split(':');
            int bonus = Convert.ToInt32(result[1].Trim());

            return new Customer(name, bonus);
        }
        // returns goods count
        public int GetGoodsCount()
        {
            GetNextLine();
            result = line.Split(':');
            return Convert.ToInt32(result[1].Trim());
        }
        // reads each product
        public Goods GetNextGood()
        {
            GoodsFactory factory = new GoodsFactory();
            GetNextLine();
            result = line.Split(':');
            result = result[1].Trim().Split();
            string type = result[1].Trim();
            return factory.Create(type, result[0]);
        }
        // reads the amount of products
        public int GetItemsCount()
        {
            GetNextLine();
            result = line.Split(':');
            return Convert.ToInt32(result[1].Trim());
        }
        // reads each item
        public Item GetNextItem(Goods[] g)
        {
            GetNextLine();
            result = line.Split(':');
            result = result[1].Trim().Split();
            int gid = Convert.ToInt32(result[0].Trim());
            double price = Convert.ToDouble(result[1].Trim());
            int qty = Convert.ToInt32(result[2].Trim());
            return new Item(g[gid - 1], qty, price);
        }
        // skip comments
        public void GetNextLine()
        {
            do
            {
                line = reader.ReadLine();
            }
            while (line.StartsWith('#'));
        }
    }
}
