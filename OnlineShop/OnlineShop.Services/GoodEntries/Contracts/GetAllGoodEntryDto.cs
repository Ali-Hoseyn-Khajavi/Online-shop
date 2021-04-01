using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.GoodEntries.Contracts
{
  public class GetAllGoodEntryDto
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime EntryDate { get; set; }
        public int GoodId { get; set; }
    }
}
