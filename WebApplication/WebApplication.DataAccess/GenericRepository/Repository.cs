using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WebApplication.Common;

namespace WebApplication.DataAccess.GenericRepository
{
    // TODO: add raising events
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int Create(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            using (_context)
            {
                throw NotImplementedException();
            }
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetByPredicate(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
