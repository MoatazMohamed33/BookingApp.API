using BookingApp.Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Components.Bookings.Book
{
    public class BookCommand : IRequest<OutputResponse<BookCommandResult>>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int Quantity { get; set; }
        public int ResourceId { get; set; }
    }
}
