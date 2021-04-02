using Microsoft.EntityFrameworkCore;
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
        private readonly EFDataContext _context;
        private readonly DbSet<SalesInvoice> _set;

        public EFSalesInvoiceRepository(EFDataContext context)
        {
            _context = context;
            _set = _context.SalesInvoices;
        }

        public void Add(SalesInvoice salesInvoice)
        {
            _set.Add(salesInvoice);
        }

        public async Task<SalesInvoice> FindById(int id)
        {
            return await _set
                .Include(_ => _.SalesItems)
                .Include(_ => _.AccountingDocuments)
                .SingleOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<SalesInvoice> FindByNumber(string number)
        {
            return await _set
                .Include(_ => _.AccountingDocuments)
                .SingleOrDefaultAsync(_ => _.InvoiceNumber == number);
        }

        public async Task<bool> IsExistsByNumber(string number)
        {
            return await _set.AnyAsync(_ => _.InvoiceNumber == number);
        }
    }
}
