using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsDelegate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 버튼 생성, 설정
            Button button = new Button();
            button.Text = "버튼";
            button.Width = 100;
            button.Height = 23;
            button.Click += delegate (object sender, EventArgs e)
            {
                MessageBox.Show("무명 델리게이터를 통한 이벤트 연결!");
            };
            button.Click += (sender, e) =>
            {
                MessageBox.Show("람다를 통한 이벤트 연결!");
            };

            // 버튼 화면에 추가
            Controls.Add(button);
        }

    }
}
