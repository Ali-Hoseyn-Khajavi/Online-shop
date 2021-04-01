using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.SalesInvoices.Contracts
{
  public class AddSalesInvoiceDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
