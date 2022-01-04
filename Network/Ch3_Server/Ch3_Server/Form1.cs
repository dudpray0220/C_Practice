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

namespace Ch3_Server
{
    public partial class Form1 : Form
    {
        private TcpListener tcpListener = null;
        private TcpClient tcpClient = null;
        private BinaryWriter bw = null;
        private BinaryReader br = null;
        private NetworkStream ns;

        int intValue;
        float floatValue;
        string strValue;

        // AllClose 메서드 (완벽한 객체 해제!)
        private void AllClose()
        {
            if (bw != null)
            { bw.Close(); bw = null; } 
            if (br != null)
            { br.Close(); br = null; }
            if (ns != null)
            { ns.Close(); ns = null; }
            if (tcpClient != null)
            { tcpClient.Close(); tcpClient = null; }
        }

        // DataReceive 메서드
        private int DataReceive()
        {
            intValue = br.ReadInt32(); // 양의 정수만 받는다 가정
            if (intValue < 0)
            {
                return -1;
            }
            floatValue = br.ReadSingle();
            strValue = br.ReadString();
            string str = intValue + "/" + floatValue + "/" + strValue;
            MessageBox.Show(str);
            return 0;
        }

        // DataSend 메서드
        private void DataSend()
        {
            bw.Write(intValue);
            bw.Write(floatValue);
            bw.Write(strValue);

            MessageBox.Show("보냈습니다~");
        }

        public Form1()
        {
            InitializeComponent();
        }

        // Form 로드 시
        private void Form1_Load(object sender, EventArgs e)
        {
            tcpListener = new TcpListener(3000);
            tcpListener.Start();

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            for (int i = 0; i < host.AddressList.Length; i++)
            {
                if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    textBoxServer.Text = host.AddressList[i].ToString();
                    textBoxServer.ReadOnly = true;
                    break;
                }
            }
        }

        // 접속 시작 버튼 클릭
        private void startConBtn_Click(object sender, EventArgs e)
        {
            //tcpClient = new TcpClient("172.16.5.218", 3000);
            tcpClient = tcpListener.AcceptTcpClient();
            if (tcpClient.Connected)
            {
                textBoxClient.Text = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString(); // 클라이언트 IP 가져오기 (고정적인 코드!)
            }
            ns = tcpClient.GetStream();
            bw = new BinaryWriter(ns);
            br = new BinaryReader(ns);
        }

        // 송수신 시작 버튼 클릭
        private void startNetworkBtn_Click(object sender, EventArgs e)
        {
            while (true)
            {
                if (tcpClient.Connected)
                {
                    if (DataReceive() == -1) { break; }
                    DataSend();
                }
                else
                {
                    AllClose();
                    break;
                }
            }
            AllClose();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            AllClose();
            tcpListener.Stop();
        }
    }
}
