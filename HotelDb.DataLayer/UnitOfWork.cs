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

        private BookedRoomsListRepository bookedRoomListsRepository;
        private BookingRepository bookingRepository;
        private ClientRepository clientRepository;
        private GuestsListRepository guestsListRepository;
        private HolidayRepository holidayRepository;
        private InvoiceRepository invoiceRepository;
        private RoomPriceRepository roomPriceRepository;
        private RoomRepository roomsRepository;

        public IRepository<BookedRoomsListDL> BookedRoomsList
        {
            get
            {
                if (bookedRoomListsRepository == null)
                    bookedRoomListsRepository = new BookedRoomsListRepository(DataBase);
                return bookedRoomListsRepository;
            }
        }
        public IRepository<BookingDL> Bookings
        {
            get
            {
                if (bookingRepository == null)
                    bookingRepository = new BookingRepository(DataBase);
                return bookingRepository;
            }
        }
        public IRepository<ClientDL> Clients
        {
            get
            {
                if (clientRepository == null)
                    clientRepository = new ClientRepository(DataBase);
                return clientRepository;
            }
        }
        public IRepository<GuestsListDL> GuestsList
        {
            get
            {
                if (guestsListRepository == null)
                    guestsListRepository = new GuestsListRepository(DataBase);
                return guestsListRepository;
            }
        }
        public IRepository<HolidaysListDL> HolidaysList
        {
            get
            {
                if (holidayRepository == null)
                    holidayRepository = new HolidayRepository(DataBase);
                return holidayRepository;
            }
        }
        public IRepository<InvoiceDL> Invoices
        {
            get
            {
                if (invoiceRepository == null)
                    invoiceRepository = new InvoiceRepository(DataBase);
                return invoiceRepository;
            }
        }
        public IRepository<RoomPriceDL> RoomPrices
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
                    roomsRepository = new RoomRepository(DataBase);
                return roomsRepository;
            }
        }

        public UnitOfWork()
        {
            DataBase = new HotelDbContext();
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
