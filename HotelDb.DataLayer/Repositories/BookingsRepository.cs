using HotelDb.DataLayer.Context;
using HotelDb.DataLayer.Interfaces;
using HotelDb.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.DataLayer.Repositories
{
    public class BookingsRepository : IRepository<BookingDL>
    {
        private HotelDbContext database;

        public BookingsRepository(HotelDbContext context)
        {
            database = context;
        }

        public void Create(BookingDL booking)
        {
            database.Bookings.Add(booking);
        }

        public BookingDL Read(int id)
        {
            return database.Bookings.Find(id);
        }

        public IEnumerable<BookingDL> ReadAll()
        {
            return database.Bookings;
        }

        public void Update(BookingDL booking)
        {
            database.Bookings.Update(booking);
        }

        public void Delete(Guid id)
        {
            BookingDL booking = database.Bookings.Find(id);
            if (booking != null)
            {
                database.Bookings.Remove(booking);
            }
        }
    }
}
