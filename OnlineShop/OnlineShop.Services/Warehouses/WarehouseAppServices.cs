using OnlineShop.Services.Warehouses.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Warehouses
{
  public  class WarehouseAppServices : WarehouseServices
    {
        private readonly WarehouseRepository _repository;
        public WarehouseAppServices(WarehouseRepository warehouseRepository)
        {
            _repository = warehouseRepository;
        }
        public async Task<IList<GetAllWarehouseDto>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<IList<GetAllWarehouseDto>> GetAll(string filter, int pageId)
        {
            var GoodCount = await _repository.CountGoodByFilter(filter);

            int take = 2;

            int totalPageCount = (int)Math.Ceiling((double)GoodCount / take);

            if (totalPageCount < pageId)
            {
                pageId = 1;
            }

            int skip = (pageId - 1) * take;


            return await _repository.GetAll(filter, skip, take);
        }
    }
}
