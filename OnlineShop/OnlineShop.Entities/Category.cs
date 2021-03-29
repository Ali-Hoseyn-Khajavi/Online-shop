using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{

  public  class Category
    {
        public Category()
        {
            Goods = new HashSet<Good>();
                 
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public HashSet<Good> Goods { get; set; }
    }
}
