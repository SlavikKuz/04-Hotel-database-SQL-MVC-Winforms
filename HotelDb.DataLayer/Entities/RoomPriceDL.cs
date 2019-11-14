using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelDb.DataLayer.Entities
{
    public class RoomPriceDL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column(TypeName = "decimal(5,0)")]
        public decimal AveragePrice { get; set; }
        [Column(TypeName = "decimal(5,0)")]
        public decimal WeekendPrice { get; set; }
        [Column(TypeName = "decimal(5,0)")]
        public decimal HolidayPrice { get; set; }

        public Guid RoomId { get; set; }
    }
}
