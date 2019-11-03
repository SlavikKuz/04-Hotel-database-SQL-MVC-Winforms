using System;
using System.Collections.Generic;

namespace HotelDB.Domain.Model
{
    public class BookingModel
    {
        public long Id { get; set; }
        //public long ClientId { get; set; }
        public ClientModel Client { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DayFrom { get; set; }
        public DateTime DayTill { get; set; }
        public int NumberAdults { get; set; }
        public int NumberKids { get; set; }
        public string Status { get; set; }
        public string Info { get; set; }
        public List<RoomModel> BookedRooms { get; set; }
        public List<DayModel> Holidays { get; set; }
    }
}
