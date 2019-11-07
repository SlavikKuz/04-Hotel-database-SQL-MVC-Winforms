using System;

namespace HotelDb.WebUI.Models
{
    public class RoomModel
    {
        public long RoomId { get; set; }
        public string RoomDescription { get; set; }
        public int NumberBeds { get; set; }
        public string Floor { get; set; }
        public string Info  { get; set; }
        public Status Active { get; set; }

        public enum Status
        {
            //ready or not to accept guests, not - renowation, flood, etc
            Confirmed, Fullfilled, Cancelled
        }
    }
}
