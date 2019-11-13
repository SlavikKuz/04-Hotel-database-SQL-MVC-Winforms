using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelDb.Logic.Entities
{
    public class BookingLL
    {
        public Guid Id { get; set; }

        public ClientLL Client { get; set; }
        public InvoiceLL Invoice { get; set; }
        public List<RoomLL> RoomList { get; set; }
        public List<ClientLL> GuestList { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime DayFrom { get; set; }
        public DateTime DayTill { get; set; }        

        public bool WithKids { get; set; }

        public string Info { get; set; }

        public Status Status { get; set; }
    }

    public enum Status
    {
        Confirmed, Fullfilled, Cancelled
    }
}
