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
    }
}
