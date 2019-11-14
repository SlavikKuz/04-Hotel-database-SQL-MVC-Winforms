using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelDb.WebUI.Models
{
    public class BookingRoomListModel
    {
        public Guid BookingId { get; set; }
        public BookingModel Booking { get; set; }

        public Guid RoomId { get; set; }
        public RoomModel Room { get; set; }
    }
}
