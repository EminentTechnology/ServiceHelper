using ServiceHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace ServiceHelperSample
{
    partial class SampleService : DebuggableService
    {
        private readonly Timer timer = new Timer();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public SampleService()
        {
            InitializeComponent();

            timer.Interval = 1000; //every second
            timer.Enabled = false;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            log.Debug("OnStart");

            timer.Start();
        }

        protected override void OnContinue()
        {
            log.Debug("OnContinue");

            timer.Start();

        }

        protected override void OnPause()
        {
            log.Debug("OnPause");

            timer.Stop();


        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
            log.Debug("OnStop");

            timer.Stop();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            log.Debug("timer_Elapsed");
        }


    }
}
