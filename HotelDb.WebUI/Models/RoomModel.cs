using System;
using System.ComponentModel.DataAnnotations;

namespace HotelDb.WebUI.Models
{
    public class RoomModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Room")]
        [StringLength(10, MinimumLength = 3)]
        [Required]
        public string RoomNumber { get; set; }

        [Display(Name = "Beds")]
        [Required]
        public int NumberBeds { get; set; }
        
        [Display(Name = "Facilities")]
        [StringLength(50, MinimumLength = 2)]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Floor")]
        [StringLength(10, MinimumLength = 1)]
        [Required]
        public string Floor { get; set; }

        [Display(Name = "Information")]
        [StringLength(50, MinimumLength = 2)]
        public string RoomInfo  { get; set; }
        
        [Display(Name = "Room is ready?")]
        [Required]
        public bool Ready { get; set; }

        public RoomPriceModel RoomPrice { get; set; }
    }
}
