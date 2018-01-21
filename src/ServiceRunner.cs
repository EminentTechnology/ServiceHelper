using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using log4net.Appender;
using log4net.Core;

namespace ServiceHelper
{
    public partial class ServiceRunner : Form, IAppender
    {
        private readonly IDebuggableService service;

        public ServiceRunner(IDebuggableService service)
        {
            InitializeComponent();
            this.service = service;
            ServiceBase winService = this.service as ServiceBase;
            if (winService != null) Text = winService.ServiceName + " Runner";
            Show();

            ((log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetRepository())?.Root?.AddAppender(this);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            service.Start(new string[] { });
            toolStripStatusLabel1.Text = "Started";
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            service.Pause();
            toolStripStatusLabel1.Text = "Paused";
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            service.Continue();
            toolStripStatusLabel1.Text = "Started";
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            service.StopService();
            toolStripStatusLabel1.Text = "Stopped";
        }

        

        public void DoAppend(LoggingEvent loggingEvent)
        {
            this.ReportProgress(string.Format("{0} - {1}: {2}", loggingEvent.TimeStamp, loggingEvent.Level.Name, loggingEvent.MessageObject.ToString()));
        }

        private void ReportProgress(string message)
        {
            

            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(ReportProgress), new object[] { message });
                return;
            }

            this.LogTextBox.AppendText(string.Concat(message, "\r\n\r\n"));
            
        }
    }
}
