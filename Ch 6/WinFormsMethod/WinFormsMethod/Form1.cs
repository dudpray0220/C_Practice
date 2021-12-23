using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.Click += Button1_Click;
            FormClosed += Form1_FormClosed1;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Button self = (Button)sender;
            self.Text = "Why me click?";
            timer1.Enabled = true; // 클릭시 타이머작동
        }

        private void Form1_FormClosed1(object sender, FormClosedEventArgs e)
        {
        }

        private int elapsedTime = 0; // 변수선언
        private void timer1_Tick(object sender, EventArgs e)
        {
            elapsedTime++;
            textBox1.Text = elapsedTime + "초 경과";
            label1.Text = elapsedTime + "초 경과";
        }
    }
}
