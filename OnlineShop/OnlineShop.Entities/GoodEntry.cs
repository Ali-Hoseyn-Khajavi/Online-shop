using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
 public class GoodEntry
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime EntryDate { get; set; }
        public int GoodId { get; set; }
        public Good  good { get; set; }
    }
}
