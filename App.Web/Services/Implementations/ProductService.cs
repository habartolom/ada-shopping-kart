using App.Web.Infrastructure.Interfaces;
using App.Web.Models.Contracts.Products;
using App.Web.Models.Contracts.Response;
using App.Web.Models.Dtos;
using App.Web.Models.Entities;
using App.Web.Models.Enums;
using App.Web.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResponseTypedContract<IEnumerable<ProductDto>>> GetAvailableProductsAsync()
        {
            var response = new ResponseTypedContract<IEnumerable<ProductDto>>();
            try
            {
                IEnumerable<ProductEntity> products = _productRepository.GetAll()
                    .Where(x => x.Stock > 0).AsEnumerable();

                response.Data = _mapper.Map<IEnumerable<ProductDto>>(products);
            }
            catch (Exception ex)
            {
                response.Header.Code = HttpCodeEnum.InternalServerError;
                response.Header.Message = ex.Message;
            }

            return response;
        }

        public async Task<ResponseTypedContract<ProductDto>> GetProductAsync(Guid productId)
        {
            var response = new ResponseTypedContract<ProductDto>();
            try
            {
                ProductEntity? product = await _productRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id.Equals(productId));

                response.Data = _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {
                response.Header.Code = HttpCodeEnum.InternalServerError;
                response.Header.Message = ex.Message;
            }

            return response;
        }

        public async Task<ResponseTypedContract<ProductDto>> UpdateProductAsync(Guid productId, ProductUpdateRequestContract product)
        {
            var response = new ResponseTypedContract<ProductDto>();
            try
            {
                var productEntity = await _productRepository.GetAll().FirstOrDefaultAsync(x => x.Id.Equals(productId));
                if (productEntity is null) throw new Exception("Product not found");

                productEntity.Name = product.Name;
                productEntity.Price = product.Price;
                productEntity.Stock = product.Stock;
                await _productRepository.UpdateProductAsync(productEntity);

                response.Data = _mapper.Map<ProductDto>(productEntity);
            }
            catch (Exception ex)
            {
                response.Header.Code = HttpCodeEnum.InternalServerError;
                response.Header.Message = ex.Message;
            }
            
            return response;
        }
    }
}
