using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDB.Model
{
    public class Book
    {
        private SQL sql;

        public long id { get; private set; }
        public long client_id { get; private set; }
        public DateTime order_date { get; private set; }
        public DateTime day_from { get; private set; }
        public DateTime day_till { get; private set; }
        public int adults { get; private set; }
        public int kids { get; private set; }
        public string status { get; private set; }
        public string info { get; private set; }

        /// <summary>
        /// constructor of the class
        /// </summary>
        public Book()
        {
            id = 0;
            this.sql = sql;
        }

        public void SetOrderDate(DateTime order_date)
        {
            this.order_date = order_date;
        }
        public void SetDayFrom(DateTime day_from)
        {
            this.day_from = day_from;
        }
        public void SetDayTill(DateTime day_till)
        {
            this.day_till = day_till;
        }
        public void SetAdults(int adults)
        {
            this.adults = adults;
        }
        public void SetKids(int kids)
        {
            this.kids = kids;
        }
        public void SetStatus(string status)
        {
            this.status = status;
        }
        public void SetInfo(string info)
        {
            this.info = info;
        }

        /// <summary>
        /// add a new booking;
        /// </summary>
        public bool InsertBook(long client_id, DateTime day_from, DateTime day_till)
        {
            do this.id = this.sql.Insert(
                "INSERT INTO Order " +
                "SET client_id = '" + client_id + "'," +
                "order_date = NOW()," +
                "day_from = '" + day_from.ToString("yyyy-MM-dd") + "'," +
                "day_till = '" + day_till.ToString("yyyy-MM-dd") + "'," +
                "adults = '" + this.adults + "'," +
                "kids = '" + this.kids + "'," +
                "status = 'waiting'," +
                "info = '" + sql.AddSlash(this.info) + "'");
            while (this.sql.SqlError());
            return (this.id > 0);
        }

        /// <summary>
        /// get a list of reservations;
        /// </summary>
        /// <param name="book_id"></param>
        /// <returns>TRUE/FALSE</returns>
        public bool SelectBook(long book_id)
        {
            DataTable book;
            this.id = book_id;
            do book = sql.Select(
                "SELECT client_id, order_date, day_from, " +
                "day_till, adults, kids, status, info" +
                " FROM Order" +
                " WHERE id='" + sql.AddSlash(this.id.ToString()) + "'");
            while (sql.SqlError());

            if (book.Rows.Count == 0)
                return false;

            this.id = long.Parse(book.Rows[0]["id"].ToString());
            this.client_id = long.Parse(book.Rows[0]["client_id"].ToString());
            this.order_date = DateTime.Parse(book.Rows[0]["order_date"].ToString());
            this.day_from = DateTime.Parse(book.Rows[0]["day_from"].ToString());
            this.day_till = DateTime.Parse(book.Rows[0]["day_till"].ToString());
            this.adults = int.Parse(book.Rows[0]["adults"].ToString());
            this.kids = int.Parse(book.Rows[0]["kids"].ToString());
            this.status = book.Rows[0]["status"].ToString();
            this.info = book.Rows[0]["info"].ToString();
            return true;
        }

        /// <summary>
        /// change data for selected reservation;
        /// Only number of adults and kids, and info will be changed
        /// </summary>
        /// <returns>bool</returns>
        public bool UpdateBook()
        {
            if (this.id <= 0)
                return false;

            int result = 0;
            do result = sql.Update(
                "UPDATE Order " +
                "SET adults = '" + this.adults.ToString() + "'," +
                    "kids = '" + this.kids.ToString() + "'," +
                    "info = '" + sql.AddSlash(this.info) + "' " +
                    "WHERE id = '" + sql.AddSlash(this.id.ToString()) + "'");
            while (sql.SqlError());
            return result == 1;
        }
    }
}
