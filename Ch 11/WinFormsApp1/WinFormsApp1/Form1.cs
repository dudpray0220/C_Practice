using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog(); // 대화상자 동적생성
            //dialog.ShowDialog();
            //MessageBox.Show(dialog.FileName);
            dialog.Filter = "엑셀 파일입니다 (*.xlsx)|*.xlsx";
            dialog.ShowDialog();
            File.WriteAllText(dialog.FileName, textBox1.Text);
        }
    }
}
