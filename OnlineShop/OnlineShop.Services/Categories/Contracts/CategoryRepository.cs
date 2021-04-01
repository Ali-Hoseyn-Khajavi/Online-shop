using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Categories.Contracts
{
   public interface CategoryRepository
    {
        void Add(Category category);
        Task<IList<GetAllCategoryDto>> GetAll();
        Task<bool> IsExistsById(int id);
    }
}
