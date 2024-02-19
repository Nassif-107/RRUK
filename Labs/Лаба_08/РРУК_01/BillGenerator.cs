using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
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
        public String GetBIll()
        {
            Bill bill = new Bill(_customer, view);
            foreach (Item item in _items)
            {
                bill.addGoods(item);
            }
            BillSummary billSummary = bill.Process();

            List<Item>.Enumerator items = _items.GetEnumerator();
            String result = view.GetHeader(_customer);
            int index = 0; // Initialize an index for parallel access
            foreach (var itemSummary in billSummary.ItemSummaries)
            {
                if (index < _items.Count) // Check to avoid IndexOutOfRangeException
                {
                    Item each = _items[index]; // Access the corresponding Item
                    result += view.GetItemString(
                        each, // Pass the Item object
                        itemSummary.Discount,
                        itemSummary.Sum,
                        itemSummary.Bonus);
                    index++; // Move to the next item
                }
            }
            result += view.GetFooter(billSummary.TotalAmount, billSummary.TotalBonus);
            return result;
        }

    }
}
