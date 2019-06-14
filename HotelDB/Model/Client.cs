using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDB.Model
{
    class Client
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

        //        ModelClient.SelectClients()
        //// get a list of clients;
        //        SELECT* FROM Client;


        //ModelClient.SelectClient(string fing)
        //// get a list of clients (filter);
        //        SELECT* FROM Client
        //   WHERE client_full_name LIKE '%k%'

        //        OR email   LIKE '%k%'
        //		OR tel     LIKE '%k%'
        //		OR address LIKE '%k%'
        //		OR notes   LIKE '%k%'
        //		OR id = 'g';


        //        ModelClient.SelectClient(int client_id)
        //            // get data for selected client;
        //            SELECT client_full_name, email, tel, address, notes
        //            FROM Client
        //            WHERE id = '5';


        //ModelClient.UpdateClient(int client_id)
        //    // change client's data;
        //    UPDATE Client
        //    SET client_full_name = 'John Doe', 
        //		email = 'newmail@smthmail.com',
        //		tel = '987654321',
        //		address = 'Trænevegen 32, Sørfjord, 3215',
        //		notes = 'test'
        //	WHERE id = 1

        //    LIMIT 1; //control safety
    }
}
