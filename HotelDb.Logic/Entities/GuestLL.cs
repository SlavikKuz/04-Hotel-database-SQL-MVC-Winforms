
namespace HotelDb.Logic.Entities
{
    public class GuestLL
    {
        public long ClientId { get; set; }
        public ClientLL Client { get; set; }

        public long BookingId { get; set; }
        public BookingLL Booking { get; set; }
    }
}
