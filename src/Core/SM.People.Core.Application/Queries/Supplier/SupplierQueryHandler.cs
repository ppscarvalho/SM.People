using AutoMapper;
using MediatR;
using SM.People.Core.Application.Interfaces.Repositories.Domain;
using SM.People.Core.Application.Models;

namespace SM.People.Core.Application.Queries.Supplier
{
    public class SupplierQueryHandler :
        IRequestHandler<GetSupplierByIdQuery, SupplierModel>,
        IRequestHandler<GetAllSupplierQuery, IEnumerable<SupplierModel>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        public SupplierQueryHandler(ISupplierRepository categoryRepository, IMapper mapper)
        {
            _supplierRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<SupplierModel> Handle(GetSupplierByIdQuery query, CancellationToken cancellationToken)
        {
            return _mapper.Map<SupplierModel>(await _supplierRepository.GetSupplierById(query.Id));
        }

        public async Task<IEnumerable<SupplierModel>> Handle(GetAllSupplierQuery query, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<SupplierModel>>(await _supplierRepository.GetAllSupplier());
        }
    }
}
