using AutoMapper;
using HotelDb.DataLayer.Entities;
using HotelDb.Logic.Entities;

namespace HotelDb.DataLogic
{
    public class MapperProfileLL : Profile
    {
        public MapperProfileLL()
        {
            CreateMap<ClientLL, ClientDL>();
            CreateMap<BookingLL, BookingDL>();
            CreateMap<RoomLL, RoomDL>();
            CreateMap<DayDL, DayLL>();
            CreateMap<GuestDL, GuestLL>();
        }
    }
}
