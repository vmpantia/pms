using PMS.Shared.Models.Dtos;

namespace PMS.Web.Contracts
{
    public interface IPMSService
    {
        Task<IEnumerable<WorkItemDto>> GetWorkItemsAsync(CancellationToken cancellationToken = default);
    }
}
