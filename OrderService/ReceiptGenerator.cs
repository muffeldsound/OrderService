using OrderService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService
{
    public class ReceiptGenerator
    {
        private Order _order;
        private FileFormat _fileFormat;

        public ReceiptGenerator(Order order, FileFormat fileFormat)
        {
            _order = order;
            _fileFormat = fileFormat;
        }

        public string Generate()
        {
            IReceipt receipt = ReceiptProviderFabric.CreateReceiptProvider(_fileFormat);
            return receipt.GenerateReceipt(_order);

        }
    }
}
