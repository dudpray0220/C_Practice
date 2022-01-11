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

namespace WinFormDBConnection01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Select 메서드
        public void Select()
        {
            // 연결
            string conn_str = string.Format("Server={0};Database={1};Port={2};Uid={3};Pwd={4};", "127.0.0.1", "test", "3306", "root", "1234qwer");
            string sql = "select * from test2 where score = 100";

            MySqlConnection conn = new MySqlConnection(conn_str);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            try
            {
                conn.Open(); // 연결
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            MySqlDataReader reader = cmd.ExecuteReader(); // 쿼리 실행
            while (reader.Read())
            {
                textBox1.Text += reader["name"].ToString();
                textBox2.Text += reader["score"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Select();
            toolStripStatusLabel1.Text = "Select 쿼리가 실행되었습니다!";
        }
    }
}
