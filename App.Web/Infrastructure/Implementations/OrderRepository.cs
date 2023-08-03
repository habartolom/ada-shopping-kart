using App.Web.Infrastructure.Database.Context;
using App.Web.Infrastructure.Database.StoreProcedures;
using App.Web.Infrastructure.Interfaces;
using App.Web.Models.Contracts.Orders;
using App.Web.Models.Dtos;
using App.Web.Models.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace App.Web.Infrastructure.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private DbContext _dbContext;
        private DbSet<OrderEntity> _table;

        public OrderRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<OrderEntity>();
        }

        public async Task<int> CreateOrderAsync(IEnumerable<ProductRequestContract> requestedProducts, Guid orderId, Guid userId)
        {
            string createRequestedProductsTypeSqlStatement = StoreProcedures.CreateRequestedProductsType;
            string createOrderSqlStatement = StoreProcedures.CreateOrder;

            await _dbContext.Database.ExecuteSqlRawAsync(createRequestedProductsTypeSqlStatement);

            DataTable dataTable = GetRequestedProductsDataTable(requestedProducts);
            var sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@orderId", orderId),
                new SqlParameter("@orderDate", DateTime.Now),
                new SqlParameter("@userId", userId),
                new SqlParameter { ParameterName = "@requestedProductsTable", Value = dataTable, TypeName = "dbo.RequestedProductsTableType" }
            };

            return await _dbContext.Database.ExecuteSqlRawAsync(createOrderSqlStatement, sqlParameters);
        }

        public async Task<OrderEntity?> GetOrderAsync(Guid orderId)
        {
            OrderEntity? order = await _table
                .Include(x => x.Products).ThenInclude(x => x.Product)
                .Where(x => x.Id.Equals(orderId))
                .FirstOrDefaultAsync();

            return order;
        }

        public IEnumerable<OrderDto> GetOrders(Guid userId)
        {
            IEnumerable<OrderDto> orders = _table
                .Where(x => x.UserId.Equals(userId))
                .Select(x => new OrderDto
                    {
                        Id = x.Id,
                        Date = x.Date,
                        Total = x.Total,
                        Items = x.Items
                    }
                ).OrderByDescending(x => x.Date)
                .AsEnumerable();

            return orders;
        }

        private DataTable GetRequestedProductsDataTable(IEnumerable<ProductRequestContract> requestedProducts)
        {
            var dataSourceTable = new DataTable();
            dataSourceTable.Columns.Add("Id", typeof(Guid));
            dataSourceTable.Columns.Add("Quantity", typeof(int));

            foreach (ProductRequestContract product in requestedProducts) 
            {
                dataSourceTable.Rows.Add(
                    product.Id,
                    product.Quantity
                );
            }

            return dataSourceTable;
        }
    }
}
