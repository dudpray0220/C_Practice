using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DB_SelectTest3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnString = "Server=172.16.10.109; Database=mstation; Port=3306; Uid=root; Pwd=1234qwer";
            MySqlConnection m_sqlcon = new MySqlConnection(ConnString);
            m_sqlcon.Open();

            //string selectQuery = @"SELECT * from reservedsenddata 
            //                            WHERE TemplateCode = '1001' AND
            //                            NOW() > BALSONG_DT AND
            //                            STATUS = '미발송'
            //                            ORDER BY BALSONG_DT LIMIT 5000;";
            string selectQuery = "select * from rsinfotable";

            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, m_sqlcon);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "reservedsenddata");
            DataTable dt = ds.Tables["reservedsenddata"];
            m_sqlcon.Close();

            dataGridView1.DataSource = dt;
        }
    }
}
