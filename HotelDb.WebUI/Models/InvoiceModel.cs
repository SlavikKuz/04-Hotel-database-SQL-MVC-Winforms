using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelDb.WebUI.Models
{
    public class InvoiceModel
    {
        public Guid Id { get; set; }

        [Display(Name="Price")]
        public decimal TotalPrice { get; set; }
    }
}
