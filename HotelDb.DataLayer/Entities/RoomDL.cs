using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelDb.DataLayer.Entities
{
    public class RoomDL
    {
        [Key]
        public long RoomId { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string RoomNumber { get; set; }
        public int NumberBeds { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string Floor { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string RoomInfo  { get; set; }
        public bool Ready { get; set; }
        public long RoomPriceId { get; set; }
    }
}
