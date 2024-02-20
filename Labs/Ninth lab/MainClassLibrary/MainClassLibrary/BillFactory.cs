using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace РРУК_01
{
    // Класс генерации чеков
    public class BillFactory
    {
        private IFileSource readContent;
        public BillFactory(IFileSource readContent)
        {
            this.readContent = readContent;
        }
        //---Метод для преобразования данных из файла
        public BillGenerator CreateBill(TextReader sr, string config = "RegularSettings.json", IView view = null)
        {
            if (view == null)
            {
                view = new TxtView();
            }
            int strategyType;
            var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, config);
            if (!File.Exists(configPath))
            {
                throw new FileNotFoundException("Конфигурационный файл не найден.", configPath);
            }
            string configJson = File.ReadAllText(configPath);
            var settings = JsonSerializer.Deserialize<ConfigSettings>(configJson);
            if(settings.Season== "NewYears")
            {
                strategyType = 1;
            }
            else
            {
                strategyType = 0;
            }
            readContent.SetSource(sr, strategyType);
            // Чтение покупателя
            Customer customer = readContent.GetCustomer();
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
    //Класс для расспознования конфигураций
    public class ConfigSettings
    {
        public string Season { get; set; }
    }
}
