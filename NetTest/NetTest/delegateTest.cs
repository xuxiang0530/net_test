using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetTest
{
    public partial class delegateTest : Form
    {
        delegate string xuxdelegate(int x, int y);
        //泛型委托,定义2个类型,T2类型即是返回值,也是运算值
        delegate T2 xuxdelegate2<T1, T2>(T1 obj1,T2 obj2);
        //delegate T2 xuxdelegate2(T1,T2)(T1);

        string GetSumAdd1(int x,int y)
        {
            return (x + 1 + y + 1).ToString();
        }

        

        public delegateTest()
        {
            InitializeComponent();

            GrammaticalSugar x = new GrammaticalSugar();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt16(textBox1.Text);
            int y1 = Convert.ToInt16(textBox2.Text);

            xuxdelegate _xuxdelegate1 = new xuxdelegate(GetSumAdd1);

            xuxdelegate _xuxdelegate2 = delegate (int x, int y)
            {
                return (x + 2 + y + 2).ToString();
            };

            xuxdelegate _xuxdelegate3 = (int x, int y) =>
            { return (x + 3 + y + 3).ToString(); };

            MessageBox.Show(string.Format("x + 1 + y + 1 = {0}",_xuxdelegate1(x1,y1) ));
            MessageBox.Show(string.Format("x + 2 + y + 2 = {0}",_xuxdelegate2(x1,y1)));
            MessageBox.Show(string.Format("x + 3 + y + 3 = {0}",_xuxdelegate3(x1,y1)));
        }

        private bool test1(int x, bool b)
        {
            return x % 2 == 0;
        }

        private bool test2(int x, bool b)
        {
            if (b)
                return x % 2 == 0;
            else
                return b;
        }

        private int test3(int x,int y)
        {
            return x + y;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int x1 = Convert.ToInt16(textBox1.Text);
            int y1 = Convert.ToInt16(textBox2.Text);
            xuxdelegate2<int, bool> x21 = test1;

            MessageBox.Show(string.Format("第一个数字是偶数么? 答案:{0}", x21(x1, true).ToString()));

            x21 = test2;

            MessageBox.Show(string.Format("第一个数字是偶数么? 假的答案:{0}", x21(x1, false).ToString()));
            MessageBox.Show(string.Format("第一个数字是偶数么? 真的答案:{0}", x21(x1, true).ToString()));

            xuxdelegate2<int, int> x22 = test3;
        }
    }
}
