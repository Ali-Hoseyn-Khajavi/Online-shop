using OnlineShop.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EF
{

    public class EFUnitOfWork : UnitOfWork
    {

        private readonly EFDbContext _context;
        public EFUnitOfWork(EFDbContext context)
        {
            _context = context;
        }
        public void Complate()
        {
            _context.SaveChanges();
        }

        public async Task ComplateAysnc()
        {
           await _context.SaveChangesAsync();
        }
    }
}
