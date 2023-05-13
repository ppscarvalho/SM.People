using MediatR;
using SM.People.Core.Application.Models;

namespace SM.People.Core.Application.Queries.Supplier
{
    public class GetSupplierByIdQuery : IRequest<SupplierModel>
    {
        public Guid Id { get; private set; }

        public GetSupplierByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
