using System;
using TestNinja.Mocking;

namespace TestNinjaNet.Mocking
{
    public class BookRepository : IBookRepository
    {
        public IQueryable<Booking> GetActiveBooks(int? excludedBookingId = null)
        {
            var unitOfWork = new UnitOfWork();
            var bookings =
                 unitOfWork.Query<Booking>()
             .Where(
                    b => b.Status != "Cancelled");

            if (excludedBookingId.HasValue)
                bookings = bookings.Where(b => b.Id != excludedBookingId.Value);
            return bookings;

        }

    }
}

