using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
    public class SalesItem
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int InvoceId { get; set; }
        public SalesInvoice  salesInvoice  { get; set; }
    }
}
