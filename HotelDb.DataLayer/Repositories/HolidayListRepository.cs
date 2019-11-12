using HotelDb.DataLayer.Context;
using HotelDb.DataLayer.Entities;
using HotelDb.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.DataLayer.Repositories
{
    public class HolidayListRepository : IRepository<HolidayListDL>
    {
        private HotelDbContext database; 

        public HolidayListRepository(HotelDbContext context)
        {
            database = context;
        }

        public void Create(HolidayListDL day)
        {
            database.HolidayList.Add(day);
        }

        public HolidayListDL Read(int id)
        {
            return database.HolidayList.Find(id);
        }

        public IEnumerable<HolidayListDL> ReadAll()
        {
            return database.HolidayList;
        }

        public void Update(HolidayListDL day)
        {
            database.HolidayList.Update(day);
        }

        public void Delete(long holidayId)
        {
            HolidayListDL day = database.HolidayList.Find(holidayId);
            if (day != null)
            {
                database.HolidayList.Remove(day);
            }
        }    
    }
}
