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
        }

        private void open_Click(object sender, EventArgs e)
        {
            DialogResult result;
            do
            {
            result = MessageBox.Show("Hi", "title", MessageBoxButtons.RetryCancel);
            } while (result == DialogResult.Retry);
        }
    }
}
