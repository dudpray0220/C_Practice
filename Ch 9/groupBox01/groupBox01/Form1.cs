using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace groupBox01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // 조절 변수
            int width = 100;
            int height = 23;
            int margin = 3;

            // 그룹박스 생성
            GroupBox groupBox1 = new GroupBox()
            {
                Text = "채소",
                Location = new Point(margin, margin),
                Size = new Size(width + margin * 2, height * 3 + margin * 2)
            };
            GroupBox groupBox2 = new GroupBox()
            {
                Text = "과일",
                Location = new Point(margin * 5 + width, margin),
                Size = new Size(width + margin * 2, height * 3 + margin * 2)
            };
            // 라디오 버튼 생성
            RadioButton radioButton1 = new RadioButton()
            {
                Text = "potato",
                Width = width,
                Height = height,
                Location = new Point(margin, height * 1 + margin)
            };
            RadioButton radioButton2 = new RadioButton()
            {
                Text = "carrot",
                Width = width,
                Height = height,
                Location = new Point(margin, height * 2 + margin)
            };
            RadioButton radioButton3 = new RadioButton()
            {
                Text = "peach",
                Width = width,
                Height = height,
                Location = new Point(margin, height * 1 + margin)
            };
            RadioButton radioButton4 = new RadioButton()
            {
                Text = "orange",
                Width = width,
                Height = height,
                Location = new Point(margin, height * 2 + margin)
            };
            // 버튼 생성
            Button button = new Button()
            {
                Text = "Click",
                Width = width,
                Height = height,
                Location = new Point(margin, height * 3 + margin * 4)
            };

            // 이벤트 연결
            button.Click += ButtonClick;

            // 라디오 버튼을 그룹박스에 추가
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(radioButton2);
            groupBox2.Controls.Add(radioButton3);
            groupBox2.Controls.Add(radioButton4);

            // 요소를 화면에 추가
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(button);
        }

        // 이벤트 제어 -> 반복문 2번, as 키워드
        private void ButtonClick(object sender, EventArgs e)
        {
            foreach (var outerItem in Controls)
            {
                if (outerItem is GroupBox)
                {
                    foreach (var innerItem in ((GroupBox)outerItem).Controls)
                    {
                        RadioButton radioButton = innerItem as RadioButton;
                        if (radioButton != null && radioButton.Checked)
                        {
                            MessageBox.Show(radioButton.Text);
                        }
                    }
                }
            }
        }
    }
}

