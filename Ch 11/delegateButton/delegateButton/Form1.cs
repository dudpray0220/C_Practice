using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace delegateButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            int closerVariable = 52273;

            Button button = new Button();

            button.Text = "button";
            button.Click += delegate (object sender, EventArgs e)
            {
                MessageBox.Show("delegator : " + closerVariable);
            };

            Controls.Add(button);
        }

    }
}
