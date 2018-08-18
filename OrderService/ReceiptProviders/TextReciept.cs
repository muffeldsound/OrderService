using OrderService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.ReceiptProviders
{
    public class TextReceipt : IReceipt
    {
        public string GenerateReceipt(Order order)
        {
            var result = new StringBuilder($"Order receipt for '{order.Company}'{Environment.NewLine}");
            var totalAmount = PriceCalculator.CalculateTotal(order, 
                        (line, amount) => result.AppendLine(
                        $"\t{line.Quantity} x {line.Product.ProductType} {line.Product.ProductName} {line.Quantity} = {amount:C}"));
            result.AppendLine($"Subtotal: {totalAmount:C}");
            var totalTax = totalAmount * Product.Prices.TaxRate;
            result.AppendLine($"MVA: {totalTax:C}");
            result.Append($"Total: {(totalAmount + totalTax):C}");
            return result.ToString();
        }       
    }
}
