using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelDb.DataLayer.Entities
{
    public class InvoiceDL
    {
        [Key]
        public long InvoiceId { get; set; }
        public long ClientId { get; set; }
        public long BookingId { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal TotalPrice { get; set; }
    }
}
