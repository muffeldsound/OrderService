﻿namespace OrderService
{
    public static class Discount
    {
        public static double VolumeDiscount(this double amount, OrderLine line, int quantityLimit, double percentage)
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