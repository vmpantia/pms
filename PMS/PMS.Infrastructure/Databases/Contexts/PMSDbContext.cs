using Microsoft.EntityFrameworkCore;
using PMS.Shared.Models.Entities;
using PMS.Shared.Models.Enums;
using PMS.Shared.Stubs;

namespace PMS.Infrastructure.Databases.Contexts
{
    public class PMSDbContext : DbContext
    {
        private readonly List<WorkItem> _fakeWorkItems;

        public PMSDbContext(DbContextOptions options) : base(options)
        {
            _fakeWorkItems = FakeData.WorkItem()
                                     .Generate(100);
        }

        public DbSet<WorkItem> WorkItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkItem>(enty =>
            {
                enty.HasQueryFilter(wi => wi.Status != WorkItemStatus.Deleted);
                enty.HasIndex(wi => new { wi.Title, wi.OwnerId, wi.AssigneeId, wi.Type, wi.Status, wi.CreatedAt, wi.CreatedBy });
                enty.HasData(_fakeWorkItems);
            });
        }
    }
}
