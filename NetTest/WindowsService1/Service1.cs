using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
//using XuxWcfServiceTest;
using System.ServiceModel;
//using WcfServiceLibrary1;
namespace WindowsService1
{
    public partial class xuxTest : ServiceBase
    {
        public xuxTest()
        {
            InitializeComponent();
        }

        private System.ServiceModel.ServiceHost serviceHost = null; //

        protected override void OnStart(string[] args)
        {
            //using ()
            try
            {
                serviceHost = new ServiceHost(typeof(XuxTestWcfService.XuxTest));

                if (serviceHost.State != System.ServiceModel.CommunicationState.Opened)
                {
                    serviceHost.Open();
                }
            }
            catch(Exception )
            {

            }
        }

        protected override void OnStop()
        {
            if(serviceHost != null)
            {
                serviceHost.Close();
            }
        }
    }
}
