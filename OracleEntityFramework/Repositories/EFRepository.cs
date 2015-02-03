using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace OracleEntityFramework.Repositories
{
    public class EFRepository<TEntity> : IEFRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> dbSet;

        public EFRepository(DbSet<TEntity> dbSet)
        {
            this.dbSet = dbSet;
        }

        #region implementation

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void AttachForUpdate(TEntity entity)
        {
            dbSet.Attach(entity);
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return BuildQuery(predicate);
        }

        public TEntity FindSingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return BuildQuery(predicate).SingleOrDefault();
        }

        public TEntity FindFirst(Expression<Func<TEntity, bool>> predicate)
        {
            return BuildQuery(predicate).First();
        }

        public TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        private IQueryable<TEntity> BuildQuery(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate);
            // TODO:  add any includes?
        }

        #endregion
    }
}
