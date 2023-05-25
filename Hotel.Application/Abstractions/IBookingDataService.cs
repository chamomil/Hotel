using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Abstractions
{
    public interface IBookingDataService : IBaseService<BookingData>
    {
        Task<IEnumerable<BookingData>> GetSuperpowerBySuperhero(int id);
    }
}
