namespace Hotel.Domain.Entities
{
    public class BookingData : Entity
    {
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Room Room { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime DateOfLeaving { get; set; }
    }
}
