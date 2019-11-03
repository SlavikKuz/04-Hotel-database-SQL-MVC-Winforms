using System;


namespace HotelDB.Domain.Model
{
    public class DayModel
    {
        public int Id { get; set; }
        public DateTime DayHoliday { get; set; }
        public string HolidayName { get; set; }
        public BookingModel Booking { get; set; }
    }
}
