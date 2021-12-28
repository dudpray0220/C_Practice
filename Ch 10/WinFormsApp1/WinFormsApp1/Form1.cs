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
        class Product
        {
            public string Name { get; set; }
            public int Price { get; set; }
        }

        public Form1()
        {
            InitializeComponent();

            // 데이터 소스를 선택.
            var dataSource = new List<Product>
               {
                   new Product() {Name = "potato", Price = 1000 },
                   new Product() {Name = "carrot", Price = 2000 },
                   new Product() {Name = "orange", Price = 3000 }
               };

            // 콤보박스 설정
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Price";
            comboBox1.DataSource = dataSource;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;       // 이벤트 연결

            // 리스트 박스 설정
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "Price";
            listBox1.DataSource = dataSource;
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;                // 이벤트 연결
        }

        // 이벤트 제어
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = comboBox1.SelectedIndex + " : " + comboBox1.SelectedValue + " : " + ((Product)comboBox1.SelectedItem).Name;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = listBox1.SelectedIndex + " : " + listBox1.SelectedValue + " : " + ((Product)listBox1.SelectedItem).Name;
        }
    }
}
