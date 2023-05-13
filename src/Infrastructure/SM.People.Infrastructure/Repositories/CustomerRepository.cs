#nullable disable

using Microsoft.EntityFrameworkCore;
using SM.People.Core.Application.Interfaces.Repositories.Domain;
using SM.People.Core.Domain.Entities;
using SM.People.Infrastructure.DbContexts;
using SM.Resource.Data;

namespace SM.People.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly PeopleDbContext _context;
        private bool disposedValue;

        public CustomerRepository(PeopleDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await _context.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<Customer> GetCustomerById(Guid id)
        {
            return await _context.Customers.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Customer> AddCustomer(Customer Customer)
        {
            return (await _context.AddAsync(Customer)).Entity;
        }

        public async Task<Customer> UpdateCustomer(Customer Customer)
        {
            await Task.CompletedTask;
            return (_context.Customers.Update(Customer)).Entity;
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
