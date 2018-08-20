using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService
{
    public class PriceCalculator
    {
        public static double CalculateTotal(Order order, Action<OrderLine, double> productPriceCalculatedCallback)
        {
            double totalAmount = 0d;
            foreach (var line in order.OrderLines)
            {
                var thisAmount = 0d;
                switch (line.Product.Price)
                {
                    case Product.Prices.OneThousand:
                        thisAmount += ((double)line.Product.Price).VolumeDiscount(line, 5, Percentage.Ten);
                        break;
                    case Product.Prices.TwoThousand:
                        thisAmount += ((double)line.Product.Price).VolumeDiscount(line, 3, Percentage.Twenty);
                        break;
                }
                productPriceCalculatedCallback(line, thisAmount);
                totalAmount += thisAmount;
            }
            return totalAmount;
        }

        private static double CalculateProductPrice(OrderLine line, int quantityLimit, double percentage )
        {
            return line.Quantity 
                * line.Product.Price 
                * (
                    (line.Quantity >= quantityLimit)
                    ? percentage 
                    : 1
                   );
        }
    }
}