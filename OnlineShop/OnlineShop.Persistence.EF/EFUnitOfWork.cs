using OnlineShop.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EF
{
    public class EFUnitOfWork : UnitOfWork
    {
        public void Complate()
        {
            throw new NotImplementedException();
        }

        public Task ComplateAysnc()
        {
            throw new NotImplementedException();
        }
    }
}
