using AutoMapper;
using HotelDb.DataLayer;
using HotelDb.DataLayer.Entities;
using HotelDb.DataLogic;
using HotelDb.Logic.Entities;
using System;
using System.Collections.Generic;

namespace HotelDb.Logic
{
    public class LogicLL : IDisposable
    {             
        private UnitOfWork DataBase { get; } = new UnitOfWork();
        private IMapper mapper = ObjectMapper.Mapper;

        public IEnumerable<ClientLL> GetAllClients()
        {
            List<ClientLL> result = new List<ClientLL>();

            foreach (ClientDL client in DataBase.Clients.ReadAll())
                result.Add(mapper.Map<ClientLL>(client));
            return result;
        }

        public IEnumerable<DayLL> GetAllHolidays()
        {
            List<DayLL> result = new List<DayLL>();

            foreach (DayDL day in DataBase.Days.ReadAll())
                result.Add(mapper.Map<DayLL>(day));
            return result;
        }

        public IEnumerable<BookingLL> GetAllBookings()
        {
            List<BookingLL> result = new List<BookingLL>();

            foreach (BookingDL booking in DataBase.Bookings.ReadAll())
                result.Add(mapper.Map<BookingLL>(booking));
            return result;
        }

        public IEnumerable<RoomLL> GetAllRooms()
        {
            List<RoomLL> result = new List<RoomLL>();

            foreach (RoomDL room in DataBase.Rooms.ReadAll())
                result.Add(mapper.Map<RoomLL>(room));
            return result;
        }

        public IEnumerable<GuestLL> GetAllGuest()
        {
            List<GuestLL> result = new List<GuestLL>();
            
            foreach (GuestDL guest in DataBase.Guests.ReadAll())
                result.Add(mapper.Map<GuestLL>(guest));
            return result;
        }

        public void AddRoom(RoomLL room)
        {
            DataBase.Rooms.Create(mapper.Map<RoomDL>(room));
            DataBase.Save();
        }

        public void AddHoliday(DayLL day)
        {
            DataBase.Days.Create(mapper.Map<DayDL>(day));
            DataBase.Save();
        }

        public void AddClient(ClientLL client)
        {
            DataBase.Clients.Create(mapper.Map<ClientDL>(client));
            DataBase.Save();
        }
        public void AddBooking(BookingLL booking)
        {
            DataBase.Bookings.Create(mapper.Map<BookingDL>(booking));
            DataBase.Save();
        }

        public void UpdateClient(ClientLL client)
        {
            DataBase.Clients.Update(mapper.Map<ClientDL>(client));
            DataBase.Save();
        }       

        
        public void Dispose()
        {
            DataBase.Dispose();
        }

    }
}
