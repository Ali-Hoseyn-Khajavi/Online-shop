using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Persistence.EF;
using OnlineShop.Persistence.EF.Categories;
using OnlineShop.Persistence.EF.GoodEntries;
using OnlineShop.Persistence.EF.Goods;
using OnlineShop.Persistence.EF.SalesInvoices;
using OnlineShop.Persistence.EF.Warehouses;
using OnlineShop.Services.Categories;
using OnlineShop.Services.Categories.Contracts;
using OnlineShop.Services.GoodEntries;
using OnlineShop.Services.GoodEntries.Contracts;
using OnlineShop.Services.Goods;
using OnlineShop.Services.Goods.Contracts;
using OnlineShop.Services.SalesInvoices;
using OnlineShop.Services.SalesInvoices.Contracts;
using OnlineShop.Services.Warehouses;
using OnlineShop.Services.Warehouses.Contracts;

namespace OnlineShop.RestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<CategoryServices, CategoryAppServices>();
            services.AddScoped<CategoryRepository, EFCategoryRepository>();
            services.AddScoped<GoodEntryServices, GoodEntryAppServices>();
            services.AddScoped<GoodServices, GoodAppServices>();
            services.AddScoped<SalesInvoiceServices, SalesInvoiceAppServices>();
            services.AddScoped<WarehouseServices, WarehouseAppServices>();
            services.AddScoped<SalesInvoiceRepository, EFSalesInvoiceRepository>();
            services.AddScoped<CategoryRepository, EFCategoryRepository>();
            services.AddScoped<GoodRepository, EFGoodRepository>();
            services.AddScoped<GoodEntryRepository, EFGoodEntryRepository>();
            services.AddScoped<WarehouseRepository, EFWarehouseRepository>();
            services.AddScoped<UnitOfWork, EFUnitOfWork>();
            services.AddDbContext<EFDbContext>(option=> 
            {
                option.UseSqlServer("Server =.; Database = OnlineStor; Trusted_Connection = True;");
            });
            services.AddSwaggerGen();


        }
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
