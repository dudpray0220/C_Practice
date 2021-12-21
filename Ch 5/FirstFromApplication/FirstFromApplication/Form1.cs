using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstFromApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int width = 100;
            int height = 23;
            int margin = 6;
            myButton.Text = "생성";
            myButton.Width = 100;
            myButton.Location = new Point(margin, margin);

            for (int i = 0; i < 5; i++)
            {
                Button button = new Button();
                Controls.Add(button); // 붙이고
                button.Location = new Point(margin, (height + margin) * (i + 1) + margin); // 위치설정
                button.Text = "동적 생성" + i + "번째";
                button.Width = width;
                button.Height = height;
            }
        }
    }
}
