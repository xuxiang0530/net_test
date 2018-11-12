using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WcfServiceLibrary1
{
    partial class WCFService : ServiceBase
    {
        public WCFService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            using (ServiceHost host = new ServiceHost(typeof(CalculateService), new Uri("http://127.0.0.1:9099/CalculateWcfService"))) 
            {
                BasicHttpBinding bind = new BasicHttpBinding
                {
                    Name = "basichttpbinding"
                };

                host.AddServiceEndpoint(typeof(ICalculateService), bind, "CalculateWcfService");
                if(host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                {
                    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior()
                    {
                        HttpGetEnabled = true
                    };
                }

                host.AddServiceEndpoint(typeof(IMetadataExchange), bind, "mex");
                if(host.State != CommunicationState.Opened)
                {
                    host.Open();
                }
            }
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
