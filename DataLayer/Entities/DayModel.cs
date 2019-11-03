using System;

namespace HotelDb.DataLayer.Entities
{ 
    public class DayModel
    {
        public int Id { get; set; }
        public DateTime DayHoliday { get; set; }
        public string HolidayName { get; set; }
    }
}
