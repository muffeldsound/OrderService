using OrderService.Contracts;
using OrderService.ReceiptProviders;

namespace OrderService
{
    internal class ReceiptFabric
    {
        internal static IReceipt CreateReceiptProvider(string format)
        {
            switch (format)
            {
                case "html":
                    return new HtmlReceipt();
                case "json":
                    return new JsonReceipt();
                default:
                    return new TextReceipt();
            }
        }
    }
}