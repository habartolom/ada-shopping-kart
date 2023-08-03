using App.Web.Infrastructure.Interfaces;
using App.Web.Models.Contracts.Products;
using App.Web.Models.Contracts.Response;
using App.Web.Models.Dtos;
using App.Web.Models.Entities;
using App.Web.Models.Enums;
using App.Web.Services.Interfaces;
using AutoMapper;
using System.Security.Claims;

namespace App.Web.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<ResponseTypedErrorContract<OrderDetailDto, IEnumerable<ProductDto>>> CreateOrderAsync(IEnumerable<ProductRequestContract> requestedProducts)
        {
            var response = new ResponseTypedErrorContract<OrderDetailDto, IEnumerable<ProductDto>>();
            try
            {
                ClaimsIdentity? claimsIdentity = _httpContextAccessor.HttpContext!.User.Identity as ClaimsIdentity;
                string username = claimsIdentity!.FindFirst(ClaimTypes.Name)!.Value;
                UserEntity user = await _userRepository.GetUserByUsernameAsync(username);

                var orderId = Guid.NewGuid();
                await _orderRepository.CreateOrderAsync(requestedProducts, orderId, user.Id);
                
                OrderEntity? order = await _orderRepository.GetOrderAsync(orderId);
                if (order is null)
                {
                    var orderedProducts =  _productRepository.GetProductsByIds(requestedProducts.Select(x => x.Id));
                    if (!requestedProducts.Count().Equals(orderedProducts.Count())) throw new Exception("Bad Request");

                    var orderedProductsWithoutStock = (
                        from requestedProduct in requestedProducts
                        join orderedProduct in orderedProducts on requestedProduct.Id equals orderedProduct.Id
                        where requestedProduct.Quantity > orderedProduct.Stock
                        select orderedProduct
                    );

                    if (orderedProductsWithoutStock.Any())
                    {
                        response.DataError = _mapper.Map<IEnumerable<ProductDto>>(orderedProductsWithoutStock);
                        throw new ApplicationException("There are some products without stock");
                    }
                }

                response.Data = _mapper.Map<OrderDetailDto>(order);
            }
            catch (ApplicationException ex)
            {
                response.Header.Code = HttpCodeEnum.InternalServerError;
                response.Header.Message = ex.Message;
                
            }
            catch (Exception ex)
            {
                response.Header.Code = HttpCodeEnum.BadRequest;
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
                response.Header.Code = HttpCodeEnum.BadRequest;
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
                response.Header.Code = HttpCodeEnum.BadRequest;
                response.Header.Message = ex.ToString();
            }

            return response;
        }

        private IEnumerable<OrderProductEntity> GetOrderedProducts(Guid orderId, IEnumerable<ProductRequestContract> requestedProducts, IEnumerable<ProductEntity> products)
        {
            IEnumerable<OrderProductEntity> orderedProducts = (
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

            return orderedProducts;
        }

        private IEnumerable<ProductEntity> GetUpdatedProducts(IEnumerable<ProductRequestContract> requestedProducts, IEnumerable<ProductEntity> products)
        {
            foreach (var requestedProduct in requestedProducts)
            {
                // Buscar el producto correspondiente por su Id
                var productToUpdate = products.FirstOrDefault(p => p.Id == requestedProduct.Id);

                if (productToUpdate != null)
                {
                    // Actualizar el stock del producto
                    productToUpdate.Stock -= requestedProduct.Quantity;
                }
            }

            return products;
        }

        private IEnumerable<ProductEntity> GetRequestedProductsWithoutStock(IEnumerable<ProductRequestContract> requestedProducts, IEnumerable<ProductEntity> products)
        {
            IEnumerable<ProductEntity> requestedProductsWithoutStock = (
                from requestedProduct in requestedProducts
                join product in products on requestedProduct.Id equals product.Id
                where product.Stock - requestedProduct.Quantity < 0
                select product
            );

            return requestedProductsWithoutStock;
        }
    }
}
