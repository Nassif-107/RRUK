using System.Text;

namespace РРУК_01
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filename = "BillInfo.yaml";
            if (args.Length == 1)
                filename = args[0];
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                BillFactory factory = new BillFactory();
                BillGenerator bill = factory.CreateBill(sr);
                string billOutput = bill.GetBIll();
                Console.WriteLine(billOutput);
            }
        }
    }
}