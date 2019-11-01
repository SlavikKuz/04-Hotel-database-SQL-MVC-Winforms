using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HotelDB.Model
{
    public class Calendar
    {
        private SQL sql;

        public Calendar(SQL sql)
        {
            this.sql = sql;
        }

        public void InsertDays(int year)
        // create a calendar for selected year;
        {
            DateTime day = new DateTime(year,1,1);

            while (day.Year == year)
            {
                int weekend = 0;
                if (day.DayOfWeek == DayOfWeek.Friday ||
                    day.DayOfWeek == DayOfWeek.Saturday ||
                    day.DayOfWeek == DayOfWeek.Sunday)
                    weekend = 1;

                //code in mySQL. Ignores if the line is already in th table
                //string query =
                //    "INSERT IGNORE INTO Calendar " +
                //    "SET day = '" + day.ToString("yyyy-MM-dd") + "'," +
                //    "weekend = " + weekend + "," +
                //    "holiday = 0;";

                //possible in TSQL
                int holiday = 0;
                string query =
                "INSERT INTO Calendar (day,weekend,holiday) VALUES (" +
                    "'" + day.ToString("yyyy-MM-dd") + "'," +
                    weekend + "," + holiday + ") ";

                do
                this.sql.Insert(query);
                while (sql.SqlError());
                day = day.AddDays(1);
            }
        }

        private void SetHoliday(DateTime day, bool holiday)
        // mark some days as holiday/days off;
        {     
            string query = "UPDATE Calendar SET holiday =" +
                (holiday ? "1" : "0") +
                " WHERE day ='" + day.ToString("yyyy-MM-dd") + "'";

            do this.sql.Update(query);
            while (sql.SqlError());
        }

        public void AddHoliday(DateTime day)
        {
            SetHoliday(day, true);
        }

        public void RemoveHoliday(DateTime day)
        {
            SetHoliday(day, false);
        }
    }
}
