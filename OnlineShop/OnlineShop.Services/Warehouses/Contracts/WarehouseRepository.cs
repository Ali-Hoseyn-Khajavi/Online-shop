using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Warehouses.Contracts
{
  public interface WarehouseRepository
    {
        Task<Warehouse> FindByGoodCode(string code);
        Task<IList<GetAllWarehouseDto>> GetAll();
        Task<IList<GetAllWarehouseDto>> GetAll(string filter, int skip, int take);
        Task<int> CountGoodByFilter(string filter);
        void Delete(Warehouse warehouse);
    }
}
