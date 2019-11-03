using HotelDb.DataLayer.Context;
using HotelDb.DataLayer.Entities;
using HotelDb.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.DataLayer.Repositories
{
    public class RoomRepository:IRepository<RoomModel>
    {
        private HotelDbContext database;

        public RoomRepository(HotelDbContext context)
        {
            database = context;
        }

        public void Create(RoomModel room)
        {
            database.Rooms.Add(room);
        }

        public void Delete(int id)
        {
            RoomModel room = database.Rooms.Find(id);
            if (room != null)
            {
                database.Rooms.Remove(room);
            }
        }

        public RoomModel Read(int id)
        {
            return database.Rooms.Find(id);
        }

        public IEnumerable<RoomModel> ReadAll()
        {
            return database.Rooms;
        }

        public void Update(RoomModel room)
        {
            database.Rooms.Update(room);
        }
    }
}
