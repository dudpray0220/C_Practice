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
using System.IO;

namespace DB_SelectTest2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string query = "SELECT Dept_Code, TemplateCode FROM formmgmt;";
            string ConnString = "Server=172.16.10.109; Database=mstation; Port=3306; Uid=root; Pwd=1234qwer; convert zero datetime=True";
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
                    reader.Close();

                    int index = list.IndexOf("1004");
                    Console.WriteLine(list[0]);
                    Console.WriteLine(list.Count);
                    Console.WriteLine(index + "\n");

                    //foreach (var item in list)
                    //{
                    //    Console.WriteLine(item);
                    //}

                    //for (int i = 1; i < list.Count; i += 2) // 1, 3, 5, 7, ...
                    //{
                    //    string selectQuery = string.Format(@"SELECT * from reservedsenddata 
                    //                    WHERE TemplateCode = '{0}' AND
                    //                    NOW() > BALSONG_DT AND
                    //                    STATUS = '미발송'
                    //                    ORDER BY BALSONG_DT LIMIT 5000;", list[i]);

                    //    using (MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(selectQuery, m_sqlcon))
                    //    {
                    //        using (DataSet dataSet = new DataSet())
                    //        {
                    //            sqlDataAdapter.Fill(dataSet);
                    //            for (int nRowCount = 0; nRowCount < dataSet.Tables[0].Rows.Count; nRowCount++)
                    //            {
                    //                DataRow dataRow = dataSet.Tables[0].Rows[nRowCount];
                    //                string sServer = dataRow["BALSONG_DT"].ToString().Trim();
                    //                Console.WriteLine(sServer);
                    //            }
                    //        }
                    //    }
                    //}


                    DataSet ds = new DataSet();
                    for (int i = 1; i < list.Count; i += 2) 
                    {
                        string selectQuery = String.Format(@"SELECT * from reservedsenddata 
                                        WHERE TemplateCode = '{0}' AND
                                        NOW() > BALSONG_DT AND
                                        STATUS = '재발송'
                                        ORDER BY BALSONG_DT LIMIT 5000;", list[i]); // list[i]는 서식코드

                        Console.WriteLine(list[i]);

                        MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, m_sqlcon);
                        adapter.Fill(ds);
                    }

                    //ds.WriteXml(@"C:\Mstation\data\temp\00001_11001_20180725_1234_173017.lock");
                    string[] fields = new string[16]; // 테이블의 컬럼수가 16
                    string[] fields2 = new string[16]; // 테이블의 컬럼수가 16
                    
                    Console.WriteLine("행수: " + ds.Tables[0].Rows.Count);
                    Console.WriteLine("열수: " + ds.Tables[0].Columns.Count + "\n");
                    //string savePath = @"C:\Mstation\data\temp\00002_11001_20180725_0808_173017.lock";       // 파일 이름
                    //File.WriteAllLines(savePath, fields);

                    for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                    {
                        fields[i] = ds.Tables[0].Columns[i].ToString();
                        Console.WriteLine(fields[i]);

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {                          //dr[컬럼의 이름이나 인덱스]
                            //Console.WriteLine(dr[fields[i]].ToString());
                            fields2[i] = dr[fields[i]].ToString();
                        }
                        Console.WriteLine(fields2[i]);
                        Console.WriteLine();
                    }
                    string str_params = string.Join(",", fields);  //string 배열을  하나의 string 변수로 만들어줍니다.  사이사이에 ','를 삽입해주면서
                    string str_params2 = string.Join(",", fields2);  //string 배열을  하나의 string 변수로 만들어줍니다.  사이사이에 ','를 삽입해주면서
                    str_params = str_params.Substring(0, str_params.Length - 1);  //마지막에 들어가는  ',' 삭제 코드입니다.   이거 없이 그대로 사용하면 oledb error가 납니다.
                    str_params2 = str_params.Substring(0, str_params.Length - 1);  //마지막에 들어가는  ',' 삭제 코드입니다.   이거 없이 그대로 사용하면 oledb error가 납니다.
                    Console.WriteLine(str_params2);

                    m_sqlcon.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
