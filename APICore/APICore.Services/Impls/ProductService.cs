using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APICore.Common.DTO.Request;
using APICore.Data.Entities;
using APICore.Data.UoW;

namespace APICore.Services.Impls
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _unitOfWork.ProductRepository.GetAllAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _unitOfWork.ProductRepository.GetAsync(id);
        }

        public async Task AddProductAsync(Product product)
        {
            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteProductAsync(Product product)
        {
            _unitOfWork.ProductRepository.Delete(product);
            await _unitOfWork.CommitAsync();
        }
    }
}

