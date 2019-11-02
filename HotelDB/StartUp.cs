using System;
using System.Windows.Forms;

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
