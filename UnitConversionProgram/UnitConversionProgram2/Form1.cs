using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitConversionProgram2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true; // textbox에 무언갈 쓰면 다른 textbox는 못 쓰도록
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox4.ReadOnly = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox3.ReadOnly = true;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
        }

        private void inchToCm_Click(object sender, EventArgs e)
        {   // Inch to Cm
            if (double.Parse(textBox1.Text) > 0)         // textbox1의 내용이 양수이면
            {
                var inch = double.Parse(textBox1.Text);
                var cm = Math.Round(inch * 2.54, 2);
                textBox2.Text = cm.ToString();
                textBox1.ReadOnly = false;
            }
            else
            {
                textBox1.Text = "양수로 입력하세요!";
            }
        }

        private void CmToInch_Click(object sender, EventArgs e)
        {
            if (double.Parse(textBox2.Text) > 0)         // textbox1의 내용이 양수이면
            {
                var cm = double.Parse(textBox2.Text);
                var inch = Math.Round(cm * 0.393701, 6);
                textBox1.Text = inch.ToString();
                textBox2.ReadOnly = false;
            }
            else
            {
                textBox2.Text = "양수로 입력하세요!";
            }
        }

        private void PoundToKg_Click(object sender, EventArgs e)
        {
            if (double.Parse(textBox3.Text) > 0)         // textbox1의 내용이 양수이면
            {
                var pound = double.Parse(textBox3.Text);
                var kg = Math.Round(pound * 0.453592, 6);
                textBox4.Text = kg.ToString();
                textBox3.ReadOnly = false;
            }
            else
            {
                textBox3.Text = "양수로 입력하세요!";
            }
        }

        private void KgToPound_Click(object sender, EventArgs e)
        {
            if (double.Parse(textBox4.Text) > 0)         // textbox1의 내용이 양수이면
            {
                var kg = double.Parse(textBox4.Text);
                var pound = Math.Round(kg * 2.204623, 6);
                textBox3.Text = pound.ToString();
                textBox4.ReadOnly = false;
            }
            else
            {
                textBox4.Text = "양수로 입력하세요!";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
