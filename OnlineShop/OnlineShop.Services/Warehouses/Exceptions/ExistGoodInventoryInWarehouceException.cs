using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.Warehouses.Exceptions
{
    class ExistGoodInventoryInWarehouceException:Exception
    {
        public override string Message => "This Good has inventory.";
    }
}
