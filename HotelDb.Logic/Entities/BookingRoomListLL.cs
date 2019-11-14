using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.Logic.Entities
{
    public class BookingRoomListLL
    {
        public Guid BookingId { get; set; }
        public BookingLL Booking { get; set; }

        public Guid RoomId { get; set; }
        public RoomLL Room { get; set; }
    }
}
