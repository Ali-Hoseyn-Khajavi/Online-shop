using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Goods.Contracts
{
 public interface GoodRepository 
    {
        void Add(Good good);
        Task<bool> IsExistsTitleToCategory(string title, int categoryId);
        Task<bool> IsExistsByCode(string code);
        Task<Good> FindById(int id);
        void Delete(Good good);
    }
}
