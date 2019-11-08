using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelDb.WebUI.Models
{
    public class ClientModel
    {
        public long ClientId { get; set; }

        [Display(Name = "First Name")]
        [StringLength(20, MinimumLength = 2)]
        [Required]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        [StringLength(20, MinimumLength = 2)]
        [Required]
        public string LastName { get; set; }
        
        [Display(Name = "Address")]
        [Required]
        [StringLength(20, MinimumLength = 12)]
        public string Address { get; set; }

        [Display(Name = "City")]
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string City { get; set; }
        
        [Display(Name = "Coutry")]
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Country { get; set; }

        [Display(Name = "Telephone")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20, MinimumLength = 6)]
        [Required]
        public string Tel { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, MinimumLength = 6)]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Notes")]
        [StringLength(50)]
        public string ClientInfo { get; set; }



        [Display(Name = "Client")]
        public string ClientFullName
        {
            get { return FirstName.ToString() + " " + LastName.ToString(); }
        }

        [Display(Name = "Address")]
        public string ClientFullAddress
        {
            get { return Address.ToString() + ", " 
                    + City.ToString() + ", "
                    + Country.ToString(); }
        }
    }
}
