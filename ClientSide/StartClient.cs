using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Networking.Protocols;
using Services;

namespace ClientServer_TvDonationsProject
{
    static class StartClient
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IService service = new ServerProxy("127.0.0.1", 55555);
            MainController mainController = new MainController(service);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin(mainController));
        }
    }
}