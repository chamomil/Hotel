using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
