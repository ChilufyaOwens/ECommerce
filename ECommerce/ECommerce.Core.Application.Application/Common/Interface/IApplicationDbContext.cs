using ECommerce.Core.Domain.Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Core.Application.Application.Common.Interface
{
    public interface IApplicationDbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();


    }
}
