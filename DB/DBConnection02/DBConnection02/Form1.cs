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

namespace DBConnection02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void DBTest()
        {
            string conn_string = string.Format("Server={0};Uid ={1};Pwd={2};", "127.0.0.1", "root", "1234qwer");
            MySqlConnection conn = new MySqlConnection(conn_string);
            MySqlCommand cmd = conn.CreateCommand();

            string sql_makeDB = "show databases"; // 쿼리 문 작성
            cmd.CommandText = sql_makeDB;

            // DB 연결
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message); // 예외객체 메세지로 출력
            }

            // cmd.CommandText를 MySqlConnection로 보내고, MySqlDataReader 객체 생성 (reader) !
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) // 다음기록으로 계속 읽음
            {
                textBox1.Text += reader[0].ToString() + "\n";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBTest();
        }
    }
}
