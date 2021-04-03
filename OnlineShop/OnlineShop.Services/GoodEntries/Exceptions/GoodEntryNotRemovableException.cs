using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.GoodEntries.Exceptions
{
   public class GoodEntryNotRemovableException:Exception
    {
        public override string Message =>"Not Delete";
    }
}
