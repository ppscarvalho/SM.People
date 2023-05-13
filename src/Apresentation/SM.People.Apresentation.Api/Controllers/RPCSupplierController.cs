using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SM.MQ.Models;
using SM.MQ.Models.Supplier;
using SM.MQ.Operators;
using SM.People.Core.Application.Models;
using SM.People.Core.Application.Queries.Supplier;

namespace SM.Catalog.Apresentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RPCSupplierController : ControllerBase
    {
        private readonly IPublish _publish;

        public RPCSupplierController(IPublish publish)
        {
            _publish = publish;
        }

        [HttpPost]
        [Route("GetSupplierById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ResponseSupplierOut), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSupplierById([FromBody] GetSupplierByIdQuery query)
        {
            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = query.Id.ToString(),
                Queue = "GetSupplierById"
            };

            var result = await _publish.DoRPC<RequestIn, ResponseSupplierOut>(mapIn);
            return Ok(result);
        }

        [HttpPost]
        [Route("GetAllSupplier")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ResponseSupplierOut), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllSupplier()
        {
            var mapIn = new RequestIn
            {
                Host = "localhost",
                Queue = "GetAllSupplier"
            };

            var result = await _publish.DoRPC<RequestIn, ResponseSupplierOut[]>(mapIn);
            return Ok(result);
        }

        [HttpPost]
        [Route("AddSupplier")]
        [ProducesResponseType(typeof(ResponseOut), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseOut), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseOut), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseOut>> AddSupplier([FromBody] SupplierModel SupplierModel)
        {
            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = JsonConvert.SerializeObject(SupplierModel),
                Queue = "AddSupplier"
            };

            var response = await _publish.DoRPC<RequestIn, ResponseOut>(mapIn);
            return response;
        }

        [HttpPost]
        [Route("UpdateSupplier")]
        [ProducesResponseType(typeof(ResponseOut), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseOut), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseOut), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseOut>> UpdateSupplier([FromBody] SupplierModel SupplierModel)
        {
            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = JsonConvert.SerializeObject(SupplierModel),
                Queue = "UpdateSupplier"
            };

            var response = await _publish.DoRPC<RequestIn, ResponseOut>(mapIn);
            return response;
        }
    }
}
