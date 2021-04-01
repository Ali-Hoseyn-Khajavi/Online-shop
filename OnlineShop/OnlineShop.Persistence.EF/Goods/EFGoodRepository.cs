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
        public void Add(Good good)
        {
            throw new NotImplementedException();
        }

        public void Delete(Good good)
        {
            throw new NotImplementedException();
        }

        public Task<Good> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistsByCode(string code)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistsTitleToGoodCategory(string title, int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
