using AutoMapper;
using MediatR;
using SM.People.Core.Application.Interfaces.Repositories.Domain;
using SM.People.Core.Application.Models;

namespace SM.People.Core.Application.Queries.Customer
{
    public class CustomerQueryHandler :
        IRequestHandler<GetCustomerByIdQuery, CustomerModel>,
        IRequestHandler<GetAllCustomerQuery, IEnumerable<CustomerModel>>
    {
        private readonly ICustomerRepository _CustomerRepository;
        private readonly IMapper _mapper;
        public CustomerQueryHandler(ICustomerRepository categoryRepository, IMapper mapper)
        {
            _CustomerRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomerModel> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
        {
            return _mapper.Map<CustomerModel>(await _CustomerRepository.GetCustomerById(query.Id));
        }

        public async Task<IEnumerable<CustomerModel>> Handle(GetAllCustomerQuery query, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<CustomerModel>>(await _CustomerRepository.GetAllCustomer());
        }
    }
}
