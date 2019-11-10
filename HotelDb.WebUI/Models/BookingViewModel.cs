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
        public BookingModel Booking { get; set; } = new BookingModel();

        public List<SelectListItem> SelectClient { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> SelectRoom { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> SelectGuest { get; set; } = new List<SelectListItem>();

        [Display(Name = "Room")]
        public long RoomId { get; set; }
        
        [Display(Name = "Guests")]
        public long GuestId { get; set; }

        [Display(Name = "Selected Rooms")]
        public List<string> SelectedRooms { get; set; } = new List<string>();

        [Display(Name = "Selected Rooms")]
        public List<string> SelectedGuests { get; set; } = new List<string>();
    }
}
