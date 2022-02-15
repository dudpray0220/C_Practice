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

namespace M_AppTest
{   // 아직 불완전하여 안 씁니다.
    internal class DBManager : Form1
    {
        // DB 연결 메서드
        public void Connect()
        {
            string conn_str = string.Format("Server={0}; Database={1}; Port={2}; Uid={3}; Pwd={4};", "172.16.10.109", "mstation", "3306", "root", "1234qwer");
            using (MySqlConnection conn = new MySqlConnection(conn_str))
            {
                try
                {
                    conn.Open(); // connection
                    MessageBox.Show("DB Connect Success!");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        // Insert 메서드
        public void Insert()
        {
            string conn_str = string.Format("Server={0}; Database={1}; Port={2}; Uid={3}; Pwd={4};", "172.16.10.109", "mstation", "3306", "root", "1234qwer");
            string sql = string.Format("Insert into reservedsenddata (JEONSONG_NO, SUSINJA_NM, TemplateCode) values ('{0}', '{1}', '{2}');", textNumber.Text, textName.Text, textTemplate.Text);
            string sql2 = "INSERT INTO rsinfotable (RSLinkCode) VALUES (LAST_INSERT_ID());";
            MySqlConnection conn = new MySqlConnection(conn_str);

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                cmd.CommandText = sql2;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Insert Success!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
