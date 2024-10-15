namespace PMS.Shared.Contracts.Models
{
    public interface IAuditableEntity : ICreatableEntity, IUpdatableEntity, IDeletableEntity
    {
        Guid Id { get; set; }
    }

}
