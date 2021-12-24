using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAppInheritance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("content");
            MessageBox.Show("content", "title");

            DialogResult result;
            do
            {
                result = MessageBox.Show("content", "title", MessageBoxButtons.RetryCancel);
            } while (result == DialogResult.Retry);
        }
    }
}
