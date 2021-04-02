using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.SalesInvoices.Contracts;
using OnlineShop.Services.SalesInvoices.Exceptions;
using OnlineShop.Services.Warehouses.Contracts;
using OnlineShop.Services.Warehouses.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.SalesInvoices
{
    class SalesInvoiceAppServices : SalesInvoiceServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly SalesInvoiceRepository _repository;
        private readonly WarehouseRepository _warehouseRepository;
        public SalesInvoiceAppServices(UnitOfWork unitOfWork,SalesInvoiceRepository invoiceRepository,WarehouseRepository warehouseRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = invoiceRepository;
            _warehouseRepository = warehouseRepository;

        }
        public async Task<int> Add(AddSalesInvoiceDto dto)
        {
            await CheckExistsByNumber(dto.InvoiceNumber);

            var salesInvoice = new SalesInvoice()
            {
                InvoiceDate = DateTime.Now,
                CustomerName = dto.CustomerName,
                InvoiceNumber = dto.InvoiceNumber
            };

            decimal totalPrice = 0;
            var selasItems = new HashSet<SalesItem>();
            foreach (var item in dto.SalesItemDto)
            {
                var warehouse= await _warehouseRepository.FindByGoodCode(item.GoodCode);
                CheckExistsGoodInWarehouse(warehouse);
                CheckStockInWarehouse(warehouse.Count, item.Count);
                selasItems.Add(new SalesItem
                {
                    Count = item.Count,
                    InvoiceId = salesInvoice.Id,
                    Price = item.Price,
                    GoodId = warehouse.GoodId,
                });
                totalPrice += (item.Price * item.Count);
                warehouse.Count -= item.Count;
            }
            salesInvoice.SalesItems = selasItems;

            var accounting = new HashSet<AccountingDocument>()
            {
                 new AccountingDocument()
                {
                InvoiceId = salesInvoice.Id,
                DateOfDocument = DateTime.Now,
                DocumentNumber =DateTime.Now.ToShortDateString(),
                InvoiceNumber = dto.InvoiceNumber,
                Totalprice=totalPrice
                }
            };

            salesInvoice.AccountingDocuments = accounting;
            _repository.Add(salesInvoice);
            _unitOfWork.Complate();
            return salesInvoice.Id;
        }

        private void CheckStockInWarehouse(int warehouseCount, int salesCount)
        {
            if (warehouseCount < salesCount)
            {
                throw new NotExistStokInWarehouceException();
            }
        }

        private void CheckExistsGoodInWarehouse(Warehouse warehouse)
        {
            if (warehouse == null)
            {
                throw new ExistGoodInventoryInWarehouceException();
            }
        }

        private async Task CheckExistsByNumber(string number)
        {
            if (await _repository.IsExistsByNumber(number))
            {
                throw new ExistInvoiceNumberException();
            }
        }

        public async Task<GetByIdSalesInvoiceDto> GetById(int id)
        {
            var invoice = await _repository.FindById(id);
            CheckExsitsSalesInvoice(invoice);

            int count = 0;
            foreach (var item in invoice.SalesItems)
            {
                count += item.Count;
            }

            decimal price = 0;
            foreach (var item in invoice.AccountingDocuments)
            {
                price += item.Totalprice;
            }

            GetByIdSalesInvoiceDto dto = new GetByIdSalesInvoiceDto()
            {
                Count = count,
                TotalPrice = price,
                InvoiceNumber = invoice.InvoiceNumber,
                CustomerName = invoice.CustomerName,
                InvoiceDate = invoice.InvoiceDate,
                Id = invoice.Id
            };

            return dto;
        }

        private void CheckExsitsSalesInvoice(SalesInvoice invoice)
        {
            if (invoice == null)
            {
                throw new NotExistSalsInvoiceException();
            }
        }
    }
}
