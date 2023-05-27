using Hotel.Domain.Abstractions;
using Hotel.Domain.Entities;
using Hotel.Persistence.Data;

namespace Hotel.Persistence.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<User>> _userRepository;
        private readonly Lazy<IRepository<BookingData>> _bookingDataRepository;
        private readonly Lazy<IRepository<Room>> _roomRepository;

        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _userRepository = new(() => new EfRepository<User>(context));
            _bookingDataRepository = new(() => new EfRepository<BookingData>(context));
            _roomRepository = new(() => new EfRepository<Room>(context));
        }

        public IRepository<User> UserRepository => _userRepository.Value;
        public IRepository<Room> RoomRepository => _roomRepository.Value;
        public IRepository<BookingData> BookingDataRepository => _bookingDataRepository.Value;

        public async Task CreateDatabaseAsync()
        {
            await _context.Database.EnsureCreatedAsync();
        }

        public async Task RemoveDatbaseAsync()
        {
            await _context.Database.EnsureDeletedAsync();
        }

        public async Task SaveAllAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
