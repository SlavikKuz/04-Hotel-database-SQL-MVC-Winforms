using System.Collections.Generic;

namespace HotelDb.Logic.Entities
{
    public class ClientLL
    {
    public long Id { get; set; }
    public string ClientFullName { get; set; }
    public string Email { get; set; }
    public string Tel { get; set; }
    public string Address { get; set; }
    public string Notes { get; set; }
    //public List<BookingModel> BookingsHistory { get; set; }
    public List<GuestLL> GuestsNames { get; set; }
    }
}
