using SM.People.Core.Domain.Entities;
using SM.Resource.Data;

namespace SM.People.Core.Application.Interfaces.Repositories.Domain
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<IEnumerable<Supplier>> GetAllSupplier();
        Task<Supplier> GetSupplierById(Guid id);
        Task<Supplier> AddSupplier(Supplier supplier);
        Task<Supplier> UpdateSupplier(Supplier supplier);
    }
}
