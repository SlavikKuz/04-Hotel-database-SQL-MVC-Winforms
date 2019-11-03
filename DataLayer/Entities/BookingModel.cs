using System;
using System.Collections.Generic;

namespace HotelDb.DataLayer.Entities
{
    public class BookingModel
    {
        public long Id { get; set; }
        //public long ClientId { get; set; }
        public ClientModel Client { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DayFrom { get; set; }
        public DateTime DayTill { get; set; }
        public List<GuestModel> GuestsNames { get; set; } //many to many
        public bool WithKids { get; set; }
        public string Status { get; set; }
        public string Info { get; set; }
        public List<RoomModel> BookedRooms { get; set; }
        public List<DayModel> Holidays { get; set; }
    }
}
