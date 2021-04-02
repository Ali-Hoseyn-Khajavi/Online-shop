using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.SalesInvoices.Exceptions
{
    class ExistInvoiceNumberException:Exception
    {
        public override string Message =>"This Number Already Exist.";
    }
}
