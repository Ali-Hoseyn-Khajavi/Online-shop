using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.Categories.Contracts;
using OnlineShop.Services.Categories.Exeptions;
using OnlineShop.Services.Goods.Contracts;
using OnlineShop.Services.Goods.Exceptions;
using OnlineShop.Services.Warehouses.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Goods
{
    class GoodAppServices:GoodServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly GoodRepository _repository;
        private readonly CategoryRepository _CategoryRepository;
        private readonly WarehouseRepository _warehouseRepository;

    public GoodAppServices(
        UnitOfWork unitOfWork,
        GoodRepository repository,
        CategoryRepository CategoryRepository,
        WarehouseRepository warehouseRepository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _CategoryRepository = CategoryRepository;
        _warehouseRepository = warehouseRepository;
    }

    public async Task<int> Add(AddGoodDto dto)
    {
        await CheckedExistByCode(dto.Code);
        await CheckedExistsCategory(dto.CategoryId);
        await CheckedExistsTitleToCategory(dto.Title, dto.CategoryId);

        Good good = new Good()
        {
            CategoryId = dto.CategoryId,
            MinimomStak = dto.MinimomStak,
            Code = dto.Code,
            Title = dto.Title
        };

        var warehouse = new HashSet<Warehouse>()
            {
                new Warehouse()
                {
                    GoodId=good.Id,
                    Count=0
                }
            };

        good.Warehouses = warehouse;

        _repository.Add(good);

        await _unitOfWork.ComplateAysnc();

        return good.Id;
    }

        private Task CheckedExistsTitleToCategory(string title, object productCategoryId)
        {
            throw new NotImplementedException();
        }


        private async Task CheckedExistsCategory(int categoryId)
    {
        if (!await _CategoryRepository.IsExistsById(categoryId))
        {
            throw new CategoryExeption();
        }
    }

    private async Task CheckedExistByCode(string code)
    {
        if (await _repository.IsExistsByCode(code))
        {
            throw new ExistGoodCodeException();
        }
    }

    private async Task CheckedExistsTitleToCategory(string title, int categoryId)
    {
        if (await _repository.IsExistsTitleToCategory(title, categoryId))
        {
            throw new CategoryTitleExistException();
        }
    }

    public async Task<GetByIdGoodDto> GetById(int id)
    {
        var good = await _repository.FindById(id);
            CheckedExistsGood(good);

            GetByIdGoodDto dto = new GetByIdGoodDto()
        {
            Id = good.Id,
            Code = good.Code,
            MinimomStak = good.MinimomStak,
            CategoryId = good.CategoryId,
            Title = good.Title
        };

        return dto;
    }

    private void CheckedExistsGood(Good good)
    {
        if (good == null)
        {
            throw new GoodNotExistException();
        }
    }

    public async Task Delete(int id)
    {
        var good = await _repository.FindById(id);
            CheckedExistsGood(good);

        CheckedGoodsetByCount(good.GoodEntries.Count);
        CheckedGoodsetByCount(good.SalesItems.Count);

        var warehouse = await _warehouseRepository.FindByGoodCode(good.Code);
        _warehouseRepository.Delete(warehouse);

        _repository.Delete(good);

        await _unitOfWork.ComplateAysnc();
    }

    private void CheckedGoodsetByCount(int subsetCount)
    {
        if (subsetCount > 0)
        {
            throw new GoodNotRemovableException();
        }
    }

       
    }
}
