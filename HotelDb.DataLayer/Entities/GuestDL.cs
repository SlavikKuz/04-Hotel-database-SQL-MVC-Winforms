
namespace HotelDb.DataLayer.Entities
{
    public class GuestDL
    {
        public long ClientId { get; set; }
        public ClientDL Client { get; set; }

        public long BookingId { get; set; }
        public BookingDL Booking { get; set; }
    }
}
