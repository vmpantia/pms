using MediatR;
using PMS.Shared.Models.Dtos;
using PMS.Shared.Models.Results;

namespace PMS.Core.Queries.Models
{
    public sealed record GetWorkItemByIdQuery(Guid Id) : IRequest<Result<WorkItemDto>> { }
}
