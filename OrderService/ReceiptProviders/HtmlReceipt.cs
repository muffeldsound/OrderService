using OrderService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.ReceiptProviders
{
    public class HtmlReceipt : IReceipt
    {
        public string GenerateReceipt(Order order)
        {
            var totalAmount = 0d;
            var result = new StringBuilder($"<html><body><h1>Order receipt for '{order.Company}'</h1>");
            if (order.OrderLines.Any())
            {
                result.Append("<ul>");
                totalAmount = PriceCalculator.CalculateTotal(order,
                                                                (line, amount) => result.Append(
                                                                $"<li>{line.Quantity} x {line.Product.ProductType} {line.Product.ProductName} = {amount:C}</li>"));
                result.Append("</ul>");
            }
            result.Append($"<h3>Subtotal: {totalAmount:C}</h3>");
            var totalTax = totalAmount * Product.Prices.TaxRate;
            result.Append($"<h3>MVA: {totalTax:C}</h3>");
            result.Append($"<h2>Total: {(totalAmount + totalTax):C}</h2>");
            result.Append("</body></html>");
            return result.ToString();
        }
    }
}
