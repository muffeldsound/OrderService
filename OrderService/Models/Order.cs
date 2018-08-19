using OrderService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderService
{
    public class Order
    {
        private readonly IList<OrderLine> _orderLines = new List<OrderLine>();

        public Order(string company)
        {
            Company = company;
        }

        public string Company { get; set; }

        public void AddLine(OrderLine orderLine)
        {
            _orderLines.Add(orderLine);
        }

        public IList<OrderLine> OrderLines
        {
            get { return _orderLines; }
        }

    }
}