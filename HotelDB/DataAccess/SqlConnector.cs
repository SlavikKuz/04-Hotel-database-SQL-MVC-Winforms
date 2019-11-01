using HotelDB.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDB.DataAccess
{
    public class SqlConnector:IDataConnection
    {
        private const string db = "ht_localdb_30102019";

        //SQL query, not stored procedure
        public List<ClientModel> GetClientsAll()
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Client", connection))
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

        //TODO methods

    }
}
