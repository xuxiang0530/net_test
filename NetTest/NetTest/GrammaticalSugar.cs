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
            var vTest = new XuxTest2("33");

            vTest.test();            
        }

        private class User
        {
            public string Name { get; set; }
            public string Password { get; set; }
            public int Age { get; set; }
            public string DeptId { get; set; }
        }

        private class Dept
        {
            public string DeptName { get; set; }

            public int PepNum { get; set; }
            public string DeptId { get; set; }
        }

        public void TestFunc()
        {
            List<User> listUser = new List<User>()
            {
                new User() { Name = "张三", Password = "1234", Age = 12, DeptId = "0001" },
                new User() { Name = "张四", Password = "1234", Age = 16, DeptId = "0002" },
                new User() { Name = "张五", Password = "1234", Age = 29, DeptId = "0003" },
                new User() { Name = "张六", Password = "1234", Age = 18, DeptId = "0001" },
                new User() { Name = "张七", Password = "1234", Age = 12, DeptId = "0001" }
            };
            
            List<Dept> listDept = new List<Dept>()
            {
                new Dept() { DeptId = "0001", DeptName = "人事部", PepNum = 10 },
                new Dept() { DeptId = "0002", DeptName = "财务部", PepNum = 7 },
                new Dept() { DeptId = "0003", DeptName = "行政部", PepNum = 15 }
            };

            listDept.Select(x => { var y = new { x.DeptId, x.DeptName }; return y; });
            listDept.Where(x => x.PepNum > 10).Select(x => x.DeptId);
            //IE
        }

    }
}
