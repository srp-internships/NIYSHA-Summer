using TestNinja.Mocking;

namespace TestNinjaNet.Mocking
{
    public interface IBookRepository
    {
        IQueryable<Booking> GetActiveBooks(int? excludedBookingId = null);
    }
}