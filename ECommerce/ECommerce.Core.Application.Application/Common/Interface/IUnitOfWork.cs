using ECommerce.Core.Domain.Domain.Product;

namespace ECommerce.Core.Application.Application.Common.Interface
{
    public interface IUnitOfWork
    {
        IRepository<Category> CategoryRepository { get; }
        IRepository<Product> ProductsRepository { get; }
        Task<int> SaveAsync();
        int Save();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
