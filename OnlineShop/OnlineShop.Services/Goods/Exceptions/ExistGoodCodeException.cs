using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.Goods.Exceptions
{
    class ExistGoodCodeException:Exception
    {
        public override string Message =>"This Good Already Exist";
    }
}
