using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelDB;
using HotelDB.Model;

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

        [TestMethod]
        public void TestSqlConnection()
        {
            string result = sql.Scalar("SELECT max(id) FROM Client");
            Assert.AreEqual(result, "7");
        }

        [TestMethod]
        public void TestCalendarAddDays()
        {
            Calendar calendar = new Calendar(sql);
            calendar.InsertDays(2019);          
        }
    }
}
