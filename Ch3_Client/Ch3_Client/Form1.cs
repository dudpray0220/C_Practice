using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ch3_Client
{
    public partial class Form1 : Form
    {
        TcpClient tcpClient = null;
        NetworkStream ns;
        BinaryReader br;
        BinaryWriter bw;

        int intValue;
        float floatValue;
        string strValue;

        public Form1()
        {
            InitializeComponent();
        }

        // 접속 버튼 클릭
        private void BtnCon_Click(object sender, EventArgs e)
        {
            tcpClient = new TcpClient(textBoxServerIp.Text, 3000);
            if (tcpClient.Connected)
            {
                ns = tcpClient.GetStream();
                br = new BinaryReader(ns);
                bw = new BinaryWriter(ns);
                MessageBox.Show("서버 접속 성공!");
            }
            else
            {
                MessageBox.Show("서버 접속 실패 8ㅅ8");
            }
        }

        // 전송 및 수신 버튼 클릭
        private void BtnNetworking_Click(object sender, EventArgs e)
        {
            bw.Write(int.Parse(textBoxInt.Text));
            bw.Write(float.Parse(textBoxFloat.Text));
            bw.Write(textBoxString.Text);

            intValue = br.ReadInt32(); // -> 대기상태
            floatValue = br.ReadSingle();
            strValue = br.ReadString();

            string str = intValue + " / " + floatValue + " / " + strValue;
            MessageBox.Show(str);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bw.Write(-1);
            bw.Close();
            br.Close();
            ns.Close();
            tcpClient.Close();
        }
    }
}
