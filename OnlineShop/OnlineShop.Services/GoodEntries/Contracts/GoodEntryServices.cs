using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.GoodEntries.Contracts
{
   public interface GoodEntryServices
    {
        Task<int> Add(AddGoodEntryDto dto);
        Task Delete(int id);
        Task<IList<GetAllGoodEntryDto>> GetAll();
    }
}
