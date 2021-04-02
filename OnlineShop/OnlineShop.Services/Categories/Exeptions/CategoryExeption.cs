using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.Categories.Exeptions
{
   public class CategoryExeption:Exception
    {
        public override string Message => "There are no categories";
    }
}
