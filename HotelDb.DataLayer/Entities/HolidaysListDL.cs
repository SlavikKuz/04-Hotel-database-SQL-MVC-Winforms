using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelDb.DataLayer.Entities
{ 
    public class HolidaysListDL
    {
        [Column(TypeName = "date")]
        public DateTime HolidayDay { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string HolidayName { get; set; }
    }
}
