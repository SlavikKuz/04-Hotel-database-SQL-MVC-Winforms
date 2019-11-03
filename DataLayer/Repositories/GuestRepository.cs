using HotelDb.DataLayer.Context;
using HotelDb.DataLayer.Entities;
using HotelDb.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.DataLayer.Repositories
{
    public class GuestRepository : IRepository<GuestModel>
    {
        private HotelDbContext database;

        public GuestRepository(HotelDbContext context)
        {
            database = context;
        }

        public void Create(GuestModel guest)
        {
            database.Guests.Add(guest);
        }

        public void Delete(int id)
        {
            GuestModel guest = database.Guests.Find(id);
            if (guest != null)
            {
                database.Guests.Remove(guest);
            }
        }

        public GuestModel Read(int id)
        {
            return database.Guests.Find(id);
        }

        public IEnumerable<GuestModel> ReadAll()
        {
            return database.Guests;
        }

        public void Update(GuestModel guest)
        {
            database.Guests.Update(guest);
        }
    }
}
