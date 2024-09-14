using Microsoft.EntityFrameworkCore;
using PegassusBooking.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegassusBooking.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDBContext _context;

        public UnitOfWork(ApplicationDBContext context) 
        {
            _context = context;
        }

        private bool _disposed;

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

        public IGenericRepository<T> GenericRepository<T>() where T : class 
        {
            IGenericRepository<T> repo = new GenericRepository<T>(_context);
            return repo;
        }
        public void Save()
        {
            _context.SaveChanges(); 
        }
    }
}
