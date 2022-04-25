namespace ECommerce.Core.Domain.Domain.Common
{
    public abstract class BaseEntity<T>
    {
        public virtual T Id { get; set; }
    }
}
