using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SM.Catalog.Apresentation.Api.Controllers.BaseController;
using SM.People.Core.Application.Commands.Supplier;
using SM.People.Core.Application.Models;
using SM.People.Core.Application.Queries.Supplier;
using SM.Resource.Communication.Mediator;
using SM.Resource.Messagens.CommonMessage.Notifications;
using SM.Resource.Util;

namespace SM.Catalog.Apresentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerConfiguration
    {
        private readonly ILogger<SupplierController> _logger;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;
        private readonly IMediator _mediatorQuery;

        public SupplierController(
            ILogger<SupplierController> logger,
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
        [Route("GetSupplierById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(SupplierModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSupplierById([FromBody] GetSupplierByIdQuery query)
        {
            _logger.LogInformation("Obter todas as categorias");
            var result = await _mediatorQuery.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllSupplier")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(SupplierModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllSupplier()
        {
            _logger.LogInformation("Obter todas as categorias");
            var result = await _mediatorQuery.Send(new GetAllSupplierQuery());
            return Ok(result);
        }

        [HttpPost]
        [Route("AddSupplier")]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DefaultResult>> SaveSupplier([FromBody] SupplierModel SupplierModel)
        {
            var cmd = _mapper.Map<AddSupplierCommand>(SupplierModel);
            var result = await _mediatorHandler.SendCommand(cmd);

            if (ValidOperation())
                return Ok(result);
            else
                return BadRequest(GetMessageError());
        }

        [HttpPost]
        [Route("UpdateSupplier")]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DefaultResult>> UpdateSupplier([FromBody] SupplierModel SupplierModel)
        {
            var cmd = _mapper.Map<UpdateSupplierCommand>(SupplierModel);
            var result = await _mediatorHandler.SendCommand(cmd);

            if (ValidOperation())
                return Ok(result);
            else
                return BadRequest(GetMessageError());
        }
    }
}
