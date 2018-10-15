using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetTest
{
    public partial class BackgroundWorker : Form
    {
        static string strSaveDir = @"D:\project\Net_test\temp";

        public BackgroundWorker()
        {
            InitializeComponent();
            this.bgWork.WorkerReportsProgress = true;
            this.bgWork.WorkerSupportsCancellation = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(strSaveDir) == false)
            {
                Directory.CreateDirectory(strSaveDir);
            }
            button1.Enabled = false;
            int count = Convert.ToInt32(this.textBox1.Text.ToString().Trim());
            //设置进度条
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = count;
            this.progressBar1.Value = this.progressBar1.Minimum;
            //开始执行异步线程，进行后台操作,给后台传递参数
            this.bgWork.RunWorkerAsync(count);
        }
        /// <summary>
        /// 后台操作要处理的任务代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWork_DoWork_1(object sender, DoWorkEventArgs e)
        {
            //获取从RunWorkerAsync（）方法里面传递的参数的值
            int fileCount = Convert.ToInt32(e.Argument);
            Random rand = new Random();
            byte[] buffer = new byte[2048];
            for (int i = 0; i < fileCount; i++)
            {
                try
                {
                    string strFileName = Path.Combine(strSaveDir, i.ToString() + ".tmp");
                    using (var stream = File.Create(strFileName))
                    {
                        int n = 0;
                        int maxByte = 8 * 1024 * 1024;
                        while (n < maxByte)
                        {
                            rand.NextBytes(buffer);
                            stream.Write(buffer, 0, buffer.Length);
                            n += buffer.Length;
                        }
                    }
                }
                catch (Exception ex)
                {
                    continue;
                }
                finally
                {
                    //报告进度
                    this.bgWork.ReportProgress(i + 1);
                    Thread.Sleep(100);
                }

                //判断是否取消了后台操作
                if (bgWork.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                //设置返回值
                e.Result = 22222;
            }
        }

        /// <summary>
        /// 更新前台界面进度条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //获取异步任务的进度百分百
            int val = e.ProgressPercentage;
            this.label2.Text = string.Format("已经生成{0}个文件", val);
            //进度条显示当前进度
            this.progressBar1.Value = val;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.bgWork.CancelAsync();
        }
        

        /// <summary>
        /// 后台操作完成，向前台反馈信息
        /// </summary>
        /// <param name="sender"></param>
        private void bgWork_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
            //用户取消操作(e.Cancelled==true,表示异步操作已被取消)
            if (e.Cancelled)
            {
                MessageBox.Show("用户取消后台操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("操作完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //接收返回值
                int result = (int)e.Result;

                MessageBox.Show("返回值:" + result);
            }
        }
    }
}
