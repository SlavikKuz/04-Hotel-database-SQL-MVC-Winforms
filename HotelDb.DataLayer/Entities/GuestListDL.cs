using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelDb.DataLayer.Entities
{
    public class GuestListDL
    {
        [Key]
        public Guid Id { get; set; }
        
        public Guid BookingId { get; set; }
        
        public Guid GuestId { get; set; } 
    }
}
