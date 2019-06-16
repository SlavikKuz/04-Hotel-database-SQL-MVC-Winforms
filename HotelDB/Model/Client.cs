using System.Data;

namespace HotelDB.Model
{
    public class Client
    {
    public int id { get; private set; }
    public string client_full_name { get; private set; }
    public string email { get; private set; }
    public string tel { get; private set; }
    public string address { get; private set; }
    public string notes { get; private set; }

        private SQL sql;

        public Client(SQL sql)
        {
            id = 0;
            client_full_name = "";
            email = "";
            tel = "";
            address = "";
            notes = "";
            this.sql = sql;
        }
    
        public void SetClient (string client_name)
        {
            this.client_full_name = client_name;
        }

        public  void SetEmail(string email)
        {
            this.email = email;
        }

        public void SetTel(string tel)
        {
            this.tel = tel;
        }

        public void SetAddress(string address)
        {
            this.address = address;
        }

        public void SetNotes(string notes)
        {
            this.notes = notes;
        }

        public void InsertClient()
        // register a new client
        // injection protected
        {
            string query = "INSERT INTO Client (" +
                "client_full_name, " +
                "email, " +
                "tel, " +
                "address, " +
                "notes) " +
                    "VALUES('" + 
                    sql.AddSlash(client_full_name) +
                    "','" + sql.AddSlash(email) + 
                    "','" + sql.AddSlash(tel) + 
                    "','" + sql.AddSlash(address) +
                    "','" + sql.AddSlash(notes) + "');";

            do this.id = this.sql.Insert(query);
            while (this.sql.SqlError());
        }

        public DataTable SelectClients()
        // get a list of clients;
        {
            DataTable client;
            do client = sql.Select("SELECT * FROM Client");
            while (sql.SqlError());
            return client;
        }

        public DataTable SelectClients(string find)
        // get a list of clients (filter);
        {
            DataTable client;
            find = sql.AddSlash(find);

            do client = sql.Select("SELECT * FROM Client " +
                "WHERE client_full_name LIKE '%" + find + "%' " +
                "OR email LIKE '%" + find + "%' " +
                "OR tel LIKE '%" + find + "%' " +
                "OR address LIKE '%" + find + "%' " +
                "OR notes LIKE '%" + find + "%' " +
                "OR id = '" + find + "';");
            while (sql.SqlError());
            return client;
        }

        public bool SelectClient(int client_id)
        // get data for selected client;
        {
            DataTable client;
            do client = sql.Select(
                "SELECT id, client_full_name, email, tel, address, notes " +
                "FROM Client " +
                "WHERE id = '" + sql.AddSlash(client_id.ToString()) + "'");
            while (sql.SqlError());

            if (client.Rows.Count == 0)
                return false;

            this.id=int.Parse(client.Rows[0]["id"].ToString());
            this.client_full_name = client.Rows[0]["client_full_name"].ToString();
            this.email = client.Rows[0]["email"].ToString();
            this.tel = client.Rows[0]["tel"].ToString();
            this.address = client.Rows[0]["address"].ToString();
            this.notes = client.Rows[0]["notes"].ToString();
            return true;
        }


        public bool UpdateClient()
        // change client's data;
        {
            int result =0;
            do result = sql.Update(
                "UPDATE Client " +
                "SET client_full_name = '" + sql.AddSlash(this.client_full_name) + "'," +
                    "email = '" + sql.AddSlash(this.email) + "'," +
                    "tel = '" + sql.AddSlash(this.tel) + "'," +
                    "address = '" + sql.AddSlash(this.address) + "'," +
                    "notes = '" + sql.AddSlash(this.notes) + "' " +
                    "WHERE id = '" + sql.AddSlash(this.id.ToString()) + "'");
            while (sql.SqlError());

            if (result == 0)
                return false;
            return true;
        }
    }
}
