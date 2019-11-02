using HotelDB.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelDB.View;
using HotelDB.Model;
using System.Data;

namespace HotelDB
{
    static class StartUp
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new DashboardView());
        }
    }
}
