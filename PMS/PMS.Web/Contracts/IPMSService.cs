using PMS.Shared.Models.Dtos;
using PMS.Shared.Models.Results;

namespace PMS.Web.Contracts
{
    public interface IPMSService
    {
        Task<Result<IEnumerable<WorkItemDto>>> GetWorkItemsAsync(CancellationToken cancellationToken = default);
    }
}
