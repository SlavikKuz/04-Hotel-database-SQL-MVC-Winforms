using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelDb.WebUI.Models
{
    public class BookingModel
    {
        public long BookingId { get; set; }
        public long ClientId { get; set; }
        public DateTime OrderDate { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DayFrom { get; set; }

        [DataType(DataType.Date)]
        public DateTime DayTill { get; set; }
        public bool WithKids { get; set; }
        public List<long> GuestId { get; set; }
        public Status Status { get; set; }
        public string Info { get; set; }
        public List<long> RoomId { get; set; }
        public List<DateTime> Holiday { get; set; }
    }

    public enum Status
    {
        Confirmed, Fullfilled, Cancelled
    }
}
