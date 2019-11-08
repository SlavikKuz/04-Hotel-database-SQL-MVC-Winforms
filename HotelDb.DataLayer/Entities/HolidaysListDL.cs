using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace HotelDb.DataLayer.Entities
{ 
    public class HolidaysListDL
    {
        [Key]
        public long HolidayId { get; set; }

        [Column(TypeName = "date")]
        public DateTime HolidayDay { get; set; }
        
        [Column(TypeName = "nvarchar(20)")]
        public string HolidayName { get; set; }

    }
}
