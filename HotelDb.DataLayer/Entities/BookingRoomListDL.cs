using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.DataLayer.Entities
{
    public class BookingRoomListDL
    {
        public Guid BookingId { get; set; }
        public BookingDL Booking { get; set; }

        public Guid RoomId { get; set; }
        public RoomDL Room { get; set; }

    }
}
