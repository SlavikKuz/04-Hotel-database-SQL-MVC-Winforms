using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelDb.Logic.Entities
{
    public class BookingLL
    {
        public long BookingId { get; set; }
        public long ClientId { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DayFrom { get; set; }

        public DateTime DayTill { get; set; }
        public bool WithKids { get; set; }
        public Status BookingStatus { get; set; }

        public string BookingInfo { get; set; }
        public long InvoiceId { get; set; }
    }
    public enum Status
    {
        Cofirmed, Cancelled
    }
}
