using MediatR;
using PMS.Shared.Models.Dtos;
using PMS.Shared.Models.Enums;
using PMS.Shared.Models.Results;

namespace PMS.Core.Commands.Models
{
    public sealed class CreateWorkItemCommand : IRequest<Result<WorkItemDto>>
    {
        public CreateWorkItemCommand(SaveWorkItemDto dto, string requestor = "System")
        {
            Title = dto.Title.Trim();
            Description = dto.Description?.Trim();
            OwnerId = dto.OwnerId;
            AssigneeId = dto.AssigneeId;
            Type = dto.Type;
            Status = dto.Status;
            StartDate = dto.StartDate?.Date;
            EndDate = dto.EndDate?.Date;
            Requestor = requestor.Trim();
        }

        public string Title { get; init; }
        public string? Description { get; init; }
        public Guid OwnerId { get; init; }
        public Guid? AssigneeId { get; init; }
        public WorkItemType Type { get; init; }
        public WorkItemStatus Status { get; init; }
        public DateTime? StartDate { get; init; }
        public DateTime? EndDate { get; init; }
        public string Requestor { get; init; }
    }
}
