using App.Web.Models.Entities;

namespace App.Web.Infrastructure.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<ProductEntity> GetProductsByIds(IEnumerable<Guid> productIds);
    }
}
