using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.WebUI.Models
{
    public class RoomPriceModel
    {
        public long RoomId { get; set; }

        public decimal AveragePrice { get; set; }

        public decimal WeekendPrice { get; set; }

        public decimal HolidayPrice { get; set; }
    }
}
