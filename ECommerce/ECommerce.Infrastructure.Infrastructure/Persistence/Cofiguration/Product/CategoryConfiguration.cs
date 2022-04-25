using ECommerce.Core.Domain.Domain.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Infrastructure.Persistence.Cofiguration.Product
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
               .ToTable(nameof(Category));
            builder.Property(nameof(Category.Name)).HasMaxLength(200).IsRequired();
            builder.Property(nameof(Category.Description)).HasMaxLength(500);
        }
    }
}
