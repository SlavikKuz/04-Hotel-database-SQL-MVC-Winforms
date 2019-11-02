using HotelDB.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelDB.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        private const string db = "ht_localdb_30102019";

        //SQL queries, not stored procedures
        public List<ClientModel> GetClientsAll()
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Client", connection))
                    return FillListOfClientModels(command);
            }
        }

        public ClientModel GetClient(int clientPosition)
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Client " +
                    "WHERE id = '" + clientPosition + "';", connection))
                    return FillListOfClientModels(command).First();
            }
        }

        public List<ClientModel> GetClientsAll(string clientSearch)
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                connection.Open();
                string query = "SELECT * FROM Client " +
                               "WHERE client_full_name LIKE '%" + clientSearch + "%' " +
                               "OR email LIKE '%" + clientSearch + "%' " +
                               "OR tel LIKE '%" + clientSearch + "%' " +
                               "OR address LIKE '%" + clientSearch + "%' " +
                               "OR notes LIKE '%" + clientSearch + "%' ";
                
                if (Regex.Matches(clientSearch, @"[a-zA-Z]").Count == 0)
                query = query + "OR id = '" + clientSearch + "';";

                using (SqlCommand command = new SqlCommand(query, connection))
                    return FillListOfClientModels(command);
            }
        }

        public List<ClientModel> FillListOfClientModels(SqlCommand command)
        {
            List<ClientModel> output = new List<ClientModel>();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ClientModel client = new ClientModel()
                    {
                        Id = (int)reader["id"],
                        ClientFullName = reader["client_full_name"].ToString(),
                        Email = reader["email"].ToString(),
                        Tel = reader["tel"].ToString(),
                        Address = reader["address"].ToString(),
                        Notes = reader["notes"].ToString()
                    };
                    output.Add(client);
                }
            }
            return output;
        }

        public void CreateClient(ClientModel client)
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                int rows = 0;
                connection.Open();
                string query = "INSERT INTO Client (" +
                           "client_full_name, email, tel, address, notes) VALUES ('" +
                           client.ClientFullName + "','" +
                           client.Email + "','" +
                           client.Tel + "','" +
                           client.Address + "','" +
                           client.Notes + "');";
                SqlCommand command = new SqlCommand(query, connection);

                MessageBox.Show(query.ToString());

                rows = command.ExecuteNonQuery();

                if (rows > 0)
                {
                    command = new SqlCommand("SELECT max(id) FROM Client", connection);
                    client.Id = (Int32)command.ExecuteScalar();
                }
            }
        }

        public void UpdateClient(ClientModel client)
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                int rows = 0;
                connection.Open();
                string query = "UPDATE Client SET" +
                           "client_full_name = '" + client.ClientFullName + "', " +
                           "email = '" + client.Email + "', " +
                           "tel = '" + client.Tel + "', " +
                           "address = '" + client.Address + "', " +
                           "notes = '" + client.Notes + "' " +
                           "WHERE id = '" + client.Id.ToString() + "'";

                SqlCommand command = new SqlCommand(query, connection);

                MessageBox.Show(query.ToString());

                rows = command.ExecuteNonQuery();

                if (rows > 0)
                {
                    command = new SqlCommand("SELECT max(id) FROM Client", connection);
                    client.Id = (Int32)command.ExecuteScalar();
                }
            }
        }

        public List<BookingModel> GetBookingsAll()
        {
            //TODO booking
            throw new NotImplementedException();
        }

        public List<BookingModel> GetBookingsAll(int clientId)
        {
            //TODO booking
            throw new NotImplementedException();
        }

        public List<BookingModel> GetBookingsAll(DateTime date)
        {
            //TODO booking
            throw new NotImplementedException();
            //    this.day_from = DateTime.Parse(book.Rows[0]["day_from"].ToString());
            //    this.day_till = DateTime.Parse(book.Rows[0]["day_till"].ToString());
        }

        public List<BookingModel> GetBookingsAll(string status)
        {
            //TODO booking
            throw new NotImplementedException();
            //    if (status != "waiting" &&
            //        status != "confirmed" &&
            //        status != "deleted")
            //        return false;

            //    int result;
            //    do result = sql.Update(
            //       "UPDATE Order " +
            //       "SET status = '" + status + "'," +
            //           "WHERE id = '" + sql.AddSlash(this.id.ToString()) + "'");
            //    while (false);
        }

        public BookingModel GetBooking(int bookingId)
        {
            //TODO booking
            throw new NotImplementedException();
            //    this.id = book_id;
            //    do book = sql.Select(
            //        "SELECT client_id, order_date, day_from, " +
            //        "day_till, adults, kids, status, info" +
            //        " FROM Order" +
            //        " WHERE id='" + sql.AddSlash(this.id.ToString()) + "'");
        }

        public void CreateBooking(BookingModel booking)
        {
            //TODO booking
            throw new NotImplementedException();
        //    "INSERT INTO Order " +
        //        "SET client_id = '" + client_id + "'," +
        //        "order_date = NOW()," +
        //        //"day_from = '" + day_from.ToString("yyyy-MM-dd") + "'," +
        //        //"day_till = '" + day_till.ToString("yyyy-MM-dd") + "'," +
        //        "day_from = '" + sql.DateToString(day_from) + "'," +
        //        "day_till = '" + sql.DateToString(day_till) + "'," +
        //        "adults = '" + this.adults + "'," +
        //        "kids = '" + this.kids + "'," +
        //        "status = 'waiting'," +
        //        "info = '" + sql.AddSlash(this.info) + "'");
        }

        public void UpdateBooking(BookingModel booking)
        {
            //TODO booking
            throw new NotImplementedException();
        }

        public void DeactivateBooking(BookingModel booking)
        {
            //TODO
            //bookings are never deleted, change status only, seen in history
            throw new NotImplementedException();
        }

        public decimal GetPriceOnDay(DayModel day)
        {
            day.CheckWeekend();
            throw new NotImplementedException();
            //it will check the day while booking.
            //normal day - average, weekend - highter, holiday - highest price

            //2. SQL Table will contain only holidays
            //3. Methods checks if date is holiday form the table.
        }

        public List<RoomModel> GetRoomsAll()
        {
            //TODO
            throw new NotImplementedException();
            //    do room = sql.Select("SELECT id, room, beds, floor, step, info " +
            //        "FROM Room " +
            //        "ORDER BY step");
        }

        public RoomModel GetRoom(int roomId)
        {
            //TODO
            throw new NotImplementedException();
            //    do room = sql.Select(
            //        "SELECT id, room, beds, floor, step, info " +
            //        "FROM Room " +
            //        "WHERE id = '" + sql.AddSlash(room_id.ToString()) + "'");
        }

        public void CreateHoliday(DayModel day)
        {
            //TODO
            throw new NotImplementedException();
        }

        public void DeleteHoliday(DayModel day)
        {
            //TODO
            throw new NotImplementedException();
        }

        public void CreateRoom(RoomModel room)
        {
            //TODO
            throw new NotImplementedException();
            //    string query = "INSERT INTO Room (room, beds, floor, info, step) " +
            //            "VALUES('" +
            //            sql.AddSlash(this.room) +
            //            "','" + sql.AddSlash(this.beds.ToString()) +
            //            "','" + sql.AddSlash(this.floor) +
            //            "','" + sql.AddSlash(this.info) + "',0);";
        }

        public void UpdateRoom(RoomModel room)
        {
            //TODO
            throw new NotImplementedException();
            //        "UPDATE Room " +
            //        "SET room = '" + sql.AddSlash(this.room) + "'," +
            //            "beds = '" + sql.AddSlash(this.beds.ToString()) + "'," +
            //            "floor = '" + sql.AddSlash(this.floor) + "'," +
            //            "info = '" + sql.AddSlash(this.info) + "' " +
            //            "WHERE id = '" + sql.AddSlash(this.id.ToString()) + "'");
        }

        public void DeleteRoom(RoomModel room)
        {
            //TODO:
            throw new NotImplementedException();
            //        "DELETE FROM Room " +
            //            "WHERE id = '" + sql.AddSlash(room_id.ToString()) + "'");

        }
    }
}
