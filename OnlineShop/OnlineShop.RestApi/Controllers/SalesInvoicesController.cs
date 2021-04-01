using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.SalesInvoices.Contracts;

namespace OnlineShop.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesInvoicesController : Controller
    {
        private readonly SalesInvoiceServices _services;

        public SalesInvoicesController(SalesInvoiceServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<int> Add(AddSalesInvoiceDto dto)
        {
            return await _services.Add(dto);
        }

        [HttpGet("{id}")]
        public async Task<GetByIdSalesInvoiceDto> GetById(int id)
        {
            return await _services.GetById(id);
        }
    }
}