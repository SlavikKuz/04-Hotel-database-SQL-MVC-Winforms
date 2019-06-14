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
    public partial class Form1 : Form
    {
        SQL sql;

        public Form1()
        {
            InitializeComponent();
            sql = new SQL();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DataTable client = sql.Select("SELECT * FROM client");
            //MessageBox.Show(client.Rows[0][1].ToString());
            //MessageBox.Show(sql.Scalar("SELECT COUNT(*) FROM Client"));
            MessageBox.Show(sql.Scalar("SELECT max(id) FROM Client"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            do
                sql.Insert("INSERT INTO Client " +
                    "VALUES(07," +
                    "'5Slavik Kuz'," +
                    "'5mymail@email.com'," +
                    "'123445678'," +
                    "'Follumsvei 11B, Nordfjord, 9611'," +
                    "'loyal client, traveling with a bike');");
            while (sql.SqlError());
        }
    }
}
