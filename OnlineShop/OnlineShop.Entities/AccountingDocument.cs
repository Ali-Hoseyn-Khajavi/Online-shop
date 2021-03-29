using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
  public  class AccountingDocument
    {
        public int Id { get; set; }
        public string DocumentNumber { get; set; }
        public string  InvoiceNumber { get; set; }
        public decimal Totalprice { get; set; }
        public DateTime DateOfDocument { get; set; }
        public int InvoiceId { get; set; }
        public SalesInvoice  salesInvoice { get; set; }
    }
}
