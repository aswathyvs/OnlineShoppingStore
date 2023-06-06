using System.Linq.Expressions;

namespace OnlineShoppingStore.Data.Repository
{
    public interface IRepository<TEntity>
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        TEntity GetById(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        int CountWhere(Expression<Func<TEntity, bool>> predicate);
        int Count();
        void Save();
        Task<int> SaveChangesAsync(string currentUserEmail, CancellationToken cancellationToken = default);
    }
}
