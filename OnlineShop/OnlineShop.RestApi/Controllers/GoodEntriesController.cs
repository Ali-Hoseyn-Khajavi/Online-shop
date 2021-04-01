using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.GoodEntries.Contracts;

namespace OnlineShop.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodEntriesController : Controller
    {
        private readonly GoodEntryServices _services;

        public GoodEntriesController(GoodEntryServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<int> Add(AddGoodEntryDto dto)
        {
            return await _services.Add(dto);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _services.Delete(id);
        }

        [HttpGet]
        public async Task<IList<GetAllGoodEntryDto>> GetAll()
        {
            return await _services.GetAll();
        }
    }
}