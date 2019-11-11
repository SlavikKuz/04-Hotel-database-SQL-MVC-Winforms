using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelDb.WebUI.Models
{
    public class BookingModel
    {
        public long BookingId { get; set; }
        
        [Display(Name = "Client Name")]
        public long ClientId { get; set; }
        
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Display(Name = "From")]
        [DataType(DataType.Date)]
        public DateTime DayFrom { get; set; } = DateTime.Now;

        [Display(Name = "Till")]
        [DataType(DataType.Date)]
        public DateTime DayTill { get; set; } = DateTime.Now;
        
        public bool WithKids { get; set; }

        public long GuestListId { get; set; }    
        
        public Status Status { get; set; }
        
        [Display(Name = "Additional Information")]
        public string Info { get; set; }
        
        public long RoomListId { get; set; }
        
        public long InvoiceId { get; set; }
    }

    public enum Status
    {
        Confirmed, Fullfilled, Cancelled
    }
}
