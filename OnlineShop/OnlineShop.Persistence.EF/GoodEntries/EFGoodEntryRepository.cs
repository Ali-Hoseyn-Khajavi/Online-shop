using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.GoodEntries.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EF.GoodEntries
{
    public class EFGoodEntryRepository : GoodEntryRepository
    {
        private readonly EFDbContext _context;
        private readonly DbSet<GoodEntry> _set;

        public EFGoodEntryRepository(EFDbContext context)
        {
            _context = context;
            _set = _context.GoodEntries;
        }

        public void Add(GoodEntry goodEntry)
        {
            _set.Add(goodEntry);
        }

        public void Delete(GoodEntry goodEntry)
        {
            _set.Remove(goodEntry);
        }

        public async Task<GoodEntry> FindById(int id)
        {
            return await _set
                .Include(_ => _.good)
                .SingleOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<IList<GetAllGoodEntryDto>> GetAll()
        {
            return await _set.Select(_ => new GetAllGoodEntryDto()
            {
                Id = _.Id,
                Count = _.Count,
                InvoiceNumber = _.InvoiceNumber,
                EntryDate = _.EntryDate,
                GoodCode = _.good.Code
            }).ToListAsync();
        }
    }
}
