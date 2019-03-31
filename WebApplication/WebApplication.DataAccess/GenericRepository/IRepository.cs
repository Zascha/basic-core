using System;
using System.Collections.Generic;
using WebApplication.Common;

namespace WebApplication.DataAccess.GenericRepository
{
    public interface IRepository<T> where T : class, IEntity
    {
        T GetById(int id);

        IEnumerable<T> GetByPredicate(Func<T, bool> predicate);

        int Create(T entity);

        void CreateRange(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

        void Remove(int id);

        void Remove(T entity);

        void RemoveRange(IEnumerable<int> ids);

        void RemoveRange(IEnumerable<T> entities);
    }
}
