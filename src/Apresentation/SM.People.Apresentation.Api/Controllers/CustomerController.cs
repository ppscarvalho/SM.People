using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SM.Catalog.Apresentation.Api.Controllers.BaseController;
using SM.People.Core.Application.Commands.Customer;
using SM.People.Core.Application.Models;
using SM.People.Core.Application.Queries.Customer;
using SM.Resource.Communication.Mediator;
using SM.Resource.Messagens.CommonMessage.Notifications;
using SM.Resource.Util;

namespace SM.Catalog.Apresentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerConfiguration
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;
        private readonly IMediator _mediatorQuery;

        public CustomerController(
            ILogger<CustomerController> logger,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            IMapper mapper,
            IMediator mediatorQuery) : base(notifications, mediatorHandler)
        {
            _logger = logger;
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
            _mediatorQuery = mediatorQuery;
        }

        [HttpPost]
        [Route("GetCustomerById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CustomerModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCustomerById([FromBody] GetCustomerByIdQuery query)
        {
            _logger.LogInformation("Obter todas as categorias");
            var result = await _mediatorQuery.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [Route("GetAllCustomer")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CustomerModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCustomer()
        {
            _logger.LogInformation("Obter todas as categorias");
            var result = await _mediatorQuery.Send(new GetAllCustomerQuery());
            return Ok(result);
        }

        [HttpPost]
        [Route("AddCustomer")]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DefaultResult>> SaveCustomer([FromBody] CustomerModel CustomerModel)
        {
            var cmd = _mapper.Map<AddCustomerCommand>(CustomerModel);
            var result = await _mediatorHandler.SendCommand(cmd);

            if (ValidOperation())
                return Ok(result);
            else
                return BadRequest(GetMessageError());
        }

        [HttpPost]
        [Route("UpdateCustomer")]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DefaultResult>> UpdateCustomer([FromBody] CustomerModel CustomerModel)
        {
            var cmd = _mapper.Map<UpdateCustomerCommand>(CustomerModel);
            var result = await _mediatorHandler.SendCommand(cmd);

            if (ValidOperation())
                return Ok(result);
            else
                return BadRequest(GetMessageError());
        }
    }
}
