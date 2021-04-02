using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.Warehouses.Exceptions
{
    class NotExistStokInWarehouceException:Exception
    {
        public override string Message => "The stock of this Good is low";
    }
}
