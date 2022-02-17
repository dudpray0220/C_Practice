﻿using System;
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
        string ConnString = "Server=172.16.10.109; Database=mstation; Port=3306; Uid=root; Pwd=1234qwer; convert zero datetime=True";
        ArrayList list = new ArrayList();

        // frommgmt 테이블 Select 후 값 변수에 담기 메서드 
        public DataSet Select_FileWrite(string query)
        {
            MySqlConnection m_sqlcon = new MySqlConnection(ConnString);
            m_sqlcon.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, m_sqlcon);
                var reader = cmd.ExecuteReader();
                DataSet ds = new DataSet();

                while (reader.Read())
                {
                    string data1 = reader["Dept_Code"].ToString();
                    string data2 = reader["TemplateCode"].ToString();
                    list.Add(data1);
                    list.Add(data2);
                }
                reader.Close(); // close를 안해주면 밑에서 MySqlDataAdapter 사용 시 예외 발생.

                for (int i = 1; i < list.Count; i += 2) // 1, 3, 5, 7, ...
                {
                    string selectReservedQuery = String.Format(@"SELECT * from reservedsenddata 
                                        WHERE TemplateCode = '{0}' AND
                                        NOW() > BALSONG_DT AND
                                        STATUS = '미발송'
                                        ORDER BY BALSONG_DT LIMIT 5000;", list[i]);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(selectReservedQuery, m_sqlcon);
                    adapter.Fill(ds);
                }
                ds.WriteXml(@"C:\Mstation\data\temp\00001_11001_20180725_0808_173017.lock");
                m_sqlcon.Close();
                return ds;
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                return null;
            }
        }
    }
}