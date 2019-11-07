using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelDb.WebUI.Models
{
    public class BookingViewModel
    {
        public BookingModel Booking { get; set; }
        public ClientModel Client { get; set; }

        public List<SelectListItem> Clients { get; set; } = new List<SelectListItem>();
        public List<GuestModel> Guests { get; set; }
        
        [Display(Name = "Client Name")]
        public long ClientId { get; set; }
    }
}
