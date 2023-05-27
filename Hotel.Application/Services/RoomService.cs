using Hotel.Application.Abstractions;
using Hotel.Domain.Abstractions;
using Hotel.Domain.Entities;
using System.Linq.Expressions;

namespace Hotel.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Room> _roomRepository;

        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _roomRepository = unitOfWork.RoomRepository;
        }

        public async Task<Room> AddAsync(Room item)
        {
            await _roomRepository.AddAsync(item);
            await _unitOfWork.SaveAllAsync();
            return item;
        }

        public async Task<Room> DeleteAsync(int id)
        {
            var user = await _roomRepository.GetByIdAsync(id);
            await _roomRepository.DeleteAsync(user);
            await _unitOfWork.SaveAllAsync();
            return user;
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await _roomRepository.ListAllAsync();
        }

        public async Task<IEnumerable<Room>> GetAvailableRooms(DateTime firstDate, DateTime lastDate)
        {
            var rooms = await _roomRepository.ListAsync((room) => room.Bookings.Count == 0 || !room.Bookings.Any((booking) => booking.DateOfLeaving > firstDate && booking.DateOfEntry < lastDate));

            return rooms;
        }

        public async Task<Room> GetByIdAsync(int id)
        {
            return await _roomRepository.GetByIdAsync(id, includesProperties: (room) => room.Bookings);
        }

        public Task GetConnections()
        {
            _unitOfWork.UserRepository.ListAllAsync();
            _unitOfWork.RoomRepository.ListAllAsync();
            _unitOfWork.BookingDataRepository.ListAllAsync();
            return Task.CompletedTask;
        }

        public async Task<Room> UpdateAsync(Room item)
        {
            await _roomRepository.UpdateAsync(item);
            await _unitOfWork.SaveAllAsync();
            return item;
        }
    }
}
