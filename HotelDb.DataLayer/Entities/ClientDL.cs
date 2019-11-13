using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelDb.DataLayer.Entities
{
    public class ClientDL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string LastName { get; set; }
        
        [Column(TypeName = "nvarchar(50)")]
        public string Address { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string City { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Country { get; set; }
        
        [Column(TypeName = "nvarchar(20)")]
        public string Tel { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }
        
        [Column(TypeName = "nvarchar(100)")]
        public string ClientInfo { get; set; }
    }
}
