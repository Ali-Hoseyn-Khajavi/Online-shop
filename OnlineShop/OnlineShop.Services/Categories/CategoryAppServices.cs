using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.Categories.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.Categories
{
    class CategoryAppServices : CategoryServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly CategoryRepository _repository;
        public CategoryAppServices(UnitOfWork unitOfWork,CategoryRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public async Task<int> Add(AddCategoryDto dto)
        {
          Category category  = new Category()
            {
                Title = dto.Title
            };

            _repository.Add(category);

            await _unitOfWork.ComplateAysnc();

            return category.Id;
        }

        public async Task<IList<GetAllCategoryDto>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
