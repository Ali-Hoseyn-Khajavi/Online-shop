using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.Warehouses.Contracts;

namespace OnlineShop.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : Controller
    {
        private readonly WarehouseServices _services;

        public WarehousesController(WarehouseServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IList<GetAllWarehouseDto>> GetAll()
        {
            return await _services.GetAll();
        }

        [HttpGet("{filter}/{pageing}")]
        public async Task<IList<GetAllWarehouseDto>> GetAll(string filter, int pageing = 1)
        {
            return await _services.GetAll(filter, pageing);
        }
    }
}