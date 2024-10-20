using MediatR;
using PMS.Shared.Models.Dtos;
using PMS.Shared.Models.Results;

namespace PMS.Core.Queries.Models
{
    public sealed record GetWorkItemsQuery() : IRequest<Result<IEnumerable<WorkItemDto>>> { }
}
