using HotelDb.DataLayer.Context;
using HotelDb.DataLayer.Entities;
using HotelDb.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.DataLayer.Repositories
{
    public class GuestRepository : IRepository<GuestDL>
    {
        private HotelDbContext database;

        public GuestRepository(HotelDbContext context)
        {
            database = context;
        }

        public void Create(GuestDL guest)
        {
            database.Guests.Add(guest);
        }

        public void Delete(int id)
        {
            GuestDL guest = database.Guests.Find(id);
            if (guest != null)
            {
                database.Guests.Remove(guest);
            }
        }

        public GuestDL Read(int id)
        {
            return database.Guests.Find(id);
        }

        public IEnumerable<GuestDL> ReadAll()
        {
            return database.Guests;
        }

        public void Update(GuestDL guest)
        {
            database.Guests.Update(guest);
        }
    }
}
