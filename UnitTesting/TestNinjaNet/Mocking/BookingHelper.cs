using System;
using System.Collections.Generic;
using System.Linq;
using TestNinjaNet.Mocking;
using Microsoft.EntityFrameworkCore;

namespace TestNinja.Mocking
{
    public static  class BookingHelper
    {
             public static  string OverlappingBookingsExist(Booking booking,IBookRepository repository)
        {
            if (booking.Status == "Cencelled")
                return string.Empty;
            var bookings = repository.GetActiveBooks(booking.Id);
            var overlappingBooking =
             bookings.FirstOrDefault(
                 b =>
                     booking.ArrivalDate < b.DepartureDate &&
                    b.ArrivalDate < booking.DepartureDate);

           return overlappingBooking == null ? string.Empty : overlappingBooking.Reference;
        }
    }
}