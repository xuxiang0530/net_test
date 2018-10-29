using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace NetTest
{
    class ThreadTest
    {
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();
        //[STAThread]
        static void Main(string[] args)
        {
            AllocConsole();
             ThreadTest tt = new ThreadTest();
            //实例化线程
            Thread thred1 = new Thread(new ThreadStart(tt.Ttest1));
            //持久方法可以在static中直接调用
            Thread thred2 = new Thread(Ttest2);
            //lambda表达式的线程
            Thread thred3 = new Thread(() => { Console.WriteLine("lambda表达式的线程"); });
            //匿名委托的线程
            Thread thred4 = new Thread(delegate () { Console.WriteLine("匿名委托的线程"); });
            //带参数的线程,参数一定要是object
            Thread thred5 = new Thread(new ParameterizedThreadStart(x => { Console.WriteLine(Convert.ToString(x)); }));
            //thred5.Start("带参数的线程,参数一定要是object");

            //thred1.Start();
            //thred2.Start();
            //thred3.Start();
            //thred4.Start();

            BackGroupTest fbt = new BackGroupTest(10);
            //Thread ft = new Thread(new ParameterizedThreadStart(x => fbt.RunLoop(x)));
            //ft.Name = "前台进程";
            //ft.Start(10);
            Thread ft = new Thread(new ThreadStart(fbt.RunLoop));
            ft.Name = "前台进程";
            BackGroupTest bbt = new BackGroupTest(20);
            //Thread bt = new Thread(new ParameterizedThreadStart(x => bbt.RunLoop(x)));
            //bt.Name = "后台进程";
            //bt.Start(20);
            Thread bt = new Thread(new ThreadStart(bbt.RunLoop));
            bt.Name = "后台进程";
            bt.IsBackground = true;


            //ft.Start();
            //bt.Start();
            BackGroupTest test6 = new BackGroupTest(1);

            Thread t6 = new Thread(test6.Sale);
            Thread t7 = new Thread(test6.Sale);


            t6.Start();
            t7.Start();

            Console.ReadKey();

            FreeConsole();
        }

        class BackGroupTest
        {
            //private int c;
            public int c { get; set; }
            public  BackGroupTest(int number)
            {
                c = number;
            }

            public void RunLoop()
            {
                string threadName = Thread.CurrentThread.ManagedThreadId + Thread.CurrentThread.Name + Thread.CurrentThread.ThreadState;

                for (int i = 0; i < c; i++)
                {
                    Console.WriteLine(threadName + i.ToString());
                    Thread.Sleep(1000);
                }
                Console.WriteLine("{0}全部完成了", threadName);
            }

            public void Sale()
            {
                lock(this)
                {
                    int tmp = c;

                    if (tmp > 0)
                    {
                        Thread.Sleep(1000);
                        c -= 1;
                        Console.WriteLine("现在数字是{0}", c);

                    }
                    else
                    {
                        Console.WriteLine("0就不减了");
                    }
                }
            }

            public void RunLoop(object ob)
            {
                string threadName = Thread.CurrentThread.ManagedThreadId + Thread.CurrentThread.Name + Thread.CurrentThread.ThreadState;

                for (int i = 0; i < (int)ob; i++)
                {
                    Console.WriteLine(threadName + i.ToString());
                    Thread.Sleep(1000);
                }
                Console.WriteLine("{0}全部完成了", threadName);
            }
        }

        private void Ttest1()
        {
            Console.WriteLine("实例化线程");
        }

        static void Ttest2()
        {
            Console.WriteLine("持久方法可以在static中直接调用");
        }
    }
}
