using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTest
{
    class GrammaticalSugar
    {
        //自动属性prop+tab
        public string xuxStr { get;  }


        //自动属性prop+tab
        public int MyProperty { get; set; }

        //测试匿名类型
        private class XuxTest1
        {
            public int intTest { get; set; }
            public string strTest { get; set; }
            public string testOut { get; set; }

            public XuxTest1()
            {

            }

            public XuxTest1(int x,string y)
            {
                intTest = x;
                strTest = y;

            }

            public string test()
            {
                return intTest.ToString() + "  @ " + strTest; 
            }
        }

        private class XuxTest2 : XuxTest1
        {
            public double age { get; set; }
            public XuxTest2(string x, int y = 55)
            {
                strTest = x;
                intTest = y;
            }

            //public XuxTest1 getTest1()
            //{
            //    testOut = "Test2Out";
            //    return base.
            //}
        }

        public GrammaticalSugar()
        {
            xuxStr = "10";
            double xd;
            if (double.TryParse(xuxStr, out xd))
            {
                
            }

            //测试匿名类型,隐式类型
            var vTest = new XuxTest1(22, "33");

            vTest.test();


            
        }
    }
}
