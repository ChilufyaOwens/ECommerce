using ECommerce.Core.Domain.Domain.Common.Interfaces;

namespace ECommerce.Core.Domain.Domain.Common
{
    public abstract class AuditableEntity<T> : BaseEntity<T>, IAuditableEntity
    {
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
