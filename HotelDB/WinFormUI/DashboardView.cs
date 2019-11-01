using HotelDB.Model;
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
        SQL sql;
        Model.ClientModel mClient;

        public DashboardView() 
        {
            InitializeComponent(); //+
            HotelDB.GlobalConfig.InitializeConnection(); //+
            List<ClientModel> clients = GlobalConfig.Connection.GetClientsAll(); //+

            //sql = new SQL();//-
            //mClient = new Model.ClientModel(sql);//-
            //DataTable client = mClient.SelectClients(); //-

            dataGridView1.DataSource = clients;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable client = mClient.SelectClients();
            dataGridView1.DataSource = client;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable calendar;
            do calendar = sql.Select("SELECT * FROM Calendar");
            while (sql.SqlError());

            dataGridView1.DataSource = calendar;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
            //bad practice. opens database at every letter pressed
        {
            dataGridView1.DataSource = mClient.SelectClients(textBox1.Text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dataGridView1[0, e.RowIndex].Value.ToString());
            mClient.SelectClient(id);
            
            Random rand = new Random();
            mClient.SetTel(rand.Next(1000000, 9999999).ToString());

            mClient.UpdateClient();
        }
    }
}
