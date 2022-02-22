using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTP_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_FileSearch_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName.Length > 0)
            {
                textFileName.Text = openFileDialog1.FileName;
                //foreach (string file in openFileDialog1.FileNames)
                //{
                //    listboxFileNames.Items.Add(file);
                //}
            }
        }

        private async void btn_FileSend_Click(object sender, EventArgs e)
        {
            string tempPath = @"ftp://172.16.10.109/temp/";
            // WebRequest.Create로 Http,Ftp,File Request 객체를 모두 생성할 수 있다.
            FtpWebRequest req = (FtpWebRequest)WebRequest.Create(tempPath + openFileDialog1.SafeFileName);
            // FTP 업로드한다는 것을 표시
            req.Method = WebRequestMethods.Ftp.UploadFile;
            // 쓰기 권한이 있는 FTP 사용자 로그인 지정
            req.Credentials = new NetworkCredential(textUser.Text, textPWD.Text);

            // 파일 여러개 전송은 추후 해결 (Create 할 때 파일명을 어떻게 할 지 고민)
            //foreach (string file in listboxFileNames.Items)
            //{
            //    await using FileStream fileStream = File.Open(file, FileMode.Open, FileAccess.Read);
            //    await using Stream requestStream = req.GetRequestStream();
            //    await fileStream.CopyToAsync(requestStream);
            //}

            await using FileStream fileStream = File.Open(textFileName.Text, FileMode.Open, FileAccess.Read);       // 첫 경로 = FullPath
            await using Stream requestStream = req.GetRequestStream();
            await fileStream.CopyToAsync(requestStream);

            

            

            // FTP 결과 상태 출력 시 계속 로딩이 걸림. (추후 해결)
            //using FtpWebResponse response = (FtpWebResponse)req.GetResponse();
            //MessageBox.Show($"Upload File Complete, status {response.StatusDescription}");
        }
    }
}
