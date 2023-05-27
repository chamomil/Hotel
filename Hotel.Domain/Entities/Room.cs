namespace Hotel.Domain.Entities
{
    public class Room : Entity
    {
        public int Number { get; set; }
        public int Rank { get; set; }
        public int Size { get; set; }
        public ICollection<BookingData> Bookings { get; set; }
    }
}
