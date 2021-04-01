using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.Goods.Contracts;

namespace OnlineShop.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : Controller
    {
        private readonly GoodServices _services;

        public GoodsController(GoodServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<int> Add(AddGoodDto dto)
        {
            return await _services.Add(dto);
        }

        [HttpGet("{id}")]
        public async Task<GetByIdGoodDto> GetById(int id)
        {
            return await _services.GetById(id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _services.Delete(id);
        }
    }
}