using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Common;

namespace WebApplication.DataAccess.GenericRepository
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public T GetById(int id)
        {
            using (_context)
            {
                return _context.Set<T>().FirstOrDefault(e => e.Id == id);
            }
        }

        public IEnumerable<T> GetByPredicate(Func<T, bool> predicate)
        {
            using (_context)
            {
                return _context.Set<T>().Where(predicate);
            }
        }

        public int Create(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            using (_context)
            {
                _context.Attach(entity);
                _context.SaveChanges();

                return entity.Id;
            }
        }

        public void CreateRange(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            if (!entities.Any())
            {
                return;
            }

            using (_context)
            {
                _context.Attach(entities);
                _context.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            using (_context)
            {
                var entity = _context.Set<T>().FirstOrDefault(e => e.Id == id);

                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            using (_context)
            {
                _context.Attach(entity);
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
        }

        public void RemoveRange(IEnumerable<int> ids)
        {
            if (ids == null)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            if (!ids.Any())
            {
                return;
            }

            using (_context)
            {
                var entitiesToRemove = _context.Set<T>().Where(e => ids.Contains(e.Id));

                _context.Set<T>().RemoveRange(entitiesToRemove);
                _context.SaveChanges();
            }
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            if (!entities.Any())
            {
                return;
            }

            using (_context)
            {
                _context.Attach(entities);
                _context.Set<T>().RemoveRange(entities);
                _context.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            using (_context)
            {
                _context.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            if (!entities.Any())
            {
                return;
            }

            using (_context)
            {
                _context.Attach(entities);
                _context.Entry(entities).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
