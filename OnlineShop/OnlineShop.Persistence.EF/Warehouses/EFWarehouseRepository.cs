using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Persistence.EF;
using OnlineShop.Services.Warehouses.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EF.Warehouses
{
    public class EFWarehouseRepository : WarehouseRepository
    {
        private readonly EFDbContext _context;
        private readonly DbSet<Warehouse> _set;

        public EFWarehouseRepository(EFDbContext context)
        {
            _context = context;
            _set = _context.Warehouses;
        }


        public async Task<IList<GetAllWarehouseDto>> GetAll()
        {
            var query =
                (from warehouse in _set
                 join Goods in _context.goods
                 on warehouse.GoodId equals Goods.Id
                 join category in _context.GoodEntries
                 on Goods.CategoryId equals category.Id
                 select new GetAllWarehouseDto()
                 {
                     GoodName = Goods.Title,
                     GoodCode = Goods.Code,
                     Categroy = category.Title,
                     MinimumStak = Goods.MinimomStak,
                     Stock = warehouse.Count
                 }).ToListAsync();
            return await query;
        }


        public async Task<IList<GetAllWarehouseDto>> GetAll
            (string filter, int skip, int take)
        {
            return await _set
                .Where(_ =>_.good.Title.Contains(filter)|| _.good.Code.Contains(filter))
                .Skip(skip)
                .Take(take)
                .Select(_ => new GetAllWarehouseDto()
                {
                    MinimumStak = _.good.MinimomStak,
                    Stock = _.Count,
                    GoodName = _.good.Title,
                    Categroy = _.good.category.Title,
                    GoodCode = _.good.Code,
                })
                .ToListAsync();
        }

        public async Task<int> CountGoodByFilter(string filter)
        {
            return await _set
                .CountAsync(_ => _.good.Title.Contains(filter) || _.good.Code.Contains(filter));
        }

        public void Delete(Warehouse warehouse)
        {
            _set.Remove(warehouse);
        }

        public async Task<Warehouse> FindByGoodCode(string code)
        {
            return await _set
                .Include(_=>_.good)
                .SingleOrDefaultAsync(_ => _.good.Code == code);
        }
    }
}
