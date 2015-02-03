using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OracleEntityFramework.Repositories
{
    public interface IEFRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void AttachForUpdate(TEntity entity);

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity FindSingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity FindFirst(Expression<Func<TEntity, bool>> predicate);


        TEntity GetById(int id);
    }
}
