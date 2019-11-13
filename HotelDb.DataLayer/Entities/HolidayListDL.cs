using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelDb.DataLayer.Entities
{ 
    public class HolidayListDL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime HolidayDay { get; set; }
        
        [Column(TypeName = "nvarchar(20)")]
        public string HolidayName { get; set; }
    }
}
