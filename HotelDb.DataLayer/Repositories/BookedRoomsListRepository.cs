using HotelDb.DataLayer.Context;
using HotelDb.DataLayer.Entities;
using HotelDb.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.DataLayer.Repositories
{
    public class BookedRoomsListRepository:IRepository<BookedRoomsListDL>
    {
        private HotelDbContext database;

        public BookedRoomsListRepository(HotelDbContext context)
        {
            database = context;
        }

        public void Create(BookedRoomsListDL bookingRoomList)
        {
            database.BookedRoomsList.Add(bookingRoomList);
        }

        public void Delete(int id)
        {
            BookedRoomsListDL bookingRoomList = database.BookedRoomsList.Find(id);
            if (bookingRoomList != null)
            {
                database.BookedRoomsList.Remove(bookingRoomList);
            }
        }

        public BookedRoomsListDL Read(int id)
        {
            return database.BookedRoomsList.Find(id);
        }

        public IEnumerable<BookedRoomsListDL> ReadAll()
        {
            return database.BookedRoomsList;
        }

        public void Update(BookedRoomsListDL booking)
        {
            database.BookedRoomsList.Update(booking);
        }
    }
}
