using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelDb.WebUI.Models
{
    public class RoomPriceModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Average Price:")]
        public decimal AveragePrice { get; set; }

        [Display(Name = "Weekend Price:")]
        public decimal WeekendPrice { get; set; }

        [Display(Name = "Holiday Price:")]
        public decimal HolidayPrice { get; set; }
    }
}
