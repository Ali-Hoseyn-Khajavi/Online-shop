using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.GoodEntries.Exceptions
{
    class GoodEntryException:Exception
    {
        public override string Message => "This number of goods is not available in stock";
    }
}
