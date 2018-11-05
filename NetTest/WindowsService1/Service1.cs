using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
//using WcfServiceLibrary1;
namespace WindowsService1
{
    public partial class xuxTest : ServiceBase
    {
        public xuxTest()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //using ()
        }

        protected override void OnStop()
        {
        }
    }
}
