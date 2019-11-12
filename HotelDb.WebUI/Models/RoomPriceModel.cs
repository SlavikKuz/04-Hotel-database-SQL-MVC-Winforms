using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelDb.WebUI.Models
{
    public class RoomPriceModel
    {
        public long RoomPriceId { get; set; }

        [Display(Name ="Room Number:")]
        public string RoomNumber { get; set; }

        public decimal AveragePrice { get; set; }

        public decimal WeekendPrice { get; set; }

        public decimal HolidayPrice { get; set; }
    }
}
