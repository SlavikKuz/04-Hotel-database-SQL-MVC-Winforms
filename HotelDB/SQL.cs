using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace HotelDB
{
    class SQL
    {
        SqlConnection myConnection;
        SqlCommand cmd;
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
                cmd = new SqlCommand(query, myConnection);
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

        public DataTable Select(string query)
        {
            DataTable table = null;
            this.query = query;
            if (!Open()) return table;

            try
            {
                cmd = new SqlCommand(query, myConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                table = new DataTable("table");
                table.Load(reader);
            }
            catch(Exception ex)
            {
                error = ex.Message;
                return null;
            }
            Close();
            return table;
        }

        public int Insert(string query) //return last inserted id
        {
            int rows = Update(query);
            if (rows > 0)
            {
                cmd = new SqlCommand("SELECT max(id) FROM Client", myConnection);
                int a=(Int32)cmd.ExecuteScalar();
                return a;
            }
            return 0;
        }

        public int Update(string query) //update | delete, return count of rows
        {
            int rows = 0;
            this.query = query;
            if (!Open()) return 0;
            try
            {
                cmd = new SqlCommand(query, myConnection);
                rows = cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                error = ex.Message;
                return -1;
            }
            return rows;
            
        }

        public string AddSlash(string text)
        {
            return text.Replace("'","\\'");
        }
    }
}
