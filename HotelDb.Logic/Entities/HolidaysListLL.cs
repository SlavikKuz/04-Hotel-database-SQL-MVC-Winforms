using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelDb.Logic.Entities
{ 
    public class HolidaysListLL
    {
        public long HolidayId { get; set; }
        [DataType(DataType.Date)]
        public DateTime HolidayDay { get; set; }
        public string HolidayName { get; set; }
    }
}
