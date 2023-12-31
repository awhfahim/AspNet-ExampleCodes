using Exam1.Domain.Entities;
using Exam1.Domain.Exceptions;
using Exam1.Domain.Features.ProductsServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Application.Features.ProductsServices
{
    public class ProductService : IProductService
    {
        private IApplicationUnitOfWork _unitOfWork;

        public ProductService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Category>> GetCategories() =>
            await _unitOfWork.CategoryRepository.GetAllAsync();

        public async Task AddProductAsync(string name, uint price, double weight, Guid SelectedCategory)
        {
            if (await IsDuplicateAsync(name))
                throw new DuplicateValueException($"{name} is Duplicate");

            var product = new Product { Name = name, Price = price, Weight = weight, CategoryId = SelectedCategory };
            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _unitOfWork.ProductRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<(IList<ProductWithCategory> records, int total, int totalDisplay)> GetPagedProductsAsync
            (int pageIndex, int pageSize, string searchText, string orderBy)

        {
            var catagories = await GetCategories();
            var temp =  await _unitOfWork.ProductRepository.GetTableDataAsync(searchText,orderBy,pageIndex,pageSize);


            var r = (from ra in temp.records
                     select new ProductWithCategory
                     {
                         Id = ra.Id,
                         Name = ra.Name,
                         Price = ra.Price,
                         Weight = ra.Weight,
                         CategoryName = (from c in catagories
                                         where c.Id == ra.CategoryId
                                         select c.Name).First()
                     }).ToList();

            return (r, temp.total, temp.totalDisplay);
        }

        public async Task<Product> GetProductAsync(Guid id)
        {
            return await _unitOfWork.ProductRepository.GetByIdAsync(id);
        }

        public async Task UpdateProductAsync(Guid Id, string name, uint price, double weight)
        {
            if (await IsDuplicateAsync(name, Id))
                throw new DuplicateValueException($"{name} is Duplicate");

            var product = await GetProductAsync(Id);

            if(product is not null)
            {
                product.Weight = weight;
                product.Price = price;
                product.Name = name;
            }
            await _unitOfWork.SaveAsync();
        }

        private async Task<bool> IsDuplicateAsync(string name, Guid? Id = null)
        {
            return await _unitOfWork.ProductRepository.IsDuplicateAsync(name);
        }
    }
}
