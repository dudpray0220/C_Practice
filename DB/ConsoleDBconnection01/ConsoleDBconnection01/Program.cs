using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace ConsoleDBconnection01
{
    public class MariaDBTester
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
                Console.WriteLine("Success");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        // 데이터 조회
        public void SelectDB()
        {
            string conn_string = string.Format("Server={0};Database={1};Port={2};Uid={3};Pwd={4};", "127.0.0.1", "test", "3306", "root", "1234qwer");
            string sql_string = "select * from test1";

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
            string sql_string = "Insert into test1 (name, number) values ('happy','1500')";

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
            string sql_string = "Update test1 set name = '꼬돌이' where name = 'happy'";

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
            string sql_string = "Delete from test1 where number = 5";
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
        public void GetUser()
        {
            string conn_string = string.Format("Server={0};Database={1};Port={2};Uid={3};Pwd={4};", "127.0.0.1", "test", "3306", "root", "1234qwer");
            string sql = "select * from test1 order by number desc";
            DataSet dataSet = new DataSet();

            using (MySqlConnection conn = new MySqlConnection(conn_string))
            {
                conn.Open();
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sql, conn);
                mySqlDataAdapter.Fill(dataSet);
            }
            
            foreach (DataRow item in dataSet.Tables[0].Rows)
            {
                Console.WriteLine(item["name"] + " : " +  item["number"]);
            }        
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MariaDBTester mariaDBTester = new MariaDBTester();
            MariaDBTester.ConnectionTest(); // static 메서드
            //mariaDBTester.SelectDB(); // instance 메서드
            mariaDBTester.InsertDB();
            mariaDBTester.UpdateDB();
            //mariaDBTester.DeleteDB();
            Console.WriteLine();
            mariaDBTester.GetUser();
        }
    }
}
