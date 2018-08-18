using OrderService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.RecieptProviders
{
    public class JsonReciept : IReciept
    {
        public string GenerateReceipt(Order order)
        {
            var totalAmount = 0d;
            var result = new StringBuilder("{" + $"    order-receipt-for: '{order.Company}',");
            if (order.OrderLines.Any())
            {
                result.Append("{");
                totalAmount = PriceCalculator.CalculateTotal(order,
                                                        (line, amount) => {
                                                            result.Append("quantity:");
                                                            result.Append(line.Quantity);
                                                            result.Append($",product-type: {line.Product.ProductType},");
                                                            result.Append("product:{");
                                                            result.Append($"name: {line.Product.ProductName}, price: {amount:C}");
                                                            result.Append("}"); });

                result.Append("}");
            }
            result.Append($"    subtotal: {totalAmount:C},");
            var totalTax = totalAmount * Product.Prices.TaxRate;
            result.Append($"    mva: {totalTax:C},");
            result.Append($"    total: {(totalAmount + totalTax):C}");
            result.Append("}");
            return result.ToString();
        }

    }
}
