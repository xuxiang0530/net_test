using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetTest
{
    //扩展方法
    static class ConvertExtension
    {
        public static int ConvertToInt(this TextBox c, string s)
        {
            int i;
            if (int.TryParse(s, out i))
            {
                return i;
            }
            else
            {
                return 0;
            }
        }
    }
    
}
