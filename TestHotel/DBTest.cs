using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelDB;

namespace TestHotel
{
    [TestClass]
    public class DBTest
    {
        [TestMethod]
        public void TestSqlConnection()
        {
            SQL sql;
            sql = new SQL();
            string result = sql.Scalar("SELECT max(id) FROM Client");
            Assert.AreEqual(result, "7");
        }
    }
}
