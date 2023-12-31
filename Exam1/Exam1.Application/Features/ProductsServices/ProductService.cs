using Exam1.Domain.Entities;
using Exam1.Domain.Exceptions;
using Exam1.Domain.Features.ProductsServices;
using System;
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

        public async Task AddProductAsync(string name, uint price, double weight, Guid SelectedCategory)
        {
            if (await IsDuplicateAsync(name))
                throw new DuplicateValueException($"{name} is Duplicate");

            var product = new Product { Name = name, Price = price, Weight = weight };
            product.AddCategory(SelectedCategory);
            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _unitOfWork.ProductRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<(IList<Product> records, int total, int totalDisplay)> GetPagedProductsAsync
            (int pageIndex, int pageSize, string searchText, string orderBy)
        {
            return await _unitOfWork.ProductRepository.GetTableDataAsync(searchText,orderBy,pageIndex,pageSize);
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
