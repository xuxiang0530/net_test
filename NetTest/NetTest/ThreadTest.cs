using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace NetTest
{
    class ThreadTest
    {
        static void Main(string[] args)
        {
            ThreadTest tt = new ThreadTest();
            Thread thred1 = new Thread(new ThreadStart(tt.Ttest1));
            Thread thred2 = new Thread(Ttest2);
            Thread thred3 = new Thread(() => { Console.WriteLine("this is lambda."); });
            Thread thred4 = new Thread(delegate () { Console.WriteLine("this is delegate"); });
            Thread thred5 = new Thread(new ParameterizedThreadStart(x => { Console.WriteLine(Convert.ToString(x)); }));
            thred5.Start("this is a parameterized fun");

            thred1.Start();
            thred2.Start();
            thred3.Start();
            thred4.Start();
            Console.ReadKey();   
        }

        private void Ttest1()
        {
            Console.WriteLine("this is a no arguments");
        }

        static void Ttest2()
        {
            Console.WriteLine("this is a ttest2");
        }
    }
}
