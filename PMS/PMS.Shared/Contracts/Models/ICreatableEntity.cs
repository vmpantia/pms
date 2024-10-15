namespace PMS.Shared.Contracts.Models
{
    public interface ICreatableEntity
    {
        DateTime CreatedAt { get; set; }
        string CreatedBy { get; set; }
    }
}
