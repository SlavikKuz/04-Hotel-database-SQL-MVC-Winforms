using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDB.Model
{
    public class Room
    {
        private SQL sql;

        public long id { get; private set; }
        public string room { get; private set; }
        public int beds { get; private set; }
        public string floor { get; private set; }
        public int step { get; private set; }
        public string info  { get; private set; }

        public void SetRoom(string room)
        {
            this.room = room;
        }
        public void SetBeds(int beds)
        {
            this.beds = beds;
        }
        public void SetFloor(string floor)
        {
            this.floor = floor;
        }
        public void SetInfo(string info)
        {
            this.info = info;
        }



        /// <summary>
        /// Constructor for managing rooms
        /// </summary>
        /// <param name="sql"></param>
        public Room(SQL sql)
        {
            this.sql = sql;
            this.id = 0;
        }
        
        /// <summary>
        /// get a list of rooms;
        /// </summary>
        /// <returns></returns>
        public DataTable SelectRooms()
        {
            DataTable room;
            do room = sql.Select("SELECT id, room, beds, floor, step, info " +
                "FROM Room " +
                "ORDER BY step");
            while (sql.SqlError());

            return room;
        }

        /// <summary>
        /// add a new room;
        /// </summary>
        public bool InsertRoom()
        {
            string query = "INSERT INTO Room (room, beds, floor, info, step) " +
                    "VALUES('" +
                    sql.AddSlash(this.room) +
                    "','" + sql.AddSlash(this.beds.ToString()) +
                    "','" + sql.AddSlash(this.floor) +
                    "','" + sql.AddSlash(this.info) + "',0);";

            do this.id = this.sql.Insert(query);
            while (this.sql.SqlError());

            if (this.id <= 0) return false;

            do sql.Update("UPDATE Room " +
                "SET step = " + this.id.ToString() +
                " WHERE id = " + this.id.ToString());
            while (sql.SqlError());

            return true;
        }

        /// <summary>
        /// get info on selected room
        /// </summary>
        /// <param name="room_id"># room</param>
        /// <returns></returns>
        public bool SelectRoom(int room_id)
        {
            DataTable room;
            do room = sql.Select(
                "SELECT id, room, beds, floor, step, info " +
                "FROM Room " +
                "WHERE id = '" + sql.AddSlash(room_id.ToString()) + "'");
            while (sql.SqlError());

            if (room.Rows.Count == 0)
                return false;

            this.id = int.Parse(room.Rows[0]["id"].ToString());
            this.room = room.Rows[0]["room"].ToString();
            this.beds = int.Parse(room.Rows[0]["beds"].ToString());
            this.floor = room.Rows[0]["floor"].ToString();
            this.step = int.Parse(room.Rows[0]["step"].ToString());
            this.info = room.Rows[0]["info"].ToString();
            return true;
        }

        /// <summary>
        /// change data for selected room;
        /// </summary>
        /// <returns>bool</returns>
        public bool UpdateRoom()
        {
            if (this.id <= 0) return false;

            int result = 0;
            do result = sql.Update(
                "UPDATE Room " +
                "SET room = '" + sql.AddSlash(this.room) + "'," +
                    "beds = '" + sql.AddSlash(this.beds.ToString()) + "'," +
                    "floor = '" + sql.AddSlash(this.floor) + "'," +
                    "info = '" + sql.AddSlash(this.info) + "' " +
                    "WHERE id = '" + sql.AddSlash(this.id.ToString()) + "'");
            while (sql.SqlError());
            return result == 1;
        }

        /// <summary>
        /// Delete selected room in case of mistake or smth
        /// </summary>
        /// <param name="room_id"># room</param>
        /// <returns>TRUE/FALSE</returns>
        public bool DeleteRoom(int room_id)
        {
            int result = 0;
            do result = sql.Update(
                "DELETE FROM Room " +
                    "WHERE id = '" + sql.AddSlash(room_id.ToString()) + "'");
            while (sql.SqlError());
            return result == 1;
        }

    }
}
