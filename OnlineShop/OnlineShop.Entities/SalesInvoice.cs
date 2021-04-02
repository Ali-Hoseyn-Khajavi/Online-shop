﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
  public  class SalesInvoice
    {
        public SalesInvoice()
        {
            SalesItems = new HashSet<SalesItem>();
            AccountingDocuments = new HashSet<AccountingDocument>();
        }
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public HashSet<SalesItem>  SalesItems { get; set; }
        public HashSet<AccountingDocument>  AccountingDocuments { get; set; }
    }
}
