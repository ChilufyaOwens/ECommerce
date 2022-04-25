namespace ECommerce.Core.Domain.Domain.Common.Interfaces
{
    public interface IAuditableEntity
    {
        bool IsDeleted { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        int? ModifiedBy { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
