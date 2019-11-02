using HotelDB.Model;
using HotelDB.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelDB
{
    public partial class DashboardView : Form
    {                 
        public DashboardView()
        {
            InitializeComponent();
            HotelDB.GlobalConfig.InitializeConnection();
        }
        private void buttonClients_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GlobalConfig.Connection.GetClientsAll();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string clientSearch = textBoxClientName.Text.ToString();
            dataGridView1.DataSource = GlobalConfig.Connection.GetClientsAll(clientSearch);
        }

        //click and get edit form of what was selected
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int clientPosition = int.Parse(dataGridView1[0, e.RowIndex].Value.ToString());
            ClientModel selectedClient = GlobalConfig.Connection.GetClient(clientPosition);
            ClientView frm = new ClientView(selectedClient);
            frm.Show();
        }
    }
}
