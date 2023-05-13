#nullable disable

using AutoMapper;
using MediatR;
using SM.MQ.Models;
using SM.MQ.Models.Supplier;
using SM.MQ.Operators;
using SM.People.Core.Application.Commands.Supplier;
using SM.People.Core.Application.Models;
using SM.People.Core.Application.Queries.Supplier;
using SM.Resource.Communication.Mediator;
using SM.Resource.Messagens.CommonMessage.Notifications;
using SM.Util.Extensions;

namespace SM.People.Core.Application.Consumers
{
    public class RPCConsumerSupplier : Consumer<RequestIn>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;
        private readonly IMediator _mediatorQuery;
        private readonly DomainNotificationHandler _notifications;

        public RPCConsumerSupplier(
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
                case "GetSupplierById":
                    await GetSupplierById(context);
                    break;

                case "GetAllSupplier":
                    await GetAllSupplier(context);
                    break;

                case "AddSupplier":
                    await AddSupplier(context);
                    break;

                case "UpdateSupplier":
                    await UpdateSupplier(context);
                    break;

                default:
                    await GetAllSupplier(context);
                    break;
            }
        }


        private async Task GetSupplierById(ConsumerContext<RequestIn> context)
        {
            var id = Guid.Parse(context.Message.Result);
            var query = new GetSupplierByIdQuery(id);
            var result = _mapper.Map<ResponseSupplierOut>(await _mediatorQuery.Send(query));
            await context.RespondAsync(result);
        }
        private async Task GetAllSupplier(ConsumerContext<RequestIn> context)
        {
            var result = _mapper.Map<IEnumerable<ResponseSupplierOut>>(await _mediatorQuery.Send(new GetAllSupplierQuery()));
            await context.RespondAsync(result.ToArray());
        }

        private async Task AddSupplier(ConsumerContext<RequestIn> context)
        {
            var SupplierModel = context.Message.Result.DeserializeObject<SupplierModel>();

            var command = _mapper.Map<AddSupplierCommand>(SupplierModel);
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

        private async Task UpdateSupplier(ConsumerContext<RequestIn> context)
        {
            var categoriaModel = context.Message.Result.DeserializeObject<SupplierModel>();

            var command = _mapper.Map<UpdateSupplierCommand>(categoriaModel);
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
