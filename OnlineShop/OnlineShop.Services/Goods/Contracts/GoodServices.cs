using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Goods.Contracts
{
  public interface GoodServices
    {
        Task<int> Add(AddGoodDto dto);
        Task<GetByIdGoodDto> GetById(int id);
        Task Delete(int id);
    }
}
