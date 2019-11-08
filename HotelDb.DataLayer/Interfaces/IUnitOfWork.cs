using HotelDb.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<ClientDL> Clients { get; }
        IRepository<BookingDL> Bookings { get; }
        IRepository<RoomDL> Rooms { get; }
        IRepository<HolidaysListDL> Days { get; }
        IRepository<GuestsListDL> Guests { get; }
        void Save();
    }
}
