using HotelDb.DataLayer.Context;
using HotelDb.DataLayer.Entities;
using HotelDb.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.DataLayer.Repositories
{
    public class HolidaysRepository : IRepository<HolidaysListDL>
    {
        private HotelDbContext database; 

        public HolidaysRepository(HotelDbContext context)
        {
            database = context;
        }

        public void Create(HolidaysListDL day)
        {
            database.HolidaysList.Add(day);
        }

        public void Delete(int id)
        {
            HolidaysListDL day = database.HolidaysList.Find(id);
            if(day != null)
            {
                database.HolidaysList.Remove(day);
            }
        }

        public HolidaysListDL Read(int id)
        {
            return database.HolidaysList.Find(id);
        }

        public IEnumerable<HolidaysListDL> ReadAll()
        {
            return database.HolidaysList;
        }

        public void Update(HolidaysListDL day)
        {
            database.HolidaysList.Update(day);
        }
    }
}
