using BookingApp.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookingApp.Application.Components.Bookings.Book
{
    public class BookCommandValidator : AbstractValidator<BookCommand>
    {
        private Booking _booking ; 
        private readonly IBookingService _bookingService;

        private async Task<bool> GetBooking(int resourceId, CancellationToken token)
        {
            _booking = await _bookingService.GetBooking(resourceId);
            if (_booking != null)
            {
                return true;
            }
            return false;
        }
        public BookCommandValidator(IBookingService bookingService)
        {
            _bookingService = bookingService;
            CascadeMode = CascadeMode.Stop;
            RuleFor(c => c.ResourceId)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithErrorCode("1000").WithMessage("Mandatory")
              .NotEmpty().WithErrorCode("1000").WithMessage("Mandatory")
              .MustAsync(GetBooking).WithErrorCode("1001").WithMessage("NotFound");

            RuleFor(c => c.DateFrom)
               .Cascade(CascadeMode.Stop)
              .NotNull().WithErrorCode("1000").WithMessage("Mandatory")
              .NotEmpty().WithErrorCode("1000").WithMessage("Mandatory")
              .Must(d=>d>=_booking.DateFrom).WithErrorCode("1011").WithMessage($"Invalid DateFrom");

            RuleFor(c => c.DateTo)
              .Cascade(CascadeMode.Stop)
             .NotNull().WithErrorCode("1000").WithMessage("Mandatory")
             .NotEmpty().WithErrorCode("1000").WithMessage("Mandatory")
             .Must(d=>d<=_booking.DateTo).WithErrorCode("1011").WithMessage($"Invalid DateTo");

            RuleFor(c => c.Quantity)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithErrorCode("1000").WithMessage("Mandatory")
             .Must(d=>d<=_booking?.Resource?.Quantity).WithErrorCode("1011").WithMessage($"Quantity is more than available");
        }

    
    }
}
