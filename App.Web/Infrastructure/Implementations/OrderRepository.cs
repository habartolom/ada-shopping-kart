using App.Web.Infrastructure.Database.Context;
using App.Web.Infrastructure.Database.StoreProcedures;
using App.Web.Infrastructure.Interfaces;
using App.Web.Models.Dtos;
using App.Web.Models.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public async Task<int> AddProductsToOrder(IEnumerable<OrderProductEntity> orderProducts)
        {
            string createOrderProductsTypeSqlStatement = StoreProcedures.CreateOrderProductsType;
            string bulkInsertOrderProductsSqlStatement = StoreProcedures.BulkInsertOrderProducts;

            await _dbContext.Database.ExecuteSqlRawAsync(createOrderProductsTypeSqlStatement);

            DataTable dataTable = GetOrderProductsDataTable(orderProducts);
            var sqlParameters = new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName = "@orderProductsTable",
                    Value = dataTable,
                    TypeName = "dbo.OrderProductsTableType"
                }
            };

            return await _dbContext.Database.ExecuteSqlRawAsync(bulkInsertOrderProductsSqlStatement, sqlParameters);
        }

        public Task<int> CreateOrderAsync(OrderEntity order)
        {
            string sqlStatement = StoreProcedures.CreateOrder;
            var sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@id", order.Id),
                new SqlParameter("@userId", order.UserId),
                new SqlParameter("@date", order.Date),
                new SqlParameter("@items", order.Items),
                new SqlParameter("@total", order.Total)
            };

            return _dbContext.Database.ExecuteSqlRawAsync(sqlStatement, sqlParameters);
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

        private DataTable GetOrderProductsDataTable(IEnumerable<OrderProductEntity> orderProducts)
        {
            var dataSourceTable = new DataTable();
            dataSourceTable.Columns.Add("Id", typeof(Guid));
            dataSourceTable.Columns.Add("Quantity", typeof(int));
            dataSourceTable.Columns.Add("Price", typeof(double));
            dataSourceTable.Columns.Add("Total", typeof(double));
            dataSourceTable.Columns.Add("OrderId", typeof(Guid));
            dataSourceTable.Columns.Add("ProductId", typeof(Guid));

            foreach (OrderProductEntity orderProduct in orderProducts) 
            {
                dataSourceTable.Rows.Add(
                    orderProduct.Id,
                    orderProduct.Quantity,
                    orderProduct.Price,
                    orderProduct.Total,
                    orderProduct.OrderId,
                    orderProduct.ProductId
                );
            }

            return dataSourceTable;
        }
    }
}
