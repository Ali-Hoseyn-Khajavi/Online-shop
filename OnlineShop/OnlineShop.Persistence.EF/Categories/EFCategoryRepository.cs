using OnlineShop.Entities;
using OnlineShop.Services.Categories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EF.Categories
{
    public class EFCategoryRepository : CategoryRepository
    {
        public void Add(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<IList<GetAllCategoryDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistsById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
