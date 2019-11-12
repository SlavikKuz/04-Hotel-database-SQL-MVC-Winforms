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

        private BookingsRepository bookingsRepository;
        private ClientsRepository clientsRepository;
        private GuestListRepository guestListRepository;
        private HolidayListRepository holidayListRepository;
        private InvoicesRepository invoicesRepository;
        private RoomPriceRepository roomPriceRepository;
        private RoomsRepository roomsRepository;
        private RoomListRepository roomListRepository;

        public UnitOfWork()
        {
            DataBase = new HotelDbContext();
        }

        public IRepository<BookingDL> Bookings
        {
            get
            {
                if (bookingsRepository == null)
                    bookingsRepository = new BookingsRepository(DataBase);
                return bookingsRepository;
            }
        }
        public IRepository<ClientDL> Clients
        {
            get
            {
                if (clientsRepository == null)
                    clientsRepository = new ClientsRepository(DataBase);
                return clientsRepository;
            }
        }
        public IRepository<GuestListDL> GuestList
        {
            get
            {
                if (guestListRepository == null)
                    guestListRepository = new GuestListRepository(DataBase);
                return guestListRepository;
            }
        }
        public IRepository<HolidayListDL> HolidayList
        {
            get
            {
                if (holidayListRepository == null)
                    holidayListRepository = new HolidayListRepository(DataBase);
                return holidayListRepository;
            }
        }
        public IRepository<InvoiceDL> Invoices
        {
            get
            {
                if (invoicesRepository == null)
                    invoicesRepository = new InvoicesRepository(DataBase);
                return invoicesRepository;
            }
        }
        public IRepository<RoomPriceDL> RoomPrice
        {
            get
            {
                if (roomPriceRepository == null)
                    roomPriceRepository = new RoomPriceRepository(DataBase);
                return roomPriceRepository;
            }
        }
        public IRepository<RoomDL> Rooms
        {
            get
            {
                if (roomsRepository == null)
                    roomsRepository = new RoomsRepository(DataBase);
                return roomsRepository;
            }
        }
        public IRepository<RoomListDL> RoomList
        {
            get
            {
                if (roomListRepository == null)
                    roomListRepository = new RoomListRepository(DataBase);
                return roomListRepository;
            }
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
