using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Categories.Contracts
{
    public interface CategoryServices
    {
        Task<int> Add(AddCategoryDto dto);
        Task<IList<GetAllCategoryDto>> GetAll();
    }
}
