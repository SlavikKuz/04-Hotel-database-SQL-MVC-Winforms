using HotelDb.DataLayer.Context;
using HotelDb.DataLayer.Interfaces;
using HotelDb.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.DataLayer.Repositories
{
    public class BookingRepository : IRepository<BookingModel>
    {
        private HotelDbContext database;

        public BookingRepository(HotelDbContext context)
        {
            database = context;
        }

        public void Create(BookingModel booking)
        {
            database.Bookings.Add(booking);
        }

        public void Delete(int id)
        {
            BookingModel booking = database.Bookings.Find(id);
            if (booking != null)
            {
                database.Bookings.Remove(booking);
            }
        }

        public BookingModel Read(int id)
        {
            return database.Bookings.Find(id);
        }

        public IEnumerable<BookingModel> ReadAll()
        {
            return database.Bookings;
        }

        public void Update(BookingModel booking)
        {
            database.Bookings.Update(booking);
        }
    }
}
