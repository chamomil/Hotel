using Hotel.Domain.Entities;

namespace Hotel.Application.Abstractions
{
    public interface IBookingDataService : IBaseService<BookingData>
    {
        Task<IEnumerable<BookingData>> GetUserById(int id);
    }
}
