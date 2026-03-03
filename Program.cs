using System;
using System.Windows.Forms;
using BarrioTecApp.Forms;

namespace BarrioTecApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmVentas());
        }
    }
}
