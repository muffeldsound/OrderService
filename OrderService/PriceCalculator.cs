using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService
{
    public class PriceCalculator
    {
        public static double CalculateTotal(Order order, Action<OrderLine, double> lineFunction)
        {
            double totalAmount = 0d;
            foreach (var line in order.OrderLines)
            {
                var thisAmount = 0d;
                switch (line.Product.Price)
                {
                    case Product.Prices.OneThousand:
                        if (line.Quantity >= 5)
                            thisAmount += line.Quantity * line.Product.Price * .9d;
                        else
                            thisAmount += line.Quantity * line.Product.Price;
                        break;
                    case Product.Prices.TwoThousand:
                        if (line.Quantity >= 3)
                            thisAmount += line.Quantity * line.Product.Price * .8d;
                        else
                            thisAmount += line.Quantity * line.Product.Price;
                        break;
                }
                lineFunction(line, thisAmount);
                totalAmount += thisAmount;
            }
            return totalAmount;
        }
    }
}