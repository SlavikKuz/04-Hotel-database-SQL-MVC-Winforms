using System;
using System.ComponentModel.DataAnnotations;

namespace HotelDb.WebUI.Models
{ 
    public class HolidayListModel
    {
        public long HolidayId { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        [Required]
        public DateTime HolidayDay { get; set; }

        [Display(Name = "Holiday")]
        [Required]
        public string HolidayName { get; set; }

        // DateTimeFormatInfo dtfi = CultureInfo.CreateSpecificCulture("nb-NO").DateTimeFormat;
        // return HolidayDay.Date.ToString("d", dtfi);           

    }
}
