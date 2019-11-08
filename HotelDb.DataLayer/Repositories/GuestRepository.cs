using HotelDb.DataLayer.Context;
using HotelDb.DataLayer.Entities;
using HotelDb.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.DataLayer.Repositories
{
    public class GuestRepository : IRepository<GuestsListDL>
    {
        private HotelDbContext database;

        public GuestRepository(HotelDbContext context)
        {
            database = context;
        }

        public void Create(GuestsListDL guest)
        {
            database.GuestsList.Add(guest);
        }

        public void Delete(int id)
        {
            GuestsListDL guest = database.GuestsList.Find(id);
            if (guest != null)
            {
                database.GuestsList.Remove(guest);
            }
        }

        public GuestsListDL Read(int id)
        {
            return database.GuestsList.Find(id);
        }

        public IEnumerable<GuestsListDL> ReadAll()
        {
            return database.GuestsList;
        }

        public void Update(GuestsListDL guest)
        {
            database.GuestsList.Update(guest);
        }
    }
}
