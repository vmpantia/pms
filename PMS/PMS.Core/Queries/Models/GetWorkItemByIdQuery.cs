using MediatR;
using PMS.Shared.Models.Dtos;

namespace PMS.Core.Queries.Models
{
    public sealed record GetWorkItemByIdQuery(Guid Id) : IRequest<WorkItemDto> { }
}
