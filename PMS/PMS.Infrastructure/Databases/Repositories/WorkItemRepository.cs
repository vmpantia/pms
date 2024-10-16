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

        public async Task<IEnumerable<WorkItem>> GetWorkItemsAsync(
            Expression<Func<WorkItem, bool>>? expression = null, 
            CancellationToken cancellationToken = default)
        {
            if(expression is null) 
                return await base.Get()
                    .ToListAsync(cancellationToken);

            return await base.Get(expression)
                .ToListAsync(cancellationToken);
        }

        public async Task<WorkItem?> GetWorkItemAsync(
            Expression<Func<WorkItem, bool>> expression,
            CancellationToken cancellationToken = default) =>
            await base.Get(expression)
                      .SingleOrDefaultAsync(cancellationToken);

        public async Task CreateWorkItemAsync(
            WorkItem workItem,
            CancellationToken cancellationToken = default)
        {
            base.Create(workItem);
            await _context.SaveChangesAsync(cancellationToken);
        }
        
        public async Task UpdateWorkItemAsync(
            WorkItem workItem,
            CancellationToken cancellationToken = default)
        {
            base.Update(workItem);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
