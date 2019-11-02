using HotelDB.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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

        public ClientModel GetClientsAll(int clientPosition)
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
                               "OR notes LIKE '%" + clientSearch + "%' " +
                               "OR id = '" + clientSearch + "';";

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
                        Client_full_name = reader["client_full_name"].ToString(),
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
                           client.Client_full_name + "','" +
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
                           "client_full_name = '" + client.Client_full_name + "', " +
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
    }
}
