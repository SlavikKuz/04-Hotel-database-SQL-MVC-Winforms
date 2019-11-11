using HotelDb.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<RoomListDL> RoomList { get; }
        IRepository<BookingDL> Bookings { get; }
        IRepository<ClientDL> Clients { get; }
        IRepository<GuestListDL> GuestList { get; }
        IRepository<HolidayListDL> HolidayList { get; }
        IRepository<InvoiceDL> Invoices { get; }
        IRepository<RoomDL> Rooms { get; }
        IRepository<RoomPriceDL> RoomPrice { get; }
        void Save();
    }
}
