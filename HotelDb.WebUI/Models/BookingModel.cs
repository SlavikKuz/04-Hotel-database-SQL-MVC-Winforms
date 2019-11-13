using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelDb.WebUI.Models
{
    public class BookingModel
    {
        public Guid Id { get; set; }

        public ClientModel Client { get; set; }
        public InvoiceModel Invoice { get; set; }
        public List<RoomModel> RoomList { get; set; }
        public List<ClientModel> GuestList { get; set; }

        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [Display(Name = "From")]
        [DataType(DataType.Date)]
        public DateTime DayFrom { get; set; } = DateTime.Now;
        [Display(Name = "Till")]
        [DataType(DataType.Date)]
        public DateTime DayTill { get; set; } = DateTime.Now;

        [Display(Name = "Kids")]
        public bool WithKids { get; set; }
        
        [Display(Name = "Additional Information")]
        public string Info { get; set; }        
        
        public Status Status { get; set; }
    }

    public enum Status
    {
        Confirmed, Fullfilled, Cancelled
    }
}
