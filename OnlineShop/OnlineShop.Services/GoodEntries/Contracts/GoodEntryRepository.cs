using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.GoodEntries.Contracts
{
 public  interface GoodEntryRepository
    {
        void Add(GoodEntry goodEntry);
        void Delete(GoodEntry goodEntry);
        Task<GoodEntry> FindById(int id);
        Task<IList<GetAllGoodEntryDto>> GetAll();
    }
}
