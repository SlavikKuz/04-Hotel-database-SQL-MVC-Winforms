using System;
using System.ComponentModel.DataAnnotations;

namespace HotelDb.WebUI.Models
{ 
    public class HolidayModel
    {
        [DataType(DataType.Date)]
        public DateTime Holiday { get; set; }     
        public string HolidayName { get; set; }
    }
}
