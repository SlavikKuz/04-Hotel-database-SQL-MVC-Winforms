using HotelDb.DataLayer.Context;
using HotelDb.DataLayer.Entities;
using HotelDb.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.DataLayer.Repositories
{
    public class RoomPriceRepository : IRepository<RoomPriceDL>
    {
        private HotelDbContext database;

        public RoomPriceRepository(HotelDbContext context)
        {
            database = context;
        }

        public void Create(RoomPriceDL roomPrice)
        {
            database.RoomPrice.Add(roomPrice);
        }

        public RoomPriceDL Read(int id)
        {
            return database.RoomPrice.Find(id);
        }

        public IEnumerable<RoomPriceDL> ReadAll()
        {
            return database.RoomPrice;
        }

        public void Update(RoomPriceDL roomPrice)
        {
            database.RoomPrice.Update(roomPrice);
        }

        public void Delete(Guid id)
        {
            RoomPriceDL roomPrice = database.RoomPrice.Find(id);
            if (roomPrice != null)
            {
                database.RoomPrice.Remove(roomPrice);
            }
        }
    }
}
