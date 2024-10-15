namespace PMS.Shared.Contracts.Models
{
    public interface IUpdatableEntity
    {
        DateTime? UpdatedAt { get; set; }
        string? UpdatedBy { get; set; }
    }
}
