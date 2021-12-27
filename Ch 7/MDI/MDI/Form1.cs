using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI
{
    public partial class Form1 : Form
    {
        class CustomForm : Form
        {
            public CustomForm ()
            {
                this.Size = new Size(300, 400);
                this.Text = "Hi";
            }
        }
        public Form1()
        {
            InitializeComponent();
            //IsMdiContainer = true;
        }

        private void MyButton_Click(object sender, EventArgs e)
        {
            CustomForm form = new CustomForm();
           // form.MdiParent = this;
            form.ShowDialog();
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
