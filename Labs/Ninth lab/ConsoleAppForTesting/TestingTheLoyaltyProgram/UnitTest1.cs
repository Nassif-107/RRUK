using ����_01;
namespace TestingTheLoyaltyProgram
{
    public class Tests
    {
        private string nameHtmlSource = "BillInfo.html";
        private string nameYamlSource = "BillInfo.yaml";
        private IFileSource fileSourceHtml;
        private IFileSource fileSourceYaml;
        private BillFactory billFactoryHtml;
        private BillFactory billFactoryYaml;
        [SetUp]
        public void Setup()
        {
                    
        IView view = new TxtView();
            fileSourceHtml = FileSourceFactory.CreateFileSource(nameHtmlSource);
            billFactoryHtml = new BillFactory(fileSourceHtml);
            fileSourceYaml = FileSourceFactory.CreateFileSource(nameYamlSource);
            billFactoryYaml = new BillFactory(fileSourceYaml);
        }

        [Test]
        public void NewYearDiscountAndBonusForRegularGoods()
        {
            // �����������, ��� ���� �������������� ������ ����������� ������ ���������
            string testData = "CustomerName: Test\r\n" +
                              "CustomerBonus: 10\r\n" +
                              "GoodsTotalCount: 1\r\n" +
                              "# ID: NAME TYPE(REG/SAL/SPO)\r\n" +
                              "1: Milk REG\r\n" +
                              "ItemsTotalCount: 1\r\n" +
                              "# ID: GID PRICE QTY\r\n" +
                              "1: 1 5000 1"; // ������� �� 5000 ������
            using (StringReader sr = new StringReader(testData))
            {
                BillGenerator billGenerator = billFactoryYaml.CreateBill(sr, "NewYearsSettings.json");
                var result = billGenerator.GenerateBill();
                // �������, ��� ������ �� �����������, �� ������ ����������� 7% �� 5000
                Assert.IsTrue(result.Contains("����� ����� ���������� 5000"));
                Assert.IsTrue(result.Contains("�� ���������� 350 �������� �����"));
            }
        }
        [Test]
        public void UsualDiscountAndBonusForRegularGoods()
        {
            // �����������, ��� ���� �������������� ������ ����������� ������ ���������
            string testData = "CustomerName: Test\r\n" +
                              "CustomerBonus: 10\r\n" +
                              "GoodsTotalCount: 1\r\n" +
                              "# ID: NAME TYPE(REG/SAL/SPO)\r\n" +
                              "1: Razor_blades REG\r\n" +
                              "ItemsTotalCount: 1\r\n" +
                              "# ID: GID PRICE QTY\r\n" +
                              "1: 1 5000 1"; // ������� �� 5000 ������
            using (StringReader sr = new StringReader(testData))
            {
                BillGenerator billGenerator = billFactoryYaml.CreateBill(sr, "RegularSettings.json");
                var result = billGenerator.GenerateBill();
                // �������, ��� ������ �� �����������, �� ������ ����������� 5% �� 5000
                Assert.IsTrue(result.Contains("����� ����� ���������� 5000"));
                Assert.IsTrue(result.Contains("�� ���������� 250 �������� �����"));
            }
        }
        [Test]
        public void NewYearDiscountForSaleGoods()
        {
            string testData = "CustomerName: Test\r\n" +
                              "CustomerBonus: 10\r\n" +
                              "GoodsTotalCount: 1\r\n" +
                              "# ID: NAME TYPE(REG/SAL/SPO)\r\n" +
                              "1: Christmas_Tree SAL\r\n" +
                              "ItemsTotalCount: 1\r\n" +
                              "# ID: GID PRICE QTY\r\n" +
                              "1: 1 2000 2"; // ������� �� 4000 ������
            using (StringReader sr = new StringReader(testData))
            {
                BillGenerator billGenerator = billFactoryYaml.CreateBill(sr, "NewYearsSettings.json");
                var result = billGenerator.GenerateBill();
                // ������� ������ 3% �� ������ �� ������� ��� ������� ����� ��� �� 2000 ���.
                Assert.IsTrue(result.Contains("����� ����� ���������� 3880,00")); // 4000 - 3% ������
                Assert.IsTrue(result.Contains("�� ���������� 40 �������� �����")); // 1% �� 4000
            }
        }
        [Test]
        public void NewYearDiscountForSpecialGoods()
        {
            string testData = "CustomerName: Test\r\n" +
                              "CustomerBonus: 10\r\n" +
                              "GoodsTotalCount: 1\r\n" +
                              "# ID: NAME TYPE(REG/SAL/SPO)\r\n" +
                              "1: New_Year_Candy SPO\r\n" +
                              "ItemsTotalCount: 1\r\n" +
                              "# ID: GID PRICE QTY\r\n" +
                              "1: 1 300 11"; // ������� �� 3300 ������
            using (StringReader sr = new StringReader(testData))
            {
                BillGenerator billGenerator = billFactoryYaml.CreateBill(sr, "NewYearsSettings.json");
                var result = billGenerator.GenerateBill();
                // ������� ������ 5% �� ��������� ������ ��� ������� ����� ��� �� 3000 ���.
                Assert.IsTrue(result.Contains("����� ����� ���������� 3125,00")); // 3300 - 5% ������
                Assert.IsTrue(result.Contains("�� ���������� 0 �������� �����")); // ��� ������� ��� ��������� �������
            }
        }
        [Test]
        public void Html_NewYearDiscountForThreeGoods()
        {
            string testData = "<html>\r\n<body>\r\n    " +
                "<customerName>Test</customerName>\r\n    " +
                "<customerBonus>10</customerBonus>\r\n    " +
                "<goodsCount>3</goodsCount>\r\n    " +
                "<good>\r\n        " +
                "<goodType>REG</goodType>\r\n        " +
                "<goodName>Cola</goodName>\r\n    " +
                "<goodType>SAL</goodType>\r\n        " +
                "<goodName>Pepsi</goodName>\r\n    " +
                "<goodType>SPO</goodType>\r\n        " +
                "<goodName>Fanta</goodName>\r\n    " +
                "</good>\r\n    " +
                "<itemsCount>3</itemsCount>\r\n    " +
                "<item>\r\n        " +
                "<itemId>1</itemId>\r\n        " +
                "<itemPrice>90</itemPrice>\r\n        " +
                "<itemQty>60</itemQty>\r\n" +
                "<itemId>2</itemId>\r\n        " +
                "<itemPrice>50</itemPrice>\r\n        " +
                "<itemQty>44</itemQty>\r\n\r\n        " +
                "<itemId>3</itemId>\r\n        " +
                "<itemPrice>76</itemPrice>\r\n        " +
                "<itemQty>40</itemQty>\r\n    " +
                "</item>\r\n" +
                "</body>\r\n" +
                "</html>\r\n"; // ������� �� 3300 ������
            using (StringReader sr = new StringReader(testData))
            {
                BillGenerator billGenerator = billFactoryHtml.CreateBill(sr, "NewYearsSettings.json");
                var result = billGenerator.GenerateBill();
                // ������� ������ 5% �� ��������� ������ ��� ������� ����� ��� �� 3000 ���.
                Assert.IsTrue(result.Contains("����� ����� ���������� 10250,00")); // 3300 - 5% ������
                Assert.IsTrue(result.Contains("�� ���������� 400 �������� �����")); // ��� ������� ��� ��������� �������
            }
        }
        [Test]
        public void Html_RegularDiscountForThreeGoods()
        {
            string testData = "<html>\r\n<body>\r\n    " +
                "<customerName>Test</customerName>\r\n    " +
                "<customerBonus>10</customerBonus>\r\n    " +
                "<goodsCount>3</goodsCount>\r\n    " +
                "<good>\r\n        " +
                "<goodType>REG</goodType>\r\n        " +
                "<goodName>Cola</goodName>\r\n    " +
                "<goodType>SAL</goodType>\r\n        " +
                "<goodName>Pepsi</goodName>\r\n    " +
                "<goodType>SPO</goodType>\r\n        " +
                "<goodName>Fanta</goodName>\r\n    " +
                "</good>\r\n    " +
                "<itemsCount>3</itemsCount>\r\n    " +
                "<item>\r\n        " +
                "<itemId>1</itemId>\r\n        " +
                "<itemPrice>90</itemPrice>\r\n        " +
                "<itemQty>60</itemQty>\r\n" +
                "<itemId>2</itemId>\r\n        " +
                "<itemPrice>50</itemPrice>\r\n        " +
                "<itemQty>44</itemQty>\r\n\r\n        " +
                "<itemId>3</itemId>\r\n        " +
                "<itemPrice>76</itemPrice>\r\n        " +
                "<itemQty>40</itemQty>\r\n    " +
                "</item>\r\n" +
                "</body>\r\n" +
                "</html>\r\n"; // ������� �� 3300 ������
            using (StringReader sr = new StringReader(testData))
            {
                BillGenerator billGenerator = billFactoryHtml.CreateBill(sr, "RegularSettings.json");
                var result = billGenerator.GenerateBill();
                // ������� ������ 5% �� ��������� ������ ��� ������� ����� ��� �� 3000 ���.
                Assert.IsTrue(result.Contains("����� ����� ���������� 10430,800")); // 3300 - 5% ������
                Assert.IsTrue(result.Contains("�� ���������� 292 �������� �����")); // ��� ������� ��� ��������� �������
            }
        }
    }
}