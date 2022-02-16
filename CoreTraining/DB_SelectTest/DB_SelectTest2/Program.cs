using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections;

namespace DB_SelectTest2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string query = "SELECT Dept_Code, TemplateCode FROM formmgmt;";
            string ConnString = "Server=172.16.10.109; Database=mstation; Port=3306; Uid=root; Pwd=1234qwer";
            MySqlConnection m_sqlcon = new MySqlConnection(ConnString);
            m_sqlcon.Open();
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, m_sqlcon))
                {
                    var list = new ArrayList();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string data1 = reader["Dept_Code"].ToString();
                        string data2 = reader["TemplateCode"].ToString();
                        list.Add(data1);
                        list.Add(data2);
                    }

                    int index = list.IndexOf("1004");
                    Console.WriteLine(list[0]);
                    Console.WriteLine(index + "\n");

                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }

                    for (int i = 1; i < list.Count; i += 2) // 1, 3, 5, 7, ...
                    {
                        string selectQuery = string.Format(@"SELECT * from reservedsenddata 
                                        WHERE TemplateCode = '{0}' AND
                                        NOW() > BALSONG_DT AND
                                        STATUS = '미발송'
                                        ORDER BY BALSONG_DT LIMIT 5000;", list[i]);

                        using (MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(selectQuery, m_sqlcon))
                        {
                            using (DataSet dataSet = new DataSet())
                            {
                                sqlDataAdapter.Fill(dataSet);
                                for (int nRowCount = 0; nRowCount < dataSet.Tables[0].Rows.Count; nRowCount++)
                                {
                                    DataRow dataRow = dataSet.Tables[0].Rows[nRowCount];
                                    string sServer = dataRow["BALSONG_DT"].ToString().Trim();
                                    Console.WriteLine(sServer);
                                }
                            }
                        }
                    }

                }
            }
            catch (MySqlException e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
            }
        }
    }
}
