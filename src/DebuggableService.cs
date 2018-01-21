using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;

namespace ServiceHelper
{
    public class DebuggableService: ServiceBase, IDebuggableService
    {


        public void Start(string[] args)
        {
            OnStart(args);
        }

        public void StopService()
        {
            OnStop();
        }

        public void Pause()
        {
            OnPause();
        }

        public void Continue()
        {
            OnContinue();
        }


    }
}
