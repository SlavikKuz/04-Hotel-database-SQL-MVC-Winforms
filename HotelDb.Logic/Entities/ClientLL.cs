using System;
using System.Collections.Generic;

namespace HotelDb.Logic.Entities
{
    public class ClientLL
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string Tel { get; set; }
        public string Email { get; set; }

        public string ClientInfo { get; set; }

        public BookingLL Booking { get; set; }
    }
}
