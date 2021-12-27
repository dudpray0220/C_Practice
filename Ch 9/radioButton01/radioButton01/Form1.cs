using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace radioButton01
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
            // 체크박스 생성
            RadioButton radioButton1 = new RadioButton()
            {
                Text = "potato",
                Width = width,
                Height = height,
                Location = new Point(10, height * 0 + margin)
            };
            RadioButton radioButton2 = new RadioButton()
            {
                Text = "carrot",
                Width = width,
                Height = height,
                Location = new Point(10, height * 1 + margin)
            };
            RadioButton radioButton3 = new RadioButton()
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
            button.Click += ButtonClick;

            Controls.Add(radioButton1);
            Controls.Add(radioButton2);
            Controls.Add(radioButton3);
            Controls.Add(button);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            foreach (var item in Controls)
            {
                if (item is RadioButton)
                {
                    RadioButton radioButton = (RadioButton)item;
                    if (radioButton.Checked)
                    {
                        MessageBox.Show(radioButton.Text);
                    }
                }
            }
        }
    }
}
