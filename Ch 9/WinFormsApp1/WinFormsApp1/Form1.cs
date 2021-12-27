using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 조절을 위한 변수
            int height = 23;

            // 레이블, 링크레이블 생성
            Label label = new Label()
            {
                Text = "text",
                Location = new Point(10, 10),
                Height = height
            };
            LinkLabel linkLabel = new LinkLabel()
            {
                Text = "text",
                Location = new Point(10, 50),
                Height = height
            };

            //  요소에 이벤트를 연결
            linkLabel.Click += LabelClick;

            // 요소를 화면에 추가
            Controls.Add(label);
            Controls.Add(linkLabel);
        }

        // 이벤트 제어
        private void LabelClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://hanb.co.kr"); // 사이트 연결
            System.Diagnostics.Process.Start("notepad.exe");      // 응용프로그램 연결
        }
    }
}
