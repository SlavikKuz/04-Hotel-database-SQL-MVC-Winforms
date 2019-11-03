using HotelDb.DataLayer.Context;
using HotelDb.DataLayer.Entities;
using HotelDb.DataLayer.Interfaces;
using HotelDb.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private HotelDbContext DataBase { get; }

        private ClientRepository clientsRepository;
        private BookingRepository bookingsRepository;
        private RoomRepository roomsRepository;
        private DayRepository holidaysRepository;
        private GuestRepository guestsRepository;

        public IRepository<ClientModel> Clients
        {
            get
            {
                if (clientsRepository == null)
                    clientsRepository = new ClientRepository(DataBase);
                return clientsRepository;
            }
        }
        public IRepository<BookingModel> Bookings
        {
            get
            {
                if (bookingsRepository == null)
                    bookingsRepository = new BookingRepository(DataBase);
                return bookingsRepository;
            }
        }
        public IRepository<RoomModel> Rooms
        {
            get
            {
                if (roomsRepository == null)
                    roomsRepository = new RoomRepository(DataBase);
                return roomsRepository;
            }
        }
        public IRepository<DayModel> Days
        {
            get
            {
                if (holidaysRepository == null)
                    holidaysRepository = new DayRepository(DataBase);
                return holidaysRepository;
            }
        }
        public IRepository<GuestModel> Guests
        {
            get
            {
                if (guestsRepository == null)
                    guestsRepository = new GuestRepository(DataBase);
                return guestsRepository;
            }
        }

        public UnitOfWork(HotelDbContext context)
        {
            DataBase = context;
        }

        public void Save()
        {
            DataBase.SaveChanges();
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
