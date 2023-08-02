using App.Web.Infrastructure.Database.Context;
using App.Web.Infrastructure.Database.StoreProcedures;
using App.Web.Infrastructure.Interfaces;
using App.Web.Models.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Data;

namespace App.Web.Infrastructure.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private DbContext _dbContext;
        private DbSet<ProductEntity> _table;

        public ProductRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<ProductEntity>();
        }

        public IQueryable<ProductEntity> GetProductsByIds(IEnumerable<Guid> productIds)
        {
            var products = _table
                .Where(product => productIds.Contains(product.Id));

            return products;
        }

        public async Task<int> Update(IEnumerable<ProductEntity> products)
        {
            _table.UpdateRange(products);
            _dbContext.SaveChanges();
            //string createProductsTypeSqlStatement = StoreProcedures.CreateProductsType;
            //string massiveUpdateProductsSqlStatement = StoreProcedures.MassiveUpdateProducts;

            //await _dbContext.Database.ExecuteSqlRawAsync(createProductsTypeSqlStatement);
            
            //DataTable dataTable = GetProductsDataTable(products);
            //var sqlParameters = new SqlParameter[]
            //{
            //    new SqlParameter
            //    {
            //        ParameterName = "@productsTable",
            //        Value = dataTable,
            //        TypeName = "dbo.ProductsTableType"
            //    }
            //};

            return 1;/*await _dbContext.Database.ExecuteSqlRawAsync(massiveUpdateProductsSqlStatement, sqlParameters);*/
        }

        private DataTable GetProductsDataTable(IEnumerable<ProductEntity> products)
        {
            var dataSourceTable = new DataTable();
            dataSourceTable.Columns.Add("Id", typeof(Guid));
            dataSourceTable.Columns.Add("Name", typeof(string));
            dataSourceTable.Columns.Add("Price", typeof(double));
            dataSourceTable.Columns.Add("Stock", typeof(int));

            foreach (ProductEntity product in products)
            {
                dataSourceTable.Rows.Add(
                    product.Id,
                    product.Name,
                    product.Price,
                    product.Stock
                );
            }

            return dataSourceTable;
        }
    }
}
