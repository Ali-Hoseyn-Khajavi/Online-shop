using OnlineShop.Entities;
using OnlineShop.Services.Warehouses.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EF.Warehouses
{
    public class EFWarehouseRepository : WarehouseRepository
    {
        public Task<int> CountGoodByFilter(string filter)
        {
            throw new NotImplementedException();
        }

        public void Delete(Warehouse warehouse)
        {
            throw new NotImplementedException();
        }

        public Task<Warehouse> FindByGoodCode(string code)
        {
            throw new NotImplementedException();
        }

        public Task<IList<GetAllWarehouseDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IList<GetAllWarehouseDto>> GetAll(string filter, int skip, int take)
        {
            throw new NotImplementedException();
        }
    }
}
