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

namespace WinFormDataGrid01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MariaDB.ConnectionTest();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MariaDB mariaDB = new MariaDB();
            DataSet ds;
            ds = mariaDB.GetUser();
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }
    }
    public class MariaDB
    {
        // 접속 테스트
        public static bool ConnectionTest()
        {
            string conn_string = string.Format("Server={0};Database={1};Port={2};Uid={3};Pwd={4};", "127.0.0.1", "test", "3306", "root", "1234qwer");
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conn_string))
                {
                    conn.Open();
                }
                MessageBox.Show("Connection Success!");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        // 데이터 조회
        public void SelectDB()
        {
            string conn_string = string.Format("Server={0};Database={1};Port={2};Uid={3};Pwd={4};", "127.0.0.1", "test", "3306", "root", "1234qwer");
            string sql_string = "select * from test2";

            using (MySqlConnection conn = new MySqlConnection(conn_string))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql_string, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine(reader.Read());
                reader.Close();
            }
        }

        // INSERT
        public void InsertDB()
        {
            string conn_string = string.Format("Server={0};Database={1};Port={2};Uid={3};Pwd={4};", "127.0.0.1", "test", "3306", "root", "1234qwer");
            string sql_string = "Insert into test2 (name, number) values ('happy','1500')";

            using (MySqlConnection conn = new MySqlConnection(conn_string))
            {
                conn.Open(); // 연결

                MySqlCommand cmd = new MySqlCommand(sql_string, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("INSERT Success!");
            }
        }
        // UPDATE
        public void UpdateDB()
        {
            string conn_string = string.Format("Server={0};Database={1};Port={2};Uid={3};Pwd={4};", "127.0.0.1", "test", "3306", "root", "1234qwer");
            string sql_string = "Update test2 set name = '꼬돌이' where name = 'happy'";

            using (MySqlConnection conn = new MySqlConnection(conn_string))
            {
                conn.Open(); // 연결

                MySqlCommand cmd = new MySqlCommand(sql_string, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Update Success!");
            }
        }
        // DELETE
        public void DeleteDB()
        {
            string conn_string = string.Format("Server={0};Database={1};Port={2};Uid={3};Pwd={4};", "127.0.0.1", "test", "3306", "root", "1234qwer");
            string sql_string = "Delete from test2 where number = 5";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conn_string))
                {
                    conn.Open(); // 연결

                    MySqlCommand cmd = new MySqlCommand(sql_string, conn);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Delete Success!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        // 데이터 조회 인스턴스 메서드
        public DataSet GetUser()
        {
            string conn_string = string.Format("Server={0};Database={1};Port={2};Uid={3};Pwd={4};", "127.0.0.1", "test", "3306", "root", "1234qwer");
            string sql = "select * from test2 order by score desc";
            DataSet dataSet = new DataSet();

            using (MySqlConnection conn = new MySqlConnection(conn_string))
            {
                conn.Open();
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sql, conn);
                mySqlDataAdapter.Fill(dataSet);
            }

            return dataSet;
        }
    }
}
