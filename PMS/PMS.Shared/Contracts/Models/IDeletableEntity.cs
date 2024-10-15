namespace PMS.Shared.Contracts.Models
{
    public interface IDeletableEntity
    {
        DateTime? DeletedAt { get; set; }
        string? DeletedBy { get; set; }
    }
}
