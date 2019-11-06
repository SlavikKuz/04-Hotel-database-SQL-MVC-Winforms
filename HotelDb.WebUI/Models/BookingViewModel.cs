using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelDb.WebUI.Models
{
    public class BookingViewModel
    {
        public ClientModel Client { get; set; }
        public BookingModel Booking { get; set; }
        public IEnumerable<GuestModel> Guests { get; set; }
        public IEnumerable<DayModel> Holidays { get; set; }
        public IEnumerable<RoomModel> Rooms { get; set; }
    }
}
