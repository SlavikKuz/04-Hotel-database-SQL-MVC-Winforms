using HotelDb.DataLayer.Context;
using HotelDb.DataLayer.Entities;
using HotelDb.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.DataLayer.Repositories
{
    public class DayRepository : IRepository<DayDL>
    {
        private HotelDbContext database; 

        public DayRepository(HotelDbContext context)
        {
            database = context;
        }

        public void Create(DayDL day)
        {
            database.Holidays.Add(day);
        }

        public void Delete(int id)
        {
            DayDL day = database.Holidays.Find(id);
            if(day != null)
            {
                database.Holidays.Remove(day);
            }
        }

        public DayDL Read(int id)
        {
            return database.Holidays.Find(id);
        }

        public IEnumerable<DayDL> ReadAll()
        {
            return database.Holidays;
        }

        public void Update(DayDL day)
        {
            database.Holidays.Update(day);
        }
    }
}
