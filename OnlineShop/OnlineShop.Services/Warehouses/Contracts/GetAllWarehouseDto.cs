using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.Warehouses.Contracts
{
  public class GetAllWarehouseDto
    {
        public string GoodCode { get; set; }
        public string GoodName { get; set; }
        public string Categroy { get; set; }
        public int Stock { get; set; }
        public int MinimumStak { get; set; }
        public string Status
        {
            get
            {
                if (Stock > MinimumStak)
                {
                    return "Available";
                }
                else if (Stock == MinimumStak)
                {
                    return "Ready to order";
                }
                else
                {
                    return "No-Avalable";
                }
            }
        }
    }
}
