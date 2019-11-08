using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelDb.DataLayer.Entities
{
    public class BookingDL
    {
        [Key]
        public long BookingId { get; set; }
        public long ClientId { get; set; }
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime DayFrom { get; set; }
        [Column(TypeName = "date")]
        public DateTime DayTill { get; set; }
        public bool WithKids { get; set; }
        public Status BookingStatus { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string BookingInfo { get; set; }
        public long InvoiceId { get; set; }
    }

    public enum Status
    {
        Cofirmed, Cancelled
    }
}
