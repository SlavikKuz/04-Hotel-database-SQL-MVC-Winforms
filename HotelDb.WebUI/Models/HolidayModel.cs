using System;
using System.ComponentModel.DataAnnotations;

namespace HotelDb.WebUI.Models
{ 
    public class HolidayModel
    {
        public long HolidayId { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Holiday Date")]
        [Required]
        public DateTime HolidayDay { get; set; }

        [Display(Name = "Holiday Name")]
        [Required]
        public string HolidayName { get; set; }


        // DateTimeFormatInfo dtfi = CultureInfo.CreateSpecificCulture("nb-NO").DateTimeFormat;
        // return HolidayDay.Date.ToString("d", dtfi);           

    }
}
