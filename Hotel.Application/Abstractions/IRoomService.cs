using Hotel.Domain.Entities;
using System.Linq.Expressions;

namespace Hotel.Application.Abstractions
{
    public interface IRoomService : IBaseService<Room>
    {
        public Task<IEnumerable<Room>> GetAvailableRooms(DateTime firstDate, DateTime lastDate);
    }
}
