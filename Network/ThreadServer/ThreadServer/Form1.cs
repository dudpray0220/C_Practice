using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;

namespace ThreadServer
{
    public partial class Form1 : Form
    {
        class EchoServer
        {
            TcpClient RefClient;
            private BinaryReader br = null;
            private BinaryWriter bw = null;
            int intValue;
            float floatValue;
            string strValue;

            public EchoServer(TcpClient Client) // 생성자
            {
                RefClient = Client;
            }

            public void Process()
            {
                NetworkStream ns = RefClient.GetStream();
                try
                { // 데이터 주고받는 모듈생성
                    br = new BinaryReader(ns);
                    bw = new BinaryWriter(ns);

                    while (true)
                    {
                        intValue = br.ReadInt32();
                        floatValue = br.ReadSingle();
                        strValue = br.ReadString();

                        bw.Write(intValue);
                        bw.Write(floatValue);
                        bw.Write(strValue);
                    }
                }
                catch (SocketException se) // 소켓 오류시 예외
                {
                    br.Close();
                    bw.Close();
                    ns.Close();
                    ns = null;
                    RefClient.Close();
                    MessageBox.Show(se.Message);
                    Thread.CurrentThread.Interrupt();
                }
                catch (IOException ex)  // 연결이 끊어져서 읽을 수가 없을 떄 처리
                {
                    br.Close();
                    bw.Close();
                    ns.Close();
                    ns = null;
                    RefClient.Close();
                    Thread.CurrentThread.Interrupt();
                }
            }
        };

        private TcpListener tcpListener = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void AcceptClient()
        {
            while (true) // 무한 반복문
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();

                if (tcpClient.Connected)
                {
                    string str = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
                    listBox1.Items.Add(str);
                }
                EchoServer echoServer = new EchoServer(tcpClient);
                Thread th = new Thread(new ThreadStart(echoServer.Process));
                th.IsBackground = true;
                th.Start();
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(AcceptClient));
            th.IsBackground = true;
            th.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tcpListener = new TcpListener(3000);
            tcpListener.Start();
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            for (int i = 0; i < host.AddressList.Length; i++)
            {
                if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    textBox1.Text = host.AddressList[i].ToString();
                    textBox1.ReadOnly = true;
                    break;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tcpListener != null)
            {
                tcpListener.Stop();
                tcpListener = null;
            }
        }
    }
}
