using System.Data;

namespace HotelDB.Model
{
    public class ClientModel
    {
    public int Id { get; set; }
    public string Client_full_name { get; set; }
    public string Email { get; set; }
    public string Tel { get; set; }
    public string Address { get; set; }
    public string Notes { get; set; }

        private SQL sql;

        public ClientModel(SQL sql)
        {
            Id = 0;
            Client_full_name = "";
            Email = "";
            Tel = "";
            Address = "";
            Notes = "";
            this.sql = sql;
        }

        public ClientModel()
        {
        }

        public void SetClient (string client_name)
        {
            this.Client_full_name = client_name;
        }

        public  void SetEmail(string email)
        {
            this.Email = email;
        }

        public void SetTel(string tel)
        {
            this.Tel = tel;
        }

        public void SetAddress(string address)
        {
            this.Address = address;
        }

        public void SetNotes(string notes)
        {
            this.Notes = notes;
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
                    sql.AddSlash(Client_full_name) +
                    "','" + sql.AddSlash(Email) + 
                    "','" + sql.AddSlash(Tel) + 
                    "','" + sql.AddSlash(Address) +
                    "','" + sql.AddSlash(Notes) + "');";

            do this.Id = this.sql.Insert(query);
            while (this.sql.SqlError());
        }

        //kill
        public DataTable SelectClients()
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

            this.Id=int.Parse(client.Rows[0]["id"].ToString());
            this.Client_full_name = client.Rows[0]["client_full_name"].ToString();
            this.Email = client.Rows[0]["email"].ToString();
            this.Tel = client.Rows[0]["tel"].ToString();
            this.Address = client.Rows[0]["address"].ToString();
            this.Notes = client.Rows[0]["notes"].ToString();
            return true;
        }


        public bool UpdateClient()
        // change client's data;
        {
            int result =0;
            do result = sql.Update(
                "UPDATE Client " +
                "SET client_full_name = '" + sql.AddSlash(this.Client_full_name) + "'," +
                    "email = '" + sql.AddSlash(this.Email) + "'," +
                    "tel = '" + sql.AddSlash(this.Tel) + "'," +
                    "address = '" + sql.AddSlash(this.Address) + "'," +
                    "notes = '" + sql.AddSlash(this.Notes) + "' " +
                    "WHERE id = '" + sql.AddSlash(this.Id.ToString()) + "'");
            while (sql.SqlError());

            if (result == 0)
                return false;
            return true;
        }
    }
}
