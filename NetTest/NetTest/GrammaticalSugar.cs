using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTest
{
    class GrammaticalSugar
    {
        public string xuxStr { get;  }

        public int MyProperty { get; set; }


        public GrammaticalSugar()
        {
            xuxStr = "10";
            double xd;
            if (double.TryParse(xuxStr, out xd))
            {

            }
        }
    }
}
