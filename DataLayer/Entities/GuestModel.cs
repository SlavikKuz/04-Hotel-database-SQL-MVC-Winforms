
namespace HotelDb.DataLayer.Entities
{
    public class GuestModel
    {
        public long ClientId { get; set; }
        public ClientModel Client { get; set; }

        public long BookingId { get; set; }
        public BookingModel Booking { get; set; }
    }
}
