using AutoMapper;
using HotelDb.DataLayer.Entities;
using HotelDb.Logic.Entities;
using HotelDb.WebUI.Models;
using Microsoft.AspNetCore.Http;

namespace HotelDb.WebUI
{
    public class MapperProfileUI : Profile
    {
        public MapperProfileUI()
        {
            CreateMap<BookingModel, BookingLL>();            
            CreateMap<ClientModel, ClientLL>();            
            CreateMap<GuestListModel, GuestListLL>(); 
            CreateMap<HolidayListModel, HolidayListLL>();         
            CreateMap<InvoiceModel, InvoiceLL>();
            CreateMap<BookingRoomListModel, BookingRoomListLL>();
            CreateMap<RoomModel, RoomLL>();
            CreateMap<RoomPriceModel, RoomPriceLL>();

            CreateMap<BookingLL, BookingModel>();
            CreateMap<ClientLL, ClientModel>();
            CreateMap<GuestListLL, GuestListModel>();
            CreateMap<HolidayListLL, HolidayListModel>();
            CreateMap<InvoiceLL, InvoiceModel>();
            CreateMap<BookingRoomListLL, BookingRoomListModel>();
            CreateMap<RoomLL, RoomModel>();
            CreateMap<RoomPriceLL, RoomPriceModel>();
        }
    }
}
