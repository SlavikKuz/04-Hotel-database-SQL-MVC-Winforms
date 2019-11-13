using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.Logic.Entities
{
    public class InvoiceLL
    {
        public Guid Id { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
