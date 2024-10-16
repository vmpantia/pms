namespace PMS.Shared.Contracts.Models
{
    public interface IUpdatableEntity
    {
        DateTimeOffset? UpdatedAt { get; set; }
        string? UpdatedBy { get; set; }
    }
}
