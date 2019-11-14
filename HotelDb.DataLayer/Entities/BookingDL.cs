using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelDb.DataLayer.Entities
{
    public class BookingDL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        public ClientDL Client { get; set; }
        public Guid ClientId { get; set; }
        
        public InvoiceDL Invoice { get; set; }
        public List<BookingRoomListDL> BookingRoomList { get; set; }
        
        public List<GuestListDL> GuestList { get; set; }

        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }        
        [Column(TypeName = "date")]
        public DateTime DayFrom { get; set; }        
        [Column(TypeName = "date")]
        public DateTime DayTill { get; set; }
        
        public bool WithKids { get; set; }
       
        [Column(TypeName = "nvarchar(100)")]
        public string Info { get; set; }
        
        public Status Status { get; set; }

    }

    public enum Status
    {
        Confirmed, Fullfilled, Cancelled
    }
}
