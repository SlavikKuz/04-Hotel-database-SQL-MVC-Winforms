using System.Collections.Generic;

namespace HotelDb.DataLayer.Entities
{
    public class ClientModel
    {
    public long Id { get; set; }
    public string ClientFullName { get; set; }
    public string Email { get; set; }
    public string Tel { get; set; }
    public string Address { get; set; }
    public string Notes { get; set; }
    //public List<BookingModel> BookingsHistory { get; set; }
    public List<GuestModel> GuestsNames { get; set; }
    }
}
