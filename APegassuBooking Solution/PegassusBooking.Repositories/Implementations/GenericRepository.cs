using Microsoft.EntityFrameworkCore;
using PegassusBooking.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PegassusBooking.Repositories.Implementations
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class 
    {
        private readonly ApplicationDBContext _context;
        internal DbSet<T> dbSet;

        public GenericRepository(ApplicationDBContext context)
        {
            _context = context;
            dbSet =_context.Set<T>();
        }

        public void Add(T entity) 
        {
            dbSet.Add(entity);
        }
        public async Task<T> AddAsync(T entity)
        {
            dbSet.Add(entity);
            return entity;
        }
        public void Delete(T entity) 
        {
            if (_context.Entry(entity).State == EntityState.Detached) 
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
        public async Task<T> DeleteAsync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
            return entity;
        }
        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing) 
        {
            if (!this._disposed) 
            {
                if (disposing) 
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            string includeProperties = "")
        {
            IQueryable<T> query = dbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in 
                includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries)) 
            {
                query = query.Include(includeProperty);
            }
            if (orderby != null)
            {
                return orderby(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = dbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.ToList();
        }
    }
}
