using OrderService.Contracts;
using OrderService.ReceiptProviders;

namespace OrderService
{
    internal class ReceiptProviderFabric
    {
        internal static IReceipt CreateReceiptProvider(FileFormat format)
        {
            switch (format)
            {
                case FileFormat.Html:
                    return new HtmlReceipt();
                case FileFormat.Json:
                    return new JsonReceipt();
                default:
                    return new TextReceipt();
            }
        }
    }
}