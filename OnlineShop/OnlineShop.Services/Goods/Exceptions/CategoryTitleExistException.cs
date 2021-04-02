using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.Goods.Exceptions
{
    class CategoryTitleExistException:Exception
    {
        public override string Message =>"This Title Already Exist";
    }
}
