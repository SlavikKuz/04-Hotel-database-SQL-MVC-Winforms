using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelDb.WebUI.Models
{
    public class InvoiceModel
    {
        public long InvoiceId { get; set; }

        public long ClientId { get; set; }

        public long BookingId { get; set; }

        [Display(Name="Price")]
        public decimal Price { get; set; }
    }
}
