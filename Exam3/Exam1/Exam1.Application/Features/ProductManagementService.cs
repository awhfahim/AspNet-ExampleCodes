using Exam1.Domain.Entities;
using Exam1.Domain.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Application.Features
{
    public class ProductManagementService : IProductManagementService
    {
        private IApplicationUnitOfWork _unitOfWork;
        public ProductManagementService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddProductAsync(string name, uint price, uint weight)
        {
            Product product = new() {  Name = name, Price = price, Weight = weight };
            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveAsync();

        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _unitOfWork.ProductRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<(string name, uint price, uint weight)> GetProductAsync(Guid id)
        {
            var res =  await _unitOfWork.ProductRepository.GetByIdAsync(id);
            return(res.Name, res.Price, res.Weight);
        }

        public async Task<(ICollection<Product> record, int total, int totalDisplay)> 
            GetProductsAsync(int pageIndex, int pageSize, string name, uint priceFrom, uint priceTo, string sortBy)
        {
            return await _unitOfWork.ProductRepository.GetProductsAsync(pageIndex, pageSize, name, priceFrom, priceTo, sortBy);
        }

        public async Task UpdateProductAsync(Guid Id,string name, uint price, uint weight)
        {
           var product = await _unitOfWork.ProductRepository.GetByIdAsync(Id);
            if(product != null)
            {
                product.Name = name;
                product.Price = price;
                product.Weight = weight;
            }
            await _unitOfWork.SaveAsync();
        }
    }
}
