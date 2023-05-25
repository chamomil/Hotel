using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? FathersName { get; set; }
        public string? Comment { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<BookingData> BookedRooms { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
