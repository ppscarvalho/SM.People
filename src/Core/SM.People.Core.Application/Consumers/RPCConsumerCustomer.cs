#nullable disable

using AutoMapper;
using MediatR;
using SM.MQ.Models;
using SM.MQ.Models.Customer;
using SM.MQ.Operators;
using SM.People.Core.Application.Commands.Customer;
using SM.People.Core.Application.Models;
using SM.People.Core.Application.Queries.Customer;
using SM.Resource.Communication.Mediator;
using SM.Resource.Messagens.CommonMessage.Notifications;
using SM.Util.Extensions;

namespace SM.People.Core.Application.Consumers
{
    public class RPCConsumerCustomer : Consumer<RequestIn>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;
        private readonly IMediator _mediatorQuery;
        private readonly DomainNotificationHandler _notifications;

        public RPCConsumerCustomer(
            IMapper mapper,
            IMediatorHandler mediatorHandler,
            INotificationHandler<DomainNotification> notifications,
            IMediator mediatorQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _notifications = (DomainNotificationHandler)notifications;
            _mediatorQuery = mediatorQuery;
        }

        public override async Task ConsumeContex(ConsumerContext<RequestIn> context)
        {
            switch (context.Message.Queue)
            {
                case "GetCustomerById":
                    await GetCustomerById(context);
                    break;

                case "GetAllCustomer":
                    await GetAllCustomer(context);
                    break;

                case "AddCustomer":
                    await AddCustomer(context);
                    break;

                case "UpdateCustomer":
                    await UpdateCustomer(context);
                    break;

                default:
                    await GetAllCustomer(context);
                    break;
            }
        }

        private async Task GetCustomerById(ConsumerContext<RequestIn> context)
        {
            var id = Guid.Parse(context.Message.Result);
            var query = new GetCustomerByIdQuery(id);
            var result = _mapper.Map<ResponseCustomerOut>(await _mediatorQuery.Send(query));
            await context.RespondAsync(result);
        }
        private async Task GetAllCustomer(ConsumerContext<RequestIn> context)
        {
            var result = _mapper.Map<IEnumerable<ResponseCustomerOut>>(await _mediatorQuery.Send(new GetAllCustomerQuery()));
            await context.RespondAsync(result.ToArray());
        }

        private async Task AddCustomer(ConsumerContext<RequestIn> context)
        {
            var CustomerModel = context.Message.Result.DeserializeObject<CustomerModel>();

            var command = _mapper.Map<AddCustomerCommand>(CustomerModel);
            var result = await _mediatorHandler.SendCommand(command);

            if (result.Success)
            {
                await context.RespondAsync(new ResponseOut { Success = result.Success });
            }
            else if (!_notifications.ExistNotification())
            {
                await context.RespondAsync(new ResponseOut { Success = result.Success });
            }
        }

        private async Task UpdateCustomer(ConsumerContext<RequestIn> context)
        {
            var categoriaModel = context.Message.Result.DeserializeObject<CustomerModel>();

            var command = _mapper.Map<UpdateCustomerCommand>(categoriaModel);
            var result = await _mediatorHandler.SendCommand(command);

            if (result.Success)
            {
                await context.RespondAsync(new ResponseOut { Success = result.Success });
            }
            else if (!_notifications.ExistNotification())
            {
                await context.RespondAsync(new ResponseOut { Success = result.Success });
            }
        }
    }
}
