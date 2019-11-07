using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelDb.WebUI.Models
{
    public class ClientModel
    {
        public long ClientId { get; set; }

        [MaxLength(50)] //limit for EF create table
        [Display(Name = "Client Name")] //for view, name
        [StringLength(50, MinimumLength = 2)] //view view, check input
        [Required] //required in creating a new client 
        public string ClientFullName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, MinimumLength = 6)]
        [Required]
        public string Email { get; set; }

        [MaxLength(50)]
        [Display(Name = "Telephone")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(50, MinimumLength = 6)]
        [Required]
        public string Tel { get; set; }

        [MaxLength(100)]
        [Display(Name = "Address")]
        [Required]
        [StringLength(100, MinimumLength = 12)]
        public string Address { get; set; }

        [MaxLength(250)]
        [Display(Name = "Notes")]
        [StringLength(250)]
        public string Notes { get; set; }
    }
}
