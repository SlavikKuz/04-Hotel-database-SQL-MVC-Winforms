using System;

namespace HotelDb.Logic.Entities
{
    public class RoomLL
    {
        public long RoomId { get; set; }

        public string RoomNumber { get; set; }
        public int NumberBeds { get; set; }

        public string Description { get; set; }

        public string Floor { get; set; }

        public string RoomInfo { get; set; }
        public bool Ready { get; set; }
        public long RoomPriceId { get; set; }
    }
}
