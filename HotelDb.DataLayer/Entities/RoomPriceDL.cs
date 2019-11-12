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
        public long RoomPriceId { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string RoomNumber { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal AveragePrice { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal WeekendPrice { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal HolidayPrice { get; set; }
    }
}
