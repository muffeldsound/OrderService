using OrderService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.ReceiptProviders
{
    public class JsonReceipt : IReceipt
    {
        public string GenerateReceipt(Order order)
        {
            var totalAmount = 0d;
            var result = new StringBuilder("{" + $"\"order-receipt-for\":\"{order.Company}\",");
            if (order.OrderLines.Any())
            {
                result.Append("\"orderlines\":[");
                totalAmount = PriceCalculator.CalculateTotal(order.OrderLines,
                                                        (line, amount) => {
                                                            result.Append("{\"quantity\":");
                                                            result.Append($"\"{line.Quantity}\"");
                                                            result.Append($",\"product-type\":");
                                                            result.Append($"\"{line.Product.ProductType}\",");
                                                            result.Append("\"product\":{");
                                                            result.Append($"\"name\":\"{line.Product.ProductName}\",");
                                                            result.Append($"\"price\": \"{amount:C}\"");
                                                            result.Append("}},"); }
                                                        );

                result.Insert(result.Length-1, "]", 1);
            }
            result.Append($"\"subtotal\": \"{totalAmount:C}\",");
            var totalTax = totalAmount * Rates.Tax;
            result.Append($"\"mva\":\"{totalTax:C}\",");
            result.Append($"\"total\":\"{(totalAmount + totalTax):C}\"");
            result.Append("}");
            return result.ToString();
        }

    }
}
