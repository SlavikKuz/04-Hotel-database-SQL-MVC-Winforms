using HotelDb.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<BookedRoomsListDL> BookedRoomsList { get; }
        IRepository<BookingDL> Bookings { get; }
        IRepository<ClientDL> Clients { get; }
        IRepository<GuestsListDL> GuestsList { get; }
        IRepository<HolidaysListDL> HolidaysList { get; }
        IRepository<InvoiceDL> Invoices { get; }
        IRepository<RoomDL> Rooms { get; }
        IRepository<RoomPriceDL> RoomPrices { get; }
        void Save();
    }
}
