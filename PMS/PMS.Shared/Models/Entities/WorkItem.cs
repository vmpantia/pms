using PMS.Shared.Contracts.Models;
using PMS.Shared.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PMS.Shared.Models.Entities
{
    public class WorkItem : IAuditableEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        public Guid? AssigneeId { get; set; }

        [Required]
        public WorkItemType Type { get; set; }

        [Required]
        public WorkItemStatus Status { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTimeOffset? DeletedAt { get; set; }

        public string? DeletedBy { get; set; }
    }
}
