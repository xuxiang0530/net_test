﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            delegateTest dt = new delegateTest();
            dt.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ThreadForm tf = new ThreadForm();
            tf.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmMain fm = new FrmMain();
            fm.ShowDialog();
        }

        ServiceReference1.XuxTestClient client = new ServiceReference1.XuxTestClient();
        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Text = client.Add(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text)).ToString();
        }
    }
}
