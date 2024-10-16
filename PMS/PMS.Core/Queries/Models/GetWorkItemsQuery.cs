using MediatR;
using PMS.Shared.Models.Dtos;

namespace PMS.Core.Queries.Models
{
    public sealed record GetWorkItemsQuery() : IRequest<IEnumerable<WorkItemDto>> { }
}
