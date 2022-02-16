using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;

namespace Select_Write
{
    public class SWDB
    {
        MySqlConnection m_sqlcon = null;
        string ConnString = "Server=172.16.10.109; Database=mstation; Port=3306; Uid=root; Pwd=1234qwer";
        ArrayList list = new ArrayList();

        // frommgmt 테이블 Select 후 값 변수에 담기 메서드 
        public object SelectFormmgmt(string query)
        {
            MySqlConnection m_sqlcon = new MySqlConnection(ConnString);
            m_sqlcon.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, m_sqlcon);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string data1 = reader["Dept_Code"].ToString();
                    string data2 = reader["TemplateCode"].ToString();
                    list.Add(data1);
                    list.Add(data2);
                }
                return list;
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                return null;
            }
        }

        // reservedsenddata 조회 메서드
        public void SelectReserved()
        {
            MySqlConnection m_sqlcon = new MySqlConnection(ConnString);
            m_sqlcon.Open();

            for (int i = 1; i < list.Count; i += 2) // 1, 3, 5, 7, ...
            {
                string selectQuery = string.Format(@"SELECT * from reservedsenddata 
                                        WHERE TemplateCode = '{0}' AND
                                        NOW() > BALSONG_DT AND
                                        STATUS = '미발송'
                                        ORDER BY BALSONG_DT LIMIT 5000;", list[i]);
                try
                {
                    MySqlCommand cmd = new MySqlCommand(selectQuery, m_sqlcon);
                    var reader = cmd.ExecuteReader();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Trace.WriteLine(e.Message);
                }
            }
        }
    }
}
