using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataGridView01
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

            // 데이터 소스 선택
            var dataSource = new List<Product>
            {
                new Product() {Name = "potato", Price = 1000 },
                new Product() {Name = "carrot", Price = 2000 },
                new Product() {Name = "amond", Price = 3000 }
            };

            dataGridView1.DataSource = dataSource;
        }

    }
}
