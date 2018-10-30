using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace NetTest
{
    public partial class ThreadForm : Form
    {
        private delegate void DoSomeCallBack(int value,string str);

        DoSomeCallBack doSomeCallBack;

        public ThreadForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doSomeCallBack = new DoSomeCallBack(SetValue);
            string str = "this is test";

            Thread nT = new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    textBox1.Invoke(doSomeCallBack, i, str);
                    Thread.Sleep(1000);
                }
            });
            nT.IsBackground = true;
            nT.Start();
        }

        private void SetValue(int value, string str)
        {
            this.textBox1.Text = string.Format( "{0} and {1}",value.ToString(),str);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"****************btnSync_Click Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
            for(int i =0;i<5;i++)
            {
                string name = $"btnSync_Click_{i}";
                this.DoSomethingLong(name);
            }
        }
        
        //public delegate AsyncCallback(IAsyncResult ar);
        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"***************btnAsync_Click Start {Thread.CurrentThread.ManagedThreadId}");
            Action<string> action = this.DoSomethingLong;
            // 调用委托(同步调用)
            //action.Invoke("btnAsync_Click_1");
            // 异步调用委托
            IAsyncResult ia = null;
            AsyncCallback callBack = p =>
            {
                //Console.WriteLine(object.ReferenceEquals(p,ia));
                Console.WriteLine($"到这里计算已经完成了。{Thread.CurrentThread.ManagedThreadId.ToString("00")}。");
            };


            //ia = action.BeginInvoke("this is xux test", callBack, null);
            //for (int i = 0; i < 5; i++)
            //{
            //    string name = $"btnSync_Click_{i}";
            //    ia = action.BeginInvoke(name, callBack, null);
            //}
            Console.WriteLine($"***************btnAsync_Click End    {Thread.CurrentThread.ManagedThreadId}");
        }

        private void DoSomethingLong(string name)
        {
            Console.WriteLine($"***DoSomethingLong{name} Start {Thread.CurrentThread.ManagedThreadId.ToString("00")}{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}*********");

            long lr = 0;
            for(int i = 0;i < 1000000000;i++)
            {
                lr += i;
            }
            Console.WriteLine($"***DoSomethingLong{name} End {Thread.CurrentThread.ManagedThreadId.ToString("00")}{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}{lr}************&&");

        }


        private int xuxtest(string str)
        {
            return str.Length;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //string str = "aseds";
            Func<string,int> xuxFunc =  p => p.Length;

            IAsyncResult ias = xuxFunc.BeginInvoke("asas", p => Console.WriteLine(p.AsyncState), $"这是后面");

            Console.WriteLine($"func.EndInvoke(asyncResult)={xuxFunc.EndInvoke(ias)}");
        }
    }
}
