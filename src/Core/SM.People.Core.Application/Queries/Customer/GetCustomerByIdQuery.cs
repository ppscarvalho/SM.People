using MediatR;
using SM.People.Core.Application.Models;

namespace SM.People.Core.Application.Queries.Customer
{
    public class GetCustomerByIdQuery : IRequest<CustomerModel>
    {
        public Guid Id { get; private set; }

        public GetCustomerByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
