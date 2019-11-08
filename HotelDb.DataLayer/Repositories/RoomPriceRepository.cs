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
            database.RoomPrices.Add(roomPrice);
        }

        public void Delete(int id)
        {
            RoomPriceDL roomPrice = database.RoomPrices.Find(id);
            if (roomPrice != null)
            {
                database.RoomPrices.Remove(roomPrice);
            }
        }

        public RoomPriceDL Read(int id)
        {
            return database.RoomPrices.Find(id);
        }

        public IEnumerable<RoomPriceDL> ReadAll()
        {
            return database.RoomPrices;
        }

        public void Update(RoomPriceDL roomPrice)
        {
            database.RoomPrices.Update(roomPrice);
        }
    }
}
