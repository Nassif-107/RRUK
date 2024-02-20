using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    //Класс Генерирования чека, соединяющий представление (IView) и модель (Bill)
    public class BillGenerator
    {
        private List<Item> _items;
        private Customer _customer;
        private IView view;
        public IView View
        {
            get { return view; }
            set { view = value; }
        }
        public BillGenerator(Customer customer, IView view)
        {
            this._customer = customer;
            this._items = new List<Item>();
            this.view = view;
        }
        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }
        //---Метод производящий вычисления и вывод чека в формате string
        public string GenerateBill()
        {
            Bill bill = new Bill(_customer, view);
            foreach (Item item in _items)
            {
                bill.addGoods(item);
            }
            BillSummary billSummary = bill.Process();
            List<Item>.Enumerator items = _items.GetEnumerator();
            //---Добавляем оглавления
            string headerAndItemString = view.GetHeader(_customer);
            int index = 0; // индекс продукта
            foreach (var itemSummary in billSummary.ItemSummaries)
            {
                if(index < _items.Count) // Проверка на IndexOutOfRangeException
                {
                    Item each = _items[index];
                    //Добавляем товары в чек
                    headerAndItemString += view.GetItemString(each,
                        itemSummary.Discount,
                        itemSummary.Sum,
                        itemSummary.Bonus);
                    index++;
                }
            }
            //---Добавляем нижний колонтитул
            string footer = view.GetFooter(billSummary.TotalAmount, billSummary.TotalBonus);
            return headerAndItemString + footer;
        }
    }
}
