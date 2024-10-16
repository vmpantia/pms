using PMS.Shared.Models.Entities;
using System.Linq.Expressions;

namespace PMS.Shared.Contracts.Repositories
{
    public interface IWorkItemRepository : IBaseRepository<WorkItem>
    {
        Task<IEnumerable<WorkItem>> GetWorkItemsAsync(
            Expression<Func<WorkItem, bool>>? expression = null, 
            CancellationToken cancellationToken = default);

        Task CreateWorkItemAsync(
            WorkItem workItem, 
            CancellationToken cancellationToken = default);
    }
}
