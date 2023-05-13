using Microsoft.EntityFrameworkCore;
using SM.People.Core.Application.Interfaces.Repositories.Domain;
using SM.People.Core.Domain.Entities;
using SM.People.Infrastructure.DbContexts;
using SM.Resource.Data;

namespace SM.People.Infrastructure.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly PeopleDbContext _context;
        private bool disposedValue;

        public SupplierRepository(PeopleDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Supplier>> GetAllSupplier()
        {
            return await _context.Supplier.AsNoTracking().ToListAsync();
        }

        public async Task<Supplier> GetSupplierById(Guid id)
        {
            return await _context.Supplier.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Supplier> AddSupplier(Supplier Supplier)
        {
            return (await _context.AddAsync(Supplier)).Entity;
        }

        public async Task<Supplier> UpdateSupplier(Supplier Supplier)
        {
            await Task.CompletedTask;
            return (_context.Supplier.Update(Supplier)).Entity;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context?.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
