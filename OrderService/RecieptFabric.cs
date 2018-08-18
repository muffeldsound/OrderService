using System;
using OrderService.Contracts;
using OrderService.RecieptProviders;

namespace OrderService
{
    internal class RecieptFabric
    {
        internal static IReciept CreateRecieptProvider(string format)
        {
            switch (format)
            {
                case "html":
                    return new HtmlReciept();
                case "json":
                    return new JsonReciept();
                default:
                    return new TextReciept();
            }
        }
    }
}