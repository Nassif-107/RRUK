using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    public class BillFactory
    {
        private IFileSource contentFile;
        // Параметризованный конструктор, принимающий IFileSource
        public BillFactory(IFileSource contentFile)
        {
            this.contentFile = contentFile;
        }
        // Метод для преобразования данных из файла
        public BillGenerator CreateBill(TextReader sr)
        {
            
            contentFile.SetSource(sr);
            Customer customer = contentFile.GetCustomer();

            IView view = new TxtView();
            BillGenerator b = new BillGenerator(customer, view);
            // read goods count
            int goodsQty = contentFile.GetGoodsCount();

            Goods[] g = new Goods[goodsQty];
            for (int i = 0; i < g.Length; i++)
            {
                g[i] = contentFile.GetNextGood();
            }
            // read items count
            int itemsQty = contentFile.GetItemsCount();

            for (int i = 0; i < itemsQty; i++)
            {
                b.addGoods(contentFile.GetNextItem(g));
            }
            return b;
        }
    }
}
