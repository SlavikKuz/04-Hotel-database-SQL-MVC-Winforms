using System;
using System.Data;
using System.Windows.Forms;
using HotelDB.Model;

namespace HotelDB.View
{
    public partial class ClientView : Form
    {

        public ClientView(ClientModel selectedClient)
        {
            InitializeComponent();

            FillClientToForm(selectedClient);
            
            //list of bookings of the client
            //dataGridViewClient.DataSource;
        }

        private void FillClientToForm(ClientModel selectedClient)
        {
            textBoxFullName.Text = selectedClient.ClientFullName.ToString();
            textBoxEmail.Text = selectedClient.Email.ToString();
            textBoxAddress.Text = selectedClient.Address.ToString();
            textBoxNotes.Text = selectedClient.Notes.ToString();
            textBoxTel.Text = selectedClient.Tel.ToString();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ClientModel client = new ClientModel();
            client.ClientFullName = textBoxFullName.Text;
            client.Email = textBoxEmail.Text;
            client.Address = textBoxAddress.Text;
            client.Tel = textBoxTel.Text;
            client.Notes = textBoxNotes.Text;

            GlobalConfig.Connection.CreateClient(client);

            //update model with new Id on screen?
        }
    }
}
