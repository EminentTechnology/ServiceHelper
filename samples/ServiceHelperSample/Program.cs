using log4net;
using ServiceHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceHelperSample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //configure logging - ServiceHelper currently only supports log4net
            log4net.Config.XmlConfigurator.Configure();

            try
            {

                //create instance of your windows service
                var service = new SampleService();

                //if we pass commandline parameter /debug
                if (args.Length > 0 && args[0].ToLower().Equals("/debug"))
                {
                    //then launch the service runner form - very helpful for debugging
                    //recommend going to Project Properties -> Debug -> Commandline arguments and entering /debug there
                    //this way pressing F5 or Start Debugging will launch in this mode

                    Application.Run(new ServiceRunner(service));
                }
                else
                {
                    //otherwise run like a regular service - this is what happens when windows service is installed on machine

                    ServiceBase[] ServicesToRun;
                    ServicesToRun = new ServiceBase[]
                    {
                    service
                    };
                    ServiceBase.Run(ServicesToRun);
                }

            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                log.Error(ex);
            }
        }
    }
}
