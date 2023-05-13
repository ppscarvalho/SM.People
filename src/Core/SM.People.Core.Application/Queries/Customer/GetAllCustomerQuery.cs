using MediatR;
using SM.People.Core.Application.Models;

namespace SM.People.Core.Application.Queries.Customer
{
    public class GetAllCustomerQuery : IRequest<IEnumerable<CustomerModel>>
    {
    }
}
