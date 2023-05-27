using Hotel.Application.Abstractions;
using Hotel.Domain.Abstractions;
using Hotel.Domain.Entities;

namespace Hotel.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Room> _roomRepository;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = unitOfWork.UserRepository;
            _roomRepository = unitOfWork.RoomRepository;
        }

        public async Task<User> AddAsync(User item)
        {
            await _userRepository.AddAsync(item);
            await _unitOfWork.SaveAllAsync();
            return item;
        }

        public async Task<User> DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            await _userRepository.DeleteAsync(user);
            await _unitOfWork.SaveAllAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.ListAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id, includesProperties: (user) => user.BookedRooms);
            foreach (var booking in user.BookedRooms)
            {
                booking.Room = await _roomRepository.FirstOrDefaultAsync(room => room.Id == booking.RoomId);
            }
            return user;
        }

        public async Task<bool> IsLoginAndPasswordValid(string login, string password)
        {
            var user = await _userRepository.FirstOrDefaultAsync((user) => user.Login == login);
            return user != null && user.Password == password;
        }

        public Task GetConnections()
        {
            _unitOfWork.UserRepository.ListAllAsync();
            _unitOfWork.RoomRepository.ListAllAsync();
            _unitOfWork.BookingDataRepository.ListAllAsync();
            return Task.CompletedTask;
        }

        public async Task<User> UpdateAsync(User item)
        {
            await _userRepository.UpdateAsync(item);
            await _unitOfWork.SaveAllAsync();
            return item;
        }

        public async Task<bool> IsLoginAvailable(string login)
        {
            var user = await _userRepository.FirstOrDefaultAsync((user) => user.Login == login);
            return user == null;
        }

        public async Task<int> GetUserIdByLogin(string login)
        {
            var user = await _userRepository.FirstOrDefaultAsync((user) => user.Login == login);
            return user.Id;
        }
    }
}
