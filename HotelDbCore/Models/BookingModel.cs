using System;

namespace HotelDBCore.Model
{
    public class BookingModel
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DayFrom { get; set; }
        public DateTime DayTill { get; set; }
        public int NumberAdults { get; set; }
        public int NumberKids { get; set; }
        public string Status { get; set; }
        public string Info { get; set; }
    }
}
