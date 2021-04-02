using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.SalesInvoices.Exceptions
{
    class NotExistSalsInvoiceException:Exception
    {
        public override string Message =>"This SalesInvoice Not Exist.";
    }
}
