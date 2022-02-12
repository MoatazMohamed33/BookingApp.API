using AspNetCore.ServiceRegistration.Dynamic;
using BookingApp.Application.Common.Responses;
using BookingApp.Application.Components.Bookings.Book;
using BookingApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookingApp.Application
{
    public interface IBookingService : IScopedService
    {
        Task<OutputResponse<BookCommandResult>> Book(BookCommand request);
        Task<Booking> GetBooking(int resourceId);
    }
}
