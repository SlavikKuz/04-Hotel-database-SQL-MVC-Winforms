using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelDb.WebUI.Models
{
    public class BookingModel
    {
        public long Id { get; set; }
        public ClientModel Client { get; set; }
        public DateTime OrderDate { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DayFrom { get; set; }

        [DataType(DataType.Date)]
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
        Confirmed, Fullfilled, Cancelled
    }
}
