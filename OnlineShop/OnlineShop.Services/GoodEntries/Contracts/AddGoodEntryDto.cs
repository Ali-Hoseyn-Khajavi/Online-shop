using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.GoodEntries.Contracts
{
  public class AddGoodEntryDto
    {
        public int Count { get; set; }
        public string InvoiceNumber { get; set; }
        public string GoodCode { get; set; }
    }
}
