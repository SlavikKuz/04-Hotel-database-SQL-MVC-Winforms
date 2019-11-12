using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelDb.WebUI.Models
{
    public class ClientViewModel
    {
        public ClientModel Client { get; set; } = new ClientModel();
        public List<BookingModel> Bookings { get; set; } = new List<BookingModel>();
        public List<InvoiceModel> Invoices { get; set; } = new List<InvoiceModel>();
    }
}
