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
            CreateMap<BookingDL, BookingLL>();
            CreateMap<ClientDL, ClientLL>();
            CreateMap<GuestListDL, GuestListLL>();
            CreateMap<HolidayListDL, HolidayListLL>();
            CreateMap<InvoiceDL, InvoiceLL>();
            CreateMap<RoomDL, RoomLL>();
            CreateMap<RoomPriceDL, RoomPriceLL>();            
            CreateMap<RoomListDL, RoomListLL>();

            CreateMap<BookingLL, BookingDL>();
            CreateMap<ClientLL, ClientDL>();
            CreateMap<GuestListLL, GuestListDL>();
            CreateMap<HolidayListLL, HolidayListDL>();            
            CreateMap<InvoiceLL, InvoiceDL>();
            CreateMap<RoomLL, RoomDL>();
            CreateMap<RoomPriceLL, RoomPriceDL>();
            CreateMap<RoomListLL, RoomListDL>();
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
