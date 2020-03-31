 using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace UnitOfWork
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(TEntity entityToDelete);

        void Delete(object id);

        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            string includeProperties = "");

   //     IEnumerable<TEntity> GetListPagination(int index, int size);
       

        TEntity GetByID(object id);

        //IEnumerable<TEntity> GetWithRawSql(string query,
        //    params object[] parameters);
        void Insert(TEntity entity);

        TEntity InsertData(TEntity entity);

        void Update(TEntity entityToUpdate);


    }
}