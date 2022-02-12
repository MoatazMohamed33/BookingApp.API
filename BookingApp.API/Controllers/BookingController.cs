using BookingApp.Application.Common.Responses;
using BookingApp.Application.Components.Bookings.Book;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : CoreController
    {
        [HttpPut("book")]
        [ProducesResponseType(typeof(OutputResponse<BookCommandResult>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(OutputResponse<>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Book(BookCommand command)
        {
            var result = await Mediator.Send(command);
            return ReturnResult(result);
        }
    }
}
