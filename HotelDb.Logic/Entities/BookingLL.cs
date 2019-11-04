using System;
using System.Collections.Generic;

namespace HotelDb.Logic.Entities
{
    public class BookingLL
    {
        public long Id { get; set; }
        //public long ClientId { get; set; }
        public ClientLL Client { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DayFrom { get; set; }
        public DateTime DayTill { get; set; }
        public List<GuestLL> GuestsNames { get; set; } //many to many
        public bool WithKids { get; set; }
        public Status Status { get; set; }
        public string Info { get; set; }
        public List<RoomLL> BookedRooms { get; set; }
        public List<DayLL> Holidays { get; set; }
    }
    public enum Status
    {
        Comming, Ongoing, Cancelled
    }
}
