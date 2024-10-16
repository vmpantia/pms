using System.Linq.Expressions;

namespace PMS.Shared.Contracts.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        IQueryable<TEntity> Get();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
