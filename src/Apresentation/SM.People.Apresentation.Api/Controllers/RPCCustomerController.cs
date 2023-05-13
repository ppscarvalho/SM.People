using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SM.MQ.Models;
using SM.MQ.Models.Customer;
using SM.MQ.Operators;
using SM.People.Core.Application.Models;
using SM.People.Core.Application.Queries.Customer;

namespace SM.Catalog.Apresentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RPCCustomerController : ControllerBase
    {
        private readonly IPublish _publish;

        public RPCCustomerController(IPublish publish)
        {
            _publish = publish;
        }

        [HttpPost]
        [Route("GetCustomerById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ResponseCustomerOut), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCustomerById([FromBody] GetCustomerByIdQuery query)
        {
            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = query.Id.ToString(),
                Queue = "GetCustomerById"
            };

            var result = await _publish.DoRPC<RequestIn, ResponseCustomerOut>(mapIn);
            return Ok(result);
        }

        [HttpPost]
        [Route("GetAllCustomer")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ResponseCustomerOut), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCustomer()
        {
            var mapIn = new RequestIn
            {
                Host = "localhost",
                Queue = "GetAllCustomer"
            };

            var result = await _publish.DoRPC<RequestIn, ResponseCustomerOut[]>(mapIn);
            return Ok(result);
        }

        [HttpPost]
        [Route("AddCustomer")]
        [ProducesResponseType(typeof(ResponseOut), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseOut), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseOut), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseOut>> AddCustomer([FromBody] CustomerModel CustomerModel)
        {
            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = JsonConvert.SerializeObject(CustomerModel),
                Queue = "AddCustomer"
            };

            var response = await _publish.DoRPC<RequestIn, ResponseOut>(mapIn);
            return response;
        }

        [HttpPost]
        [Route("UpdateCustomer")]
        [ProducesResponseType(typeof(ResponseOut), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseOut), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseOut), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseOut>> UpdateCustomer([FromBody] CustomerModel CustomerModel)
        {
            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = JsonConvert.SerializeObject(CustomerModel),
                Queue = "UpdateCustomer"
            };

            var response = await _publish.DoRPC<RequestIn, ResponseOut>(mapIn);
            return response;
        }
    }
}
