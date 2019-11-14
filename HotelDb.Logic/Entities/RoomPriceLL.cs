using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.Logic.Entities
{
    public class RoomPriceLL
    {
        public Guid Id { get; set; }

        public decimal AveragePrice { get; set; }

        public decimal WeekendPrice { get; set; }

        public decimal HolidayPrice { get; set; }

        public Guid RoomId { get; set; }
    }
}
