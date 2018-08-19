using NUnit.Framework;

namespace OrderService.Tests
{
    [TestFixture]
    public class OrderTests
    {
        private static readonly Product MotorSuper = new Product("Car Insurance", "Super", Product.Prices.TwoThousand);
        private static readonly Product MotorKasko = new Product("Car Insurance", "Kasko", Product.Prices.OneThousand);

        [Test]
        public void can_generate_receipt_for_motor_super()
        {
            var order = new Order("Test Company");
            order.AddLine(new OrderLine(MotorSuper, 1));
            var receiptGenerator = new ReceiptGenerator(order, FileFormat.Text);

            var actual = receiptGenerator.Generate();

            var expected = 
                $"Order receipt for 'Test Company'\r\n\t1 x Car Insurance Super 1 = kr 2{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00\r\nSubtotal: kr 2{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00\r\nMVA: kr 500,00\r\nTotal: kr 2{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}500,00";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void can_generate_html_receipt_for_motor_super()
        {
            var order = new Order("Test Company");
            order.AddLine(new OrderLine(MotorSuper, 1));
            var receiptGenerator = new ReceiptGenerator(order, FileFormat.Html);

            var actual = receiptGenerator.Generate();

            var expected =
                $"<html><body><h1>Order receipt for 'Test Company'</h1><ul><li>1 x Car Insurance Super = kr 2{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00</li></ul><h3>Subtotal: kr 2{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00</h3><h3>MVA: kr 500,00</h3><h2>Total: kr 2{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}500,00</h2></body></html>";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void can_generate_receipt_for_motor_kasko()
        {
            var order = new Order("Test Company");
            order.AddLine(new OrderLine(MotorKasko, 1));
            var receiptGenerator = new ReceiptGenerator(order, FileFormat.Text);

            var actual = receiptGenerator.Generate();

            var expected = 
                $"Order receipt for 'Test Company'\r\n\t1 x Car Insurance Kasko 1 = kr 1{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00\r\nSubtotal: kr 1{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00\r\nMVA: kr 250,00\r\nTotal: kr 1{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}250,00";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void can_generate_html_receipt_for_motor_kasko()
        {
            var order = new Order("Test Company");
            order.AddLine(new OrderLine(MotorKasko, 1));
            var receiptGenerator = new ReceiptGenerator(order, FileFormat.Html);

            var actual = receiptGenerator.Generate();

            var expected =
                $"<html><body><h1>Order receipt for 'Test Company'</h1><ul><li>1 x Car Insurance Kasko = kr 1{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00</li></ul><h3>Subtotal: kr 1{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00</h3><h3>MVA: kr 250,00</h3><h2>Total: kr 1{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}250,00</h2></body></html>";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void can_generate_json_receipt_for_motor_kasko()
        {
            var order = new Order("Test Company");
            order.AddLine(new OrderLine(MotorKasko, 1));
            var receiptGenerator = new ReceiptGenerator(order, FileFormat.Json);

            var actual = receiptGenerator.Generate();

            var expected =
                "{\"order-receipt-for\":\"Test Company\",\"orderlines\":[{\"quantity\":\"1\",\"product-type\":\"Car Insurance\",\"product\":{\"name\":\"Kasko\",\"price\": \"kr 1 000,00\"}}],\"subtotal\": \"kr 1 000,00\",\"mva\":\"kr 250,00\",\"total\":\"kr 1 250,00\"}";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void can_generate_json_receipt_for_motor_super()
        {
            var order = new Order("Test Company");
            order.AddLine(new OrderLine(MotorSuper, 1));
            var receiptGenerator = new ReceiptGenerator(order, FileFormat.Json);

            var actual = receiptGenerator.Generate();

            var expected =
                "{\"order-receipt-for\":\"Test Company\",\"orderlines\":[{\"quantity\":\"1\",\"product-type\":\"Car Insurance\",\"product\":{\"name\":\"Super\",\"price\": \"kr 2 000,00\"}}],\"subtotal\": \"kr 2 000,00\",\"mva\":\"kr 500,00\",\"total\":\"kr 2 500,00\"}";
            Assert.AreEqual(expected, actual);
        }
    }
}