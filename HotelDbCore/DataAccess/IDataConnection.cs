using System;
using System.Collections.Generic;
using HotelDBCore.Model;

namespace HotelDBCore.DataAccess
{
    public interface IDataConnection
    { 
        //get methods
        List<ClientModel> GetClientsAll();
        List<ClientModel> GetClientsAll(string clientSearch);
        ClientModel GetClient(int clientPosition);

        List<BookingModel> GetBookingsAll();
        List<BookingModel> GetBookingsAll(int clientId);
        List<BookingModel> GetBookingsAll(DateTime date);
        List<BookingModel> GetBookingsAll(string status);
        BookingModel GetBooking(int bookingId);

        decimal GetPriceOnDay(DayModel day);

        List<RoomModel> GetRoomsAll();
        RoomModel GetRoom(int roomId);

        //set methods
        void CreateClient(ClientModel client);
        void UpdateClient(ClientModel client);
        void CreateBooking(BookingModel booking);
        void UpdateBooking(BookingModel booking);
        void DeactivateBooking(BookingModel booking);
        void CreateHoliday(DayModel day);
        void DeleteHoliday(DayModel day);
        void CreateRoom(RoomModel room);
        void UpdateRoom(RoomModel room);
        void DeleteRoom(RoomModel room);
    }
}
