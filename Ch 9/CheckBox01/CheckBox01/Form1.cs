using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckBox01
{
    public partial class Form1 : Form
    {
        class CustomForm : Form
        {
            public CustomForm()
            {
                this.Size = new Size(400, 300);
                this.Text = "Text man~";
            }
        }
        public Form1()
        {
            InitializeComponent();

            // 조절 변수
            int width = 100;
            int height = 23;
            int margin = 3;
            // 체크박스 생성
            CheckBox checkBox1 = new CheckBox()
            {
                Text = "potato",
                Width = width,
                Height = height,
                Location = new Point(10, height * 0 + margin)
            };
            CheckBox checkBox2 = new CheckBox()
            {
                Text = "carrot",
                Width = width,
                Height = height,
                Location = new Point(10, height * 1 + margin)
            };
            CheckBox checkBox3 = new CheckBox()
            {
                Text = "amond",
                Width = width,
                Height = height,
                Location = new Point(10, height * 2 + margin)
            };
            // 버튼 생성
            Button button = new Button()
            {
                Text = "Click",
                Width = width,
                Height = height,
                Location = new Point(10, height * 3 + margin)
            };
            // 버튼 클릭 메서드
            button.Click += ButtonClick;

            // 요소 화면에 추가
            Controls.Add(checkBox1);
            Controls.Add(checkBox2);
            Controls.Add(checkBox3);
            Controls.Add(button);
        }

        // 버튼 클릭 시 이벤트 제어
        private void ButtonClick(object sender, EventArgs e)
        {
            // 리스트 생성
            List<string> list = new List<string>();

            // 리스트에 체크된 요소를 추가하고자 반복문
            foreach (var item in Controls) // 화면에 추가된 요소들에서 돔.
            {
                if (item is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)item;
                    if (checkBox.Checked)
                    {
                        list.Add(checkBox.Text);
                    }
                }
            }

            // 리스트를 붙여 문자열을 만듬
            MessageBox.Show(string.Join(", ", list));
        }
    }
}
