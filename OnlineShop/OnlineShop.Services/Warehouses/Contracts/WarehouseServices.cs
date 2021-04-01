using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Warehouses.Contracts
{
  public interface WarehouseServices
    {
        Task<IList<GetAllWarehouseDto>> GetAll();
        Task<IList<GetAllWarehouseDto>> GetAll(string filter, int pageId);

    }
}
