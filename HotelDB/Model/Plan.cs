using System;
using System.Data;

namespace HotelDB.Model
{
    public class Plan
    {
        private SQL sql;

        long room_id;
        long order_id;
        DateTime calendar_day;

        public string status { get; private set; }
        public int adults { get; private set; }
        public int kids { get; private set; }

        public Plan()
        {
            this.sql = sql;
        }

        public void SetStatus(string status)
        {
            this.status = status;
        }

        public void SetAdults(int adults)
        {
            this.adults = adults;
        }

        public void SetKids(int kids)
        {
            this.kids = kids;
        }

        //generated automatically new method .DateToString()
        public void SelectPlan(long room_id, long order_id, DateTime calendar_day)
        {
            this.room_id = room_id;
            this.order_id = order_id;
            this.calendar_day = calendar_day;

            //DateToString, class SQL checks and does not allow insertions
            DataTable plan;
            do plan = sql.Select(
                "SELECT status, adults, kids " +
                " FROM HotelPlan " +
                " WHERE room_id = '" + sql.AddSlash(this.room_id.ToString()) + "'" +
                "AND order_id = '" + sql.AddSlash(this.order_id.ToString()) + "'" +
                "AND calendar_day = '" + sql.DateToString(this.calendar_day) + "';");
            while (sql.SqlError());

            if (plan.Rows.Count == 0)
            {
                InsertPlanDefault();
            }
            else
            {
                this.status = plan.Rows[0]["status"].ToString();
                this.kids = int.Parse(plan.Rows[0]["kids"].ToString());
                this.adults = int.Parse(plan.Rows[0]["adults"].ToString());
            }
        }

        private void InsertPlanDefault()
        {
            this.status = "none";
            this.adults = 0;
            this.kids = 0;
            InsertPlan();
        }

        public void InsertPlan()//test way of writing SQL query
        {
            //insert does not return id. It is not an autoincrement key in HotelPlan table
            do this.sql.Insert(
                @"INSERT INTO HotelPlan
                    SET room_id = " + this.room_id + @",
                    order_id = " + this.order_id + @",
                    calendar_day = '" + this.sql.DateToString(this.calendar_day) + @",
                    status = '" + this.status + @"',
                    adults = " + this.adults + @",
                    kids = " + this.kids);
            while (sql.SqlError());   
        }

    }
}
