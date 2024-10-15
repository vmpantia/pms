using Microsoft.EntityFrameworkCore;
using PMS.Infrastructure.Databases.Contexts;
using PMS.Shared.Contracts.Repositories;
using System.Linq.Expressions;

namespace PMS.Infrastructure.Databases.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        protected readonly PMSDbContext _context;
        protected readonly DbSet<TEntity> _table;

        public BaseRepository(PMSDbContext context)
        {
            _context = context;
            _table = context.Set<TEntity>();
        }

        public IQueryable<TEntity> Get() => _table;

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression) => _table.Where(expression);

        public void Add(TEntity entity) => _table.Add(entity);

        public void Update(TEntity entity) => _table.Update(entity);

        public void Delete(TEntity entity) => _table.Remove(entity);
    }
}
