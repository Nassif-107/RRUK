using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    public interface IFileSource
    {
        public void SetSource(TextReader reader, int strategyType);
        public Customer GetCustomer();
        public int GetGoodsCount();
        public Goods GetNextGood();
        public int GetItemsCount();
        public Item GetNextItem(Goods[] g);
        public void GetNextLine();
    }
}
