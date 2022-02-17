using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SendProcess;

namespace M_AppTest
{
    public partial class Form3 : Form
    {
        SendData sendData = new SendData();

        public Form3()
        {
            InitializeComponent();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            sendData.Start();
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            sendData.Stop();
        }
    }
}
