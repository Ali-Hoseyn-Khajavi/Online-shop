using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
  public  class SalesInvoice
    {
        public SalesInvoice()
        {
            salesItems = new HashSet<SalesItem>();
            accountingDocuments = new HashSet<AccountingDocument>();
        }
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public HashSet<SalesItem>  salesItems { get; set; }
        public HashSet<AccountingDocument>  accountingDocuments { get; set; }
    }
}
