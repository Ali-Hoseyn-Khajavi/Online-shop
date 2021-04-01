using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.Goods.Contracts
{
  public  class AddGoodDto
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public int MinimomStak { get; set; }
        public int CategoryId { get; set; }
    }
}
