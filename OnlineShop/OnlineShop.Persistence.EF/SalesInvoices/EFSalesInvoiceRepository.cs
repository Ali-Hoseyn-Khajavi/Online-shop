using OnlineShop.Entities;
using OnlineShop.Services.SalesInvoices.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EF.SalesInvoices
{
    public class EFSalesInvoiceRepository : SalesInvoiceRepository
    {
        public void Add(SalesInvoice salesInvoice)
        {
            throw new NotImplementedException();
        }

        public Task<SalesInvoice> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SalesInvoice> FindByNumber(string number)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistsByNumber(string number)
        {
            throw new NotImplementedException();
        }
    }
}
