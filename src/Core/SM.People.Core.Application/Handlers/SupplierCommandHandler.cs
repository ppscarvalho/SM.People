using AutoMapper;
using MediatR;
using SM.People.Core.Application.Commands.Supplier;
using SM.People.Core.Application.Interfaces.Repositories.Domain;
using SM.People.Core.Application.Models;
using SM.People.Core.Domain.Entities;
using SM.Resource.Communication.Mediator;
using SM.Resource.Messagens;
using SM.Resource.Messagens.CommonMessage.Notifications;
using SM.Resource.Util;

namespace SM.People.Core.Application.Handlers
{
    public class SupplierCommandHandler :
    IRequestHandler<AddSupplierCommand, DefaultResult>,
        IRequestHandler<UpdateSupplierCommand, DefaultResult>
    {
        private readonly ISupplierRepository _SupplierRepository;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;

        public SupplierCommandHandler(
            ISupplierRepository SupplierRepository,
            IMediatorHandler mediatorHandler,
            IMapper mapper)
        {
            _SupplierRepository = SupplierRepository;
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
        }

        public async Task<DefaultResult> Handle(AddSupplierCommand request, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(request)) return new DefaultResult { Result = "Error", Success = false };

            var categoria = _mapper.Map<Supplier>(request);
            var entity = _mapper.Map<SupplierModel>(await _SupplierRepository.AddSupplier(categoria));

            var result = await _SupplierRepository.UnitOfWork.Commit();

            return new DefaultResult { Result = entity, Success = result };
        }

        public async Task<DefaultResult> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(request)) return new DefaultResult { Result = "Error", Success = false };

            var categoria = _mapper.Map<Supplier>(request);
            var entity = _mapper.Map<SupplierModel>(await _SupplierRepository.UpdateSupplier(categoria));

            var result = await _SupplierRepository.UnitOfWork.Commit();

            return new DefaultResult { Result = entity, Success = result };
        }

        private bool ValidateCommand(CommandHandler message)
        {
            if (message.IsValid()) return true;

            foreach (var error in message.ValidationResult.Errors)
                _mediatorHandler.PublishNotification(new DomainNotification(message.MessageType, error.ErrorMessage));

            return false;
        }
    }
}
