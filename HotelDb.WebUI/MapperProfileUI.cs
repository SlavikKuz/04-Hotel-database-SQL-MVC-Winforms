using AutoMapper;
using HotelDb.DataLayer.Entities;
using HotelDb.Logic.Entities;
using HotelDb.WebUI.Models;

namespace HotelDb.WebUI
{
    public class MapperProfileUI : Profile
    {
        public MapperProfileUI()
        {
            CreateMap<ClientLL, ClientModel>();
            CreateMap<BookingLL, BookingModel>();
            CreateMap<RoomLL, RoomModel>();
            CreateMap<DayLL, DayModel>();
            CreateMap<GuestLL, GuestModel>();
        }
    }
}
