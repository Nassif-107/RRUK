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
            BillSummary billSummary = bill.Process();

            List<Item>.Enumerator items = _items.GetEnumerator();
            String result = view.GetHeader(_customer);
            foreach (var itemSummary in billSummary.ItemSummaries)
            {
                Item each = (Item)items.Current;
                result += view.GetItemString(
                    each,
                    itemSummary.Discount,
                    itemSummary.Sum,
                    itemSummary.Bonus);
            }
            result += view.GetFooter(billSummary.TotalAmount, billSummary.TotalBonus);
            return result;
        }

    }
}
