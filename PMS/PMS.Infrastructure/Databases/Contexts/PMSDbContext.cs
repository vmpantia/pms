using Microsoft.EntityFrameworkCore;
using PMS.Shared.Models.Entities;
using PMS.Shared.Models.Enums;

namespace PMS.Infrastructure.Databases.Contexts
{
    public class PMSDbContext : DbContext
    {
        public PMSDbContext(DbContextOptions options) : base(options) { }

        public DbSet<WorkItem> WorkItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkItem>(enty =>
            {
                enty.HasQueryFilter(wi => wi.Status != WorkItemStatus.Deleted);
                enty.HasIndex(wi => new { wi.Title, wi.OwnerId, wi.AssigneeId, wi.Type, wi.Status, wi.CreatedAt, wi.CreatedBy });
            });
        }
    }
}
