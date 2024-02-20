using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    public class BillFactory
    {
        private IFileSource readContent;
        public BillFactory(IFileSource readContent)
        {
            this.readContent = readContent;
        }
        //---Метод для преобразования данных из файла
        public BillGenerator CreateBill(TextReader sr)
        {
            readContent.SetSource(sr);
            // Чтение покупателя
            Customer customer = readContent.GetCustomer();
            IView view = new TxtView();
            BillGenerator b = new BillGenerator(customer, view);
            //Чтение количества продуктов
            int goodsQty = readContent.GetGoodsCount();
            Goods[] g = new Goods[goodsQty];
            //Чтение каждого продукта
            for (int i = 0; i < g.Length; i++)
            {
                g[i] = readContent.GetNextGood();
            }
            //Чтение количества товаров
            int itemsQty = readContent.GetItemsCount();
            //Чтение каждого товара
            for (int i = 0; i < itemsQty; i++)
            {
                b.addGoods(readContent.GetNextItem(g));
            }
            return b;
        }
    }
}
