using ECommerce.Core.Domain.Domain.Common;

namespace ECommerce.Core.Domain.Domain.Product
{
    public class Product : AuditableEntity<int>
    {
        public string Name { get; set; }
    }
}
