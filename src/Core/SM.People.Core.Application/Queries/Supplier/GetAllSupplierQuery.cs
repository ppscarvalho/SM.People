using MediatR;
using SM.People.Core.Application.Models;

namespace SM.People.Core.Application.Queries.Supplier
{
    public class GetAllSupplierQuery : IRequest<IEnumerable<SupplierModel>>
    {
    }
}
