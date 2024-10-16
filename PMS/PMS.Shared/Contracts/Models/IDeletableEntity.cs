namespace PMS.Shared.Contracts.Models
{
    public interface IDeletableEntity
    {
        DateTimeOffset? DeletedAt { get; set; }
        string? DeletedBy { get; set; }
    }
}
