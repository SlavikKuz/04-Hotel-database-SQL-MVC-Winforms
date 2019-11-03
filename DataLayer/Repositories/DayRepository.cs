using HotelDb.DataLayer.Context;
using HotelDb.DataLayer.Entities;
using HotelDb.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.DataLayer.Repositories
{
    public class DayRepository : IRepository<DayModel>
    {
        private HotelDbContext database; 

        public DayRepository(HotelDbContext context)
        {
            database = context;
        }

        public void Create(DayModel day)
        {
            database.Holidays.Add(day);
        }

        public void Delete(int id)
        {
            DayModel day = database.Holidays.Find(id);
            if(day != null)
            {
                database.Holidays.Remove(day);
            }
        }

        public DayModel Read(int id)
        {
            return database.Holidays.Find(id);
        }

        public IEnumerable<DayModel> ReadAll()
        {
            return database.Holidays;
        }

        public void Update(DayModel day)
        {
            database.Holidays.Update(day);
        }
    }
}
