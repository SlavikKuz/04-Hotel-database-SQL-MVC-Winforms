using AutoMapper;
using HotelDb.DataLayer.Entities;
using HotelDb.Logic.Entities;
using System;

namespace HotelDb.DataLogic
{
    public class MapperProfileLL : Profile
    {
        public MapperProfileLL()
        {
            CreateMap<ClientDL, ClientLL>();
            CreateMap<BookingDL, BookingLL>();
            CreateMap<RoomDL, RoomLL>();
            CreateMap<DayDL, DayLL>();
            CreateMap<GuestDL, GuestLL>();

            CreateMap<ClientLL, ClientDL>();
            CreateMap<BookingLL, BookingDL>();
            CreateMap<RoomLL, RoomDL>();
            CreateMap<DayLL, DayDL>();
            CreateMap<GuestLL, GuestDL>();
        }
    }

    public class ObjectMapper
    {
        public static IMapper Mapper
        {
            get { return mapper.Value; }
        }

        public static IConfigurationProvider Configuration
        {
            get { return config.Value; }
        }

        public static Lazy<IMapper> mapper = new Lazy<IMapper>(() =>
        {
            var mapper = new Mapper(Configuration);
            return mapper;
        });

        public static Lazy<IConfigurationProvider> config = new Lazy<IConfigurationProvider>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfileLL>();
            });
            return config;
        });
    }
}
