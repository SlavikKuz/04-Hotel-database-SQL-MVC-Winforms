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
            CreateMap<HolidayModel, HolidayListLL>();         
            CreateMap<InvoiceModel, InvoiceLL>();
            CreateMap<RoomListModel, RoomsListLL>();
            CreateMap<RoomModel, RoomLL>();
            CreateMap<RoomPriceModel, RoomPriceLL>();

            CreateMap<BookingLL, BookingModel>();
            CreateMap< ClientLL, ClientModel>();
            CreateMap<GuestListLL, GuestListModel>();
            CreateMap<HolidayListLL, HolidayModel>();
            CreateMap<InvoiceLL, InvoiceModel>();
            CreateMap<RoomsListLL, RoomListModel>();
            CreateMap<RoomLL, RoomModel>();
            CreateMap<RoomPriceLL, RoomPriceModel>();
        }
    }
}
