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
        //delegate T2 xuxdelegate2(T1,T2)(T1);

        string GetSumAdd1(int x,int y)
        {
            return (x + 1 + y + 1).ToString();
        }

        public delegateTest()
        {
            InitializeComponent();
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

        private void button2_Click(object sender, EventArgs e)
        {

            delegate T2 xuxdelegate2(T1, T2)(T1);
        }
    }
}
