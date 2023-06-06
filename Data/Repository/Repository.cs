using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace OnlineShoppingStore.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected OnlineShoppingStoreContext Context { get; set; }

        public Repository(OnlineShoppingStoreContext context)
        {
            Context = context;
        }

        public virtual void Insert(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).SingleOrDefault();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().AsEnumerable();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>()
                .Where(predicate)
                .AsNoTracking()
                .AsEnumerable();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.Where(predicate).AsEnumerable();
        }

        public virtual TEntity GetById(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefault();
        }

        public int CountWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>()
                 .Where(predicate)
                 .Count();
        }

        public int Count()
        {
            return Context.Set<TEntity>().Count();
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(string currentUserEmail, CancellationToken cancellationToken = default)
        {
            return await Context.SaveChangesAsync(cancellationToken);
        }
    }
}