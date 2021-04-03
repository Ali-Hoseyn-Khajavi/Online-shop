using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.GoodEntries.Contracts;
using OnlineShop.Services.Goods.Exceptions;
using OnlineShop.Services.Warehouses.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.GoodEntries
{
    public class GoodEntryAppServices : GoodEntryServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly GoodEntryRepository _repository;
        private readonly WarehouseRepository _warehouseRepository;
        public GoodEntryAppServices(UnitOfWork unitOfWork,GoodEntryRepository entryRepository, WarehouseRepository warehouseRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = entryRepository;
            _warehouseRepository = warehouseRepository;
        }
        public async Task<int> Add(AddGoodEntryDto dto)
        {
            var warehouse = await _warehouseRepository.FindByGoodCode(dto.GoodCode);

            CheckedWarehouseByCode(warehouse);

            GoodEntry goodEntry = new GoodEntry()
            {
                Count = dto.Count,
                GoodId = warehouse.GoodId,
                EntryDate = DateTime.Now,
                Title="DGFDGFGFG",
                
                InvoiceNumber = dto.InvoiceNumber,
            };

            _repository.Add(goodEntry);

            warehouse.Count += goodEntry.Count;

            await _unitOfWork.ComplateAysnc();

            return goodEntry.Id;
        }

        private void CheckedWarehouseByCode(Warehouse warehouse)
        {
            if (warehouse == null)
            {
                throw new GoodNotExistException();
            }
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<GetAllGoodEntryDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
