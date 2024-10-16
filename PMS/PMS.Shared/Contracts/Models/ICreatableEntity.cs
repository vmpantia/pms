namespace PMS.Shared.Contracts.Models
{
    public interface ICreatableEntity
    {
        DateTimeOffset CreatedAt { get; set; }
        string CreatedBy { get; set; }
    }
}
