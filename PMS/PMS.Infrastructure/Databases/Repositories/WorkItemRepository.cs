using Microsoft.EntityFrameworkCore;
using PMS.Infrastructure.Databases.Contexts;
using PMS.Shared.Contracts.Repositories;
using PMS.Shared.Models.Entities;
using System.Linq.Expressions;

namespace PMS.Infrastructure.Databases.Repositories
{
    public class WorkItemRepository : BaseRepository<WorkItem>, IWorkItemRepository
    {
        public WorkItemRepository(PMSDbContext context) : base(context) { }

        public async Task<IEnumerable<WorkItem>> GetWorkItemsAsync(Expression<Func<WorkItem, bool>>? expression = null, CancellationToken cancellationToken = default)
        {
            if(expression is null) 
                return await Get()
                    .ToListAsync(cancellationToken);

            return await Get(expression)
                .ToListAsync(cancellationToken);
        }
    }
}
