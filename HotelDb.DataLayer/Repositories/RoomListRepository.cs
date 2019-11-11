using HotelDb.DataLayer.Context;
using HotelDb.DataLayer.Entities;
using HotelDb.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.DataLayer.Repositories
{
    public class RoomListRepository:IRepository<RoomListDL>
    {
        private HotelDbContext database;

        public RoomListRepository(HotelDbContext context)
        {
            database = context;
        }

        public void Create(RoomListDL bookingRoomList)
        {
            database.RoomList.Add(bookingRoomList);
        }

        public void Delete(long id)
        {
            RoomListDL bookingRoomList = database.RoomList.Find(id);
            if (bookingRoomList != null)
            {
                database.RoomList.Remove(bookingRoomList);
            }
        }

        public RoomListDL Read(int id)
        {
            return database.RoomList.Find(id);
        }

        public IEnumerable<RoomListDL> ReadAll()
        {
            return database.RoomList;
        }

        public void Update(RoomListDL booking)
        {
            database.RoomList.Update(booking);
        }
    }
}
