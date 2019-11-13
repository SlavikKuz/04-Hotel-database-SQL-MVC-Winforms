using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelDb.Logic.Entities
{ 
    public class HolidayListLL
    {
        public Guid Id { get; set; }

        public DateTime HolidayDay { get; set; }

        public string HolidayName { get; set; }
    }
}
