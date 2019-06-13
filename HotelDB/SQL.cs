using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HotelDB
{
    class SQL
    {
        string host;
        string user;
        string pass;
        string dbase;
        SqlConnection myConnection;
        string error;
        string query;

        const string connectionString = "Data Source=LAPTOP-UG5GI195;Initial Catalog=HotelDB;Integrated Security=True";

        protected bool Open()
        {
            try
            {
                myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                return true;
            }

            catch(Exception ex)
            {
                error = ex.Message;
                query = "CONNECTION to SQL " + user + "@" + host;
                return false;
            }

        }

        protected bool Close()
        {
            try
            {
                myConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                query = "DISCONNECTION to SQL " + user + "@" + host;
                return false;
            }
        }

        public string Scalar(string query)
        {
            this.query = query;
            string result = "";

            if (!Open())
                return null;

            try
            {
                SqlCommand cmd = new SqlCommand(query, myConnection);
                result = cmd.ExecuteScalar().ToString();
            }
            catch(Exception ex)
            {
                error = ex.Message;
                return null;
            }

            Close();
            return result;
        }

    }
}
