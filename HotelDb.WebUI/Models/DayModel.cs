using System;

namespace HotelDb.WebUI.Models
{ 
    public class DayModel
    {
        public int Id { get; set; }
        public DateTime DayHoliday { get; set; }
        public string HolidayName { get; set; }
    }
}
