using SM.People.Core.Domain.Entities;
using SM.Resource.Data;

namespace SM.People.Core.Application.Interfaces.Repositories.Domain
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetAllCustomer();
        Task<Customer> GetCustomerById(Guid id);
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> UpdateCustomer(Customer customer);
    }
}
