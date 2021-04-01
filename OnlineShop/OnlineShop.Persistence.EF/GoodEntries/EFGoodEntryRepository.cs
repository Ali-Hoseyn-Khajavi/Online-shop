using OnlineShop.Entities;
using OnlineShop.Services.GoodEntries.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EF.GoodEntries
{
    public class EFGoodEntryRepository : GoodEntryRepository
    {
        public void Add(GoodEntry goodEntry)
        {
            throw new NotImplementedException();
        }

        public void Delete(GoodEntry goodEntry)
        {
            throw new NotImplementedException();
        }

        public Task<GoodEntry> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<GetAllGoodEntryDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
