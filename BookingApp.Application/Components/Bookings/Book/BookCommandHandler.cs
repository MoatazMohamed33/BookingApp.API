using BookingApp.Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookingApp.Application.Components.Bookings.Book
{
    public class BookCommandHandler : IRequestHandler<BookCommand, OutputResponse<BookCommandResult>>
    {
        private readonly IBookingService _bookingService;
        private readonly IEmailService _emailService;
        public BookCommandHandler(IBookingService bookingService, IEmailService emailService)
        {
            _bookingService = bookingService;
            _emailService = emailService;
        }
        public async Task<OutputResponse<BookCommandResult>> Handle(BookCommand request, CancellationToken cancellationToken)
        {
            var result= await _bookingService.Book(request);
            if (result.StatusCode==HttpStatusCode.Created)
            {
                var msg = $"EMAIL SENT TO admin@admin.com FOR CREATED BOOKING WITH ID {result.Model.Id}";
                await _emailService.Send(msg);
            }
            return result;
        }
    }
}
