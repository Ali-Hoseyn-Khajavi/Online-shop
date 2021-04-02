using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.Goods.Exceptions
{
    class GoodNotRemovableException:Exception
    {
        public override string Message => "This Good Not Removable";
    }
}
