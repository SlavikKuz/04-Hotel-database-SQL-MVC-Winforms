using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelDB;
using HotelDB.Model;
using System.Data;

namespace TestHotel
{
    [TestClass]
    public class DBTest
    {
        SQL sql;

        public DBTest()
        {
            sql = new SQL();
        }

        //[TestMethod]
        //public void TestSqlConnection()
        //{
        //    string result = sql.Scalar("SELECT max(id) FROM Client");
        //    Assert.AreEqual(result, "7");
        //}

        //[TestMethod]
        //public void TestCalendarAddDays()
        //{
        //    Calendar calendar = new Calendar(sql);
        //    calendar.InsertDays(2019);
        //}

        //[TestMethod]
        //public void TestCalendarHoliday()
        //{
        //    Calendar calendar = new Calendar(sql);
        //    calendar.AddHoliday(new DateTime(2019, 1, 22));

        //    string days = sql.Scalar(
        //        "SELECT COUNT(*) " +
        //        " FROM Calendar " +
        //        " WHERE day = '2019-01-22' " +
        //        "AND holiday = 1");
        //    Assert.AreEqual(days, "1");
        //}

        [TestMethod]
        public void TestRoom()
        {
            Room room = new Room(sql);
            int  room_id;
            string roomInfo1 = "Info01";
            string roomInfo2 = "Info02";

            room.SetBeds(1);
            room.SetRoom("My room 42");
            room.SetFloor("Attic");
            room.SetInfo(roomInfo1);
                       
            Assert.IsTrue(room.InsertRoom());
            room_id = int.Parse(room.id.ToString());

            DataTable table = room.SelectRooms();
            bool found = false;
            foreach(DataRow row in table.Rows)
            {
                if(row["info"].ToString() == roomInfo1)
                    if (row["id"].ToString() == room_id.ToString())
                    {
                        found = true;
                        break;
                    }
            }

            Assert.IsTrue(found);

            Room room1 = new Room(sql);
            Assert.IsTrue(room1.SelectRoom(room_id));

            room1.SetInfo(roomInfo2);                               
            Assert.IsTrue(room1.UpdateRoom());

            Room room2 = new Room(sql);
            Assert.IsTrue(room2.SelectRoom(room_id));

            Assert.AreEqual(roomInfo2, room2.info);

            Assert.IsTrue(room.DeleteRoom(room_id));

            Assert.IsFalse(room.SelectRoom(room_id));
        }
    }
}
