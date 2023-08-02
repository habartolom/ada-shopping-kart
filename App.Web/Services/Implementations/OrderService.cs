using App.Web.Infrastructure.Implementations;
using App.Web.Infrastructure.Interfaces;
using App.Web.Models.Constants;
using App.Web.Models.Contracts.Orders;
using App.Web.Models.Contracts.Response;
using App.Web.Models.Dtos;
using App.Web.Models.Entities;
using App.Web.Models.Enums;
using App.Web.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResponseTypedContract<OrderDetailDto>> CreateOrderAsync(IEnumerable<ProductRequestContract> requestedProducts)
        {
            var response = new ResponseTypedContract<OrderDetailDto>();
            try
            {
                var products = _productRepository.GetProductsByIds(requestedProducts.Select(x => x.Id));

                Guid orderId = Guid.NewGuid();

                IEnumerable<OrderProductEntity> orderProducts = (
                    from requestedProduct in requestedProducts
                    join product in products on requestedProduct.Id equals product.Id
                    select new OrderProductEntity
                    {
                        Id = Guid.NewGuid(),
                        Price = product.Price,
                        Total = product.Price * requestedProduct.Quantity,
                        OrderId = orderId,
                        ProductId = product.Id,
                        Quantity = requestedProduct.Quantity
                    });

                var order = new OrderEntity()
                {
                    Id = orderId,
                    Date = DateTime.Now,
                    Total = orderProducts.Sum(x => x.Total),
                    Items = orderProducts.Sum(x => x.Quantity),
                    UserId = new Guid("499ebb4a-9a46-4a24-b713-c9dd170840c7")
                };

                await _orderRepository.CreateOrderAsync(order);
                await _orderRepository.AddProductsToOrder(orderProducts);

                order = await _orderRepository.GetOrderAsync(order.Id);

                response.Data = _mapper.Map<OrderDetailDto>(order);
            }
            catch (Exception ex)
            {
                response.Header.Code = HttpCodeEnum.InternalServerError;
                response.Header.Message = ex.ToString();
            }

            return response;
        }

        public async Task<ResponseTypedContract<OrderDetailDto>> GetOrderAsync(Guid orderId)
        {
            var response = new ResponseTypedContract<OrderDetailDto>();
            try
            {
                OrderEntity? order = await _orderRepository.GetOrderAsync(orderId);
                if (order is null) throw new Exception("Order not Found");

                response.Data = _mapper.Map<OrderDetailDto>(order);
            }
            catch (Exception ex)
            {
                response.Header.Code = HttpCodeEnum.InternalServerError;
                response.Header.Message = ex.ToString();
            }

            return response;
        }

        public ResponseTypedContract<IEnumerable<OrderDto>> GetOrders(Guid userId)
        {
            var response = new ResponseTypedContract<IEnumerable<OrderDto>>();
            try
            {
                response.Data = _orderRepository.GetOrders(userId);
            }
            catch (Exception ex)
            {
                response.Header.Code = HttpCodeEnum.InternalServerError;
                response.Header.Message = ex.ToString();
            }

            return response;
        }
    }
}
