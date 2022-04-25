using ECommerce.Core.Application.Application.Common.Interface;
using ECommerce.Core.Domain.Domain.Product;
using Microsoft.EntityFrameworkCore.Storage;

namespace ECommerce.Infrastructure.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties
        private readonly ApplicationDbContext _context;
        IDbContextTransaction dbContextTransaction;
        private IRepository<Product> _productsRepository;
        private IRepository<Category> _categoryRepository;
        #endregion

        #region Constructors
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Repository
        public IRepository<Product> ProductsRepository
        {
            get
            {
                if (_productsRepository == null)
                    this._productsRepository = new GenericRepository<Product>(_context);
                return _productsRepository;
            }
        }

        public IRepository<Category> CategoryRepository
        {
            get
            {
                if (this._categoryRepository == null)
                    this._categoryRepository = new GenericRepository<Category>(_context);
                return _categoryRepository;
            }
        }


        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public void BeginTransaction()
        {
            dbContextTransaction = _context.Database.BeginTransaction();
        }
        public void CommitTransaction()
        {
            if (dbContextTransaction != null)
            {
                dbContextTransaction.Commit();
            }
        }
        public void RollbackTransaction()
        {
            if (dbContextTransaction != null)
            {
                dbContextTransaction.Rollback();
            }
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion




    }
}
