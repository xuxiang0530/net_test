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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.ActiveControl = this.txt_Input;
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private delegate void WriteToTextBox(string strTxt);

        private WriteToTextBox writeToTextBox;  

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if(chbOne.Checked)
            {
                grbText1.Text = "运行中.....";
                grbText1.Refresh();

                writeToTextBox = new WriteToTextBox(WriteText1);
                WriteText(writeToTextBox);
                grbText1.Text = "完成";
            }

            if(chbTwo.Checked)
            {
                grbText2.Text = "运行中.....";
                grbText2.Refresh();

                writeToTextBox = new WriteToTextBox(WriteText2);
                WriteText(writeToTextBox);
                grbText2.Text = "完成";

            }
        }

        private void WriteText(WriteToTextBox wttb)
        {
            string textInput = this.txt_Input.Text;
            wttb(textInput);
        }

        private void WriteText1(string strTxt)
        {            
            this.textJobOne.Text = strTxt;
        }

        private void WriteText2(string strTxt)
        {
            this.textJobTwo.Text = strTxt;
        }
    }
}
