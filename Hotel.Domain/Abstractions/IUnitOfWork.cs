using Hotel.Domain.Entities;

namespace Hotel.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Room> RoomRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<BookingData> BookingDataRepository { get; }
        public Task RemoveDatbaseAsync();
        public Task CreateDatabaseAsync();
        public Task SaveAllAsync();
    }
}
