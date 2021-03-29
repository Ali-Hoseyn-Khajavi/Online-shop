using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
  public  class Warehouse
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int GoodId { get; set; }
        public Good   good{ get; set; }
      
    }
}
