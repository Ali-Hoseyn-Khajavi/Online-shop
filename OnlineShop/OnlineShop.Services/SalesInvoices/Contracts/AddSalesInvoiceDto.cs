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
    public class SalesItemDto
    {
       
        public string GoodCode { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
