using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTest
{
    //public static class ConvertExtension
    //{
    //    public static int ConvertToInt(this Convert convert, string s)
    //    {
    //        int i;
    //        if (int.TryParse(s, out i))
    //        {
    //            return i;
    //        }
    //        else
    //        {
    //            return 0;
    //        }
    //    }
    //}

    class GrammaticalSugar
    {
        //一、自动属性
        //自动属性prop+tab
        public string xuxStr { get;  }

        delegate void Tempdg(string name);

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

            //二、隐式类型（var）
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

            public User()
            {

            }

            public User(string name, string deptid, string password = "1234",int age = 22)
            {
                Name = name;
                Password = password;
                Age = age;
                DeptId = deptid;
            }
        }

        private class Dept
        {
            public string DeptName { get; set; }

            public int PepNum { get; set; }
            public string DeptId { get; set; }
        }

        public void TestFunc()
        {
            //参数默认值和命名参数
            User userNew = new User("徐大大", deptid: "0003");
            List<User> listUser2 = new List<User>() { new User() { Name = "徐22", Password = "1234", Age = 55, DeptId = "0002" } };

            List<User> listUser = new List<User>()
            {
                //listUser2 错误,必须是个体
                listUser2[0],
                userNew,
                new User() { Name = "张三", Password = "1234", Age = 12, DeptId = "0001" },
                new User() { Name = "张四", Password = "1234", Age = 16, DeptId = "0002" },
                new User() { Name = "张五", Password = "1234", Age = 29, DeptId = "0003" },
                new User() { Name = "张六", Password = "1234", Age = 18, DeptId = "0001" },
                new User() { Name = "张七", Password = "1234", Age = 12, DeptId = "0001" }
            };


            //listUser.Add(userNew);
            
            List<Dept> listDept = new List<Dept>()
            {
                new Dept() { DeptId = "0001", DeptName = "人事部", PepNum = 10 },
                new Dept() { DeptId = "0002", DeptName = "财务部", PepNum = 7 },
                new Dept() { DeptId = "0003", DeptName = "行政部", PepNum = 15 }
            };

            //Lambda表达式
            listDept.Select(x => { var y = new { x.DeptId, x.DeptName }; return y; });
            listDept.Where(x => x.PepNum > 10).Select(x => x.DeptId);

            //五、匿名类和匿名方法


            var xux1 = new
            {
                TName = "死神",
                Tage = 9999,
                //嵌套匿名类
                xux2 = new { Tname = "死神儿子", Tage = 9998 }
            };
            //
            //匿名方法必须结合委托使用,可以是不需要复用的方法
            Tempdg t = delegate (string s) { Console.WriteLine(s + "temp"); };
            t("12358");


            //匿名方法可以省略参数，编译的时候会自动为这个方法按照委托签名的参数添加参数

            //内置泛型委托
            Action actionx = delegate
            {
                Console.WriteLine("没有参数的匿名方法");
            };
            Action<string> actionx2 = delegate(string s)
            {
                Console.WriteLine(s + "action");
            };

            Func<int, string> funcx = delegate (int x)
             {
                 return x.ToString();
             };

            string strFunc = funcx(11);

            Predicate<int> predicatex = delegate (int x)
            {
                return x > 22;
            };

            List<int> listint = new List<int>() { 22, 33, 55, 66, 77, 32, 56, 77, 11, 1, 1,9, 2, 3, 4, 6 };

            listint.FindAll(predicatex);

            Console.WriteLine(xux1.xux2.Tname);
        }
        
        private bool returnbool(int x)
        {
            return x > 33;
        }
        
    }

}
