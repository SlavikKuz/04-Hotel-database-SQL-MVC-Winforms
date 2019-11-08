using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.Logic.Entities
{
    public class InvoiceLL
    {
        public long InvoiceId { get; set; }
        public long ClientId { get; set; }
        public long BookingId { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
