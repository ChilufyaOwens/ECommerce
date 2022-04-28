using ECommerce.Core.Application.Application.Common.Interface;
using ECommerce.Core.Domain.Domain.Common.Interfaces;
using ECommerce.Core.Domain.Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        #region Properties
        private readonly DateTime _currentDateTime;
        #endregion

        #region Constructors
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
           _currentDateTime = DateTime.Now;
        }
        #endregion
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public Task<int> SaveChangesAsync()
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy =1; //To be replaced by logged in user
                        entry.Entity.ModifiedBy =1; //To be replaced by logged in user
                        entry.Entity.CreatedOn = _currentDateTime;
                        entry.Entity.ModifiedOn = _currentDateTime;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy =1;// To be replaced by logged in user
                        entry.Entity.ModifiedOn= _currentDateTime;
                        break;
                }
            }
            return base.SaveChangesAsync();
        }

        /// <summary>
        /// Creates a DbSet that can be used to query and save instances of entity
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>A set for the given entity type</returns>
        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
