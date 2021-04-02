using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.Goods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EF.Goods
{
    public class EFGoodRepository : GoodRepository
    {
        private readonly EFDbContext _context;
        private readonly DbSet<Good> _set;
        public EFGoodRepository(EFDbContext context)
        {
            _context = context;
            _set = _context.goods;
        }
        public void Add(Good good)
        {
            _set.Add(good);
        }

        public void Delete(Good good)
        {
            _set.Remove(good);
        }

        public async Task<Good> FindById(int id)
        {
            return await _set
                .Include(_ => _.GoodEntries)
                .Include(_ => _.SalesItems)
                .Include(_ => _.Warehouses)
                .SingleOrDefaultAsync(_=>_.Id==id);
                }

        public async Task<bool> IsExistsByCode(string code)
        {
            return await _set.AnyAsync(_ => _.Code == code);
        }

     

        public async Task<bool> IsExistsTitleToCategory(string title, int categoryId)
        {
            return await _set
                .AnyAsync(_ =>
                          _.Title == title &&
                          _.CategoryId== categoryId);

        }
    }
}
