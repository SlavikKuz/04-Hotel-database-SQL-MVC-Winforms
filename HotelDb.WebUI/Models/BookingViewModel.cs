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
        public InvoiceModel Invoice { get; set; } = new InvoiceModel();
        public ClientModel Client { get; set; }

        public List<SelectListItem> SelectListClient { get; set; } = new List<SelectListItem>();        

        [Display(Name = "Invited Guests:")]
        public List<GuestListModel> GuestList { get; set; } = new List<GuestListModel>();
        public List<SelectListItem> SelectListGuest { get; set; } = new List<SelectListItem>();
        public List<string> ShowSelectedGuests { get; set; } = new List<string>();
        [Display(Name = "Add Guest:")]
        public long GuestId { get; set; }

        [Display(Name = "Selected Rooms:")]
        public List<BookingRoomListModel> RoomList { get; set; } = new List<BookingRoomListModel>();
        public List<SelectListItem> SelectListRoom { get; set; } = new List<SelectListItem>();
        public List<string> ShowSelectedRooms { get; set; } = new List<string>();
        [Display(Name = "Add Room:")]
        public long RoomId { get; set; }
    }
}
