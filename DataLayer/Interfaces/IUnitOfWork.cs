using HotelDb.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<ClientModel> Clients { get; }
        IRepository<BookingModel> Bookings { get; }
        IRepository<RoomModel> Rooms { get; }
        IRepository<DayModel> Days { get; }
        IRepository<GuestModel> Guests { get; }
        void Save();
    }
}
