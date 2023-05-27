namespace Hotel.Domain.Entities
{
    public class Room : Entity
    {
        public int Rank { get; set; }
        public int Size { get; set; }
        public bool IsAvailable { get; set; }
        public ICollection<BookingData> Bookings { get; set; }
    }
}
