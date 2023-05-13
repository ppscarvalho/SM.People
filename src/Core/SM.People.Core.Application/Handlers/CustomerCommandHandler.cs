using AutoMapper;
using MediatR;
using SM.People.Core.Application.Commands.Customer;
using SM.People.Core.Application.Interfaces.Repositories.Domain;
using SM.People.Core.Application.Models;
using SM.People.Core.Domain.Entities;
using SM.Resource.Communication.Mediator;
using SM.Resource.Messagens;
using SM.Resource.Messagens.CommonMessage.Notifications;
using SM.Resource.Util;

namespace SM.People.Core.Application.Handlers
{
    public class CustomerCommandHandler :
       IRequestHandler<AddCustomerCommand, DefaultResult>,
           IRequestHandler<UpdateCustomerCommand, DefaultResult>
    {
        private readonly ICustomerRepository _CustomerRepository;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;

        public CustomerCommandHandler(
            ICustomerRepository CustomerRepository,
            IMediatorHandler mediatorHandler,
            IMapper mapper)
        {
            _CustomerRepository = CustomerRepository;
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
        }

        public async Task<DefaultResult> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(request)) return new DefaultResult { Result = "Error", Success = false };

            var categoria = _mapper.Map<Customer>(request);
            var entity = _mapper.Map<CustomerModel>(await _CustomerRepository.AddCustomer(categoria));

            var result = await _CustomerRepository.UnitOfWork.Commit();

            return new DefaultResult { Result = entity, Success = result };
        }

        public async Task<DefaultResult> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(request)) return new DefaultResult { Result = "Error", Success = false };

            var categoria = _mapper.Map<Customer>(request);
            var entity = _mapper.Map<CustomerModel>(await _CustomerRepository.UpdateCustomer(categoria));

            var result = await _CustomerRepository.UnitOfWork.Commit();

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
