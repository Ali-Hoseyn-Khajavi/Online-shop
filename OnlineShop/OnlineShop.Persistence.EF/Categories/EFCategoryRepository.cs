using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.Categories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EF.Categories
{
    public class EFCategoryRepository : CategoryRepository
    {
        private readonly EFDbContext _context;
        private readonly DbSet<Category> _set;

        public EFCategoryRepository(EFDbContext context)
        {
            _context = context;
            _set = _context.Categories;
        }

        public void Add(Category category )
        {
            _context.Add(category);
        }

        public async Task<IList<GetAllCategoryDto>> GetAll()
        {
            return await _set.Select(_ => new GetAllCategoryDto()
            {
                Id = _.Id,
                Title = _.Title
            }).ToListAsync();
        }

        public async Task<bool> IsExistsById(int id)
        {
            return await _set.AnyAsync(_ => _.Id == id);
        }
    }
}
