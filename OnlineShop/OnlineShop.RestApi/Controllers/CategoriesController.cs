using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.Categories.Contracts;

namespace OnlineShop.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {

        private readonly CategoryServices _services;

        public CategoriesController(CategoryServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<int> Add(AddCategoryDto dto)
        {
            return await _services.Add(dto);
        }

        [HttpGet]
        public async Task<IList<GetAllCategoryDto>> GetAll()
        {
            return await _services.GetAll();
        }
    }
}