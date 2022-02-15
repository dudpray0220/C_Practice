using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace M_AppTest
{
    // 인터페이스 선언
    public interface ITLDatabase
    {
        void Init(string server, string database, string port, string id, string pwd);
        void Connect();
        void Disconnect();
        object ExcuteQuery(string query);     // select는 가변 string이기 때문에 ExcuteQuery를 쓴다. 
        int ExcuteNonQuery(string query);   // Insert, Update, Delete 는 return 값이 숫자이기 때문에 ExcuteNonQuery를 쓴다.
    }

    internal class Database 
    {
        // DB 연결정보
        MySqlConnection m_sqlcon = null;
        public void Init(string server, string database, string port, string id, string pwd)
        {
            string connInfo = string.Format("Server={0}; Database={1}; Port={2}; Uid={3}; Pwd={4};", server, database, port, id, pwd);
            m_sqlcon = new MySqlConnection(connInfo);
        }
        // DB 연결 메서드
        public void Connect()
        {
            if (m_sqlcon == null) return;
            m_sqlcon.Open();
        }

        // DB 연결 해제 메서드
        public void Disconnect()
        {
            if (m_sqlcon != null) m_sqlcon.Close();
            m_sqlcon = null;
        }

        // 쿼리실행 select (가변 string이므로 ExcuteQuery) 메서드
        public object ExcuteQuery(string query)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, m_sqlcon);
                return cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                return null;
            }
        }

        public int ExcuteNonQuery(string query)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, m_sqlcon);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                return -1;   // 만약 무슨 에러가 있었다면 0이 아닌 값, 예를 들어 1이나 2 또는 -1 등을 윈도우로 반환해야 합니다.
            }
        }

        public int ExcuteTransaction(string[] query)
        {
            int ret = 0;
            MySqlCommand cmd = null;
            MySqlTransaction tran = null;
            try
            {
                cmd = m_sqlcon.CreateCommand();
                tran = m_sqlcon.BeginTransaction();
            }
            catch (Exception _e)
            {
                System.Diagnostics.Trace.WriteLine(_e.Message);
                return -1;
            }
            try
            {
                for (int i = 0; i < query.Length; i++)
                {
                    cmd.CommandText = query[i];
                    ret += cmd.ExecuteNonQuery();
                }
                tran.Commit();
            }
            catch (Exception _e)
            {
                System.Diagnostics.Trace.WriteLine(_e.Message);
                tran.Rollback();
                return -1;
            }
            return ret;
        }
    }
}
