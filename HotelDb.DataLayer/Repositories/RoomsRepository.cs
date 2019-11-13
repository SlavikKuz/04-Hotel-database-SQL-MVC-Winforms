using HotelDb.DataLayer.Context;
using HotelDb.DataLayer.Entities;
using HotelDb.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.DataLayer.Repositories
{
    public class RoomsRepository:IRepository<RoomDL>
    {
        private HotelDbContext database;

        public RoomsRepository(HotelDbContext context)
        {
            database = context;
        }

        public void Create(RoomDL room)
        {
            database.Rooms.Add(room);
        }

        public RoomDL Read(int id)
        {
            return database.Rooms.Find(id);
        }

        public IEnumerable<RoomDL> ReadAll()
        {
            return database.Rooms;
        }

        public void Update(RoomDL room)
        {
            database.Rooms.Attach(room);
            database.Entry(room).Property(x => x.RoomNumber).IsModified = true;
            database.Entry(room).Property(x => x.NumberBeds).IsModified = true;
            database.Entry(room).Property(x => x.Description).IsModified = true;
            database.Entry(room).Property(x => x.Floor).IsModified = true;
            database.Entry(room).Property(x => x.RoomInfo).IsModified = true;
            database.Entry(room).Property(x => x.Ready).IsModified = true;
        }

        public void Delete(Guid id)
        {
            RoomDL room = database.Rooms.Find(id);
            if (room != null)
            {
                database.Rooms.Remove(room);
            }
        }
    }
}
