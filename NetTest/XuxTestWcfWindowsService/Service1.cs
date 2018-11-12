using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;


namespace XuxTestWcfWindowsService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        private System.ServiceModel.ServiceHost serviceHost = null;

        protected override void OnStart(string[] args)
        {
            try
            {
                writeLog("Start");
                serviceHost = new System.ServiceModel.ServiceHost(typeof(XuxTestWcfService.XuxTest));
                if(serviceHost.State != System.ServiceModel.CommunicationState.Opened)
                {

                    writeLog("serviceHost.Open");
                    serviceHost.Open();
                }
            }
            catch(Exception ex)
            {

                writeLog(string.Format("Error:{0}",ex.Message));
            }
        }

        protected override void OnStop()
        {
            serviceHost.Close();
            writeLog("Close");
        }

        private void writeLog(string log)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(@"D:\LOG\LOG.txt", true, System.Text.Encoding.Default);
            sw.WriteLine(DateTime.Now.ToString() + "  " + log);
            sw.Close();
        }
    }
}
