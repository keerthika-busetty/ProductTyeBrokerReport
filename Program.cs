using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradingReprot;
using TradingReprot.Interface;
using Unity;

namespace TradingReport
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //using Unity Application block for resolving IMessageBox for Unit Testing
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IReportView, ReportView>();
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<UserView>());
        }
    }
}
