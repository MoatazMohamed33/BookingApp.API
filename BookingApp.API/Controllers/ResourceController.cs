using BookingApp.Application.Common.Responses;
using BookingApp.Application.Components.Resources.Get;
using BookingApp.Application.Components.Resources.GetAll;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace BookingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : CoreController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OutputResponse<ResourceGetQueryResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(OutputResponse<object>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var query = new ResourceGetQuery { Id = id };
            var result = await Mediator.Send(query);
            return ReturnResult(result);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(OutputResponse<ResourceGetAllQueryResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(OutputResponse<object>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            var query = new ResourceGetAllQuery ();
            var result = await Mediator.Send(query);
            return ReturnResult(result);
        }
    }
}
