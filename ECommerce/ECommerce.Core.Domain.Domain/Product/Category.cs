using ECommerce.Core.Domain.Domain.Common;

namespace ECommerce.Core.Domain.Domain.Product
{
    public class Category : AuditableEntity<int>
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public int DisplayOrder { get; set; }
    }
}
