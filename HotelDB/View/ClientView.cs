using System;
using System.Data;
using System.Windows.Forms;

using HotelDB.Controller;
using HotelDB.Model;

namespace HotelDB.View
{
    public partial class ClientView : Form, IClient
    {

        public ClientView()
        {
            InitializeComponent();
        }

        ClientController _controller;

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource =
               this._controller.SelectClients(textBox1.Text);
        }
        
        //interface implementation

        public void SetController(ClientController controller)
        {
            _controller=controller;
        }

        public void InsertClient()
        {
            throw new NotImplementedException();
        }

        public DataTable SelectClients()
        {
            throw new NotImplementedException();
        }

        public void SelectClients(string find)
        {
            MessageBox.Show("done");
        }

        public bool SelectClient(int client_id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateClient()
        {
            throw new NotImplementedException();
        }

        public void SetClient(string client_name)
        {
            throw new NotImplementedException();
        }

        public void SetEmail(string email)
        {
            throw new NotImplementedException();
        }

        public void SetTel(string tel)
        {
            throw new NotImplementedException();
        }

        public void SetAddress(string address)
        {
            throw new NotImplementedException();
        }

        public void SetNotes(string notes)
        {
            throw new NotImplementedException();
        }
    }
}
