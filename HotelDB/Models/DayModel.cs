using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HotelDB.Model
{
    public class DayModel
    {
        public int Id { get; set; }
        public DateTime DayHoliday { get; set; }
        public string HolidayName { get; set; }

        public bool CheckWeekend()
        {             
        //1. method will test if the day is working or weekend
        //{
        //    DateTime day = new DateTime(year,1,1);

        //    while (day.Year == year)
        //    {
        //        int weekend = 0;
        //        if (day.DayOfWeek == DayOfWeek.Friday ||
        //            day.DayOfWeek == DayOfWeek.Saturday ||
        //            day.DayOfWeek == DayOfWeek.Sunday)
        //            weekend = 1;
            return true;
        }   
    }
}
