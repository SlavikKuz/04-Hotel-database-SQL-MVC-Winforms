using System;
using System.Collections.Generic;

namespace HotelDb.WebUI.Models
{
    public class BookingModel
    {
        public long Id { get; set; }
        public ClientModel Client { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DayFrom { get; set; }
        public DateTime DayTill { get; set; }
        public List<GuestModel> GuestsNames { get; set; } = new List<GuestModel>();
        public bool WithKids { get; set; }
        public Status Status { get; set; }
        public string Info { get; set; }
        public List<RoomModel> BookedRooms { get; set; } = new List<RoomModel>();
        public List<DayModel> Holidays { get; set; } = new List<DayModel>();
    }

    public enum Status
    {
        Comming, Ongoing, Cancelled
    }
}
