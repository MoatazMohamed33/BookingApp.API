using AutoMapper;
using BookingApp.Application;
using BookingApp.Application.Common.Responses;
using BookingApp.Application.Components.Bookings.Book;
using BookingApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Components
{
    public class BookingService : IBookingService
    {
        private readonly AppDbContext _context;
        public BookingService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<OutputResponse<BookCommandResult>> Book(BookCommand request)
        {
            var booking = await _context.Bookings.Include(x => x.Resource).Where(x => x.ResourceId == request.ResourceId).FirstOrDefaultAsync();
            booking.BookedQuantity = request.Quantity;
            booking.Resource.Quantity = booking.Resource.Quantity - request.Quantity;
            await _context.SaveChangesAsync();

            return new OutputResponse<BookCommandResult>
            {
                Success = true,
                StatusCode = HttpStatusCode.Created,
                Message = "Success",
                Model = new BookCommandResult() { Id = booking.ResourceId, Name = booking.Resource.Name }
            };
        }

        public async Task<Booking> GetBooking(int resourceId)
        {
            var res = await _context.Bookings.Include(x => x.Resource).Where(x => x.ResourceId == resourceId).FirstOrDefaultAsync();
            return res;
        }
    }
}
