using HotelDB.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelDB.View;
using HotelDB.Controller;
using HotelDB.Model;
using System.Data;

namespace HotelDB
{
    static class StartUp
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ClientView view = new ClientView();

            SQL sql = new SQL();
            ClientModel mClient = new ClientModel(sql);

            //DataTable clientData;
            //clientData = mClient.SelectClients();

            //ClientController controller = 
            //    new ClientController(view, sql, mClient, clientData);

            Application.Run(new DashboardView());

        }
    }
}
