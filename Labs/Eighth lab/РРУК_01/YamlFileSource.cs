using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    //Класс отвечающий за чтение и обработку Yaml файлов
    public class YamlFileSource : IFileSource
    {
        private TextReader reader;
        private string line;
        private string[] parts;
        //---Метод отвечающий за получение источника
        public void SetSource(TextReader reader)
        {
            this.reader = reader;
        }
        //---Метод отвечающий за чтение покупателя
        public Customer GetCustomer()
        {
            // Чтение покупателя
            GetNextLine();
            parts = line.Split(':');
            string name = parts[1].Trim();
            // Чтение бонусов
            GetNextLine();
            parts = line.Split(':');
            int bonus = Convert.ToInt32(parts[1].Trim());
            return new Customer(name, bonus);
        }
        //---Метод отвечающий за чтение количества продуктов
        public int GetGoodsCount()
        {
            GetNextLine();
            parts = line.Split(':');
            return Convert.ToInt32(parts[1].Trim());
        }
        //---Метод отвечающий за чтение каждого продукта
        public Goods GetNextGood()
        {
            GoodsFactory factory = new GoodsFactory();
            GetNextLine();
            parts = line.Split(':');
            parts = parts[1].Trim().Split();
            string type = parts[1].Trim();
            return factory.Create(type, parts[0]);
        }
        //---Метод отвечающий за чтение количества товаров
        public int GetItemsCount()
        {
            GetNextLine();
            parts = line.Split(':');
            return Convert.ToInt32(parts[1].Trim());
        }
        //---Метод отвечающий за чтение каждого товара
        public Item GetNextItem(Goods[] g)
        {
            GetNextLine();
            parts = line.Split(':');
            parts = parts[1].Trim().Split();
            int gid = Convert.ToInt32(parts[0].Trim());
            decimal price = Convert.ToDecimal(parts[1].Trim());
            int qty = Convert.ToInt32(parts[2].Trim());
            return new Item(g[gid - 1], qty, price);
        }
        //---Метод отвечающий за считывание строки
        public void GetNextLine()
        {
            // Пропуск комментариев
            do
            {
                line = reader.ReadLine();
            } while (line.StartsWith("#"));
        }
    }
}
