using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;
using System.IO;
using System.Threading;

namespace SendProcess
{
    public class SendData
    {
        ArrayList list = new ArrayList();
        MySqlConnection m_sqlcon = null;
        DirectoryInfo directory = null;
        Thread th = null;
        string ConnString = "Server=172.16.10.109; Database=mstation; Port=3306; Uid=root; Pwd=1234qwer; convert zero datetime=True";
        string selectFormmgmt = "SELECT Dept_Code, TemplateCode FROM formmgmt;";
        string updateReserved = @"UPDATE reservedsenddata a
                                INNER JOIN formmgmt b
                                ON a.TemplateCode = b.TemplateCode
                                SET a.`STATUS` = '재발송', a.FILENAME = '00001_11001_20180725_0808_173017'
                                WHERE STATUS = '미발송' AND
                                NOW() > BALSONG_DT";
        string folderName = "";
        string newFolderName = "";

        public void Send()
        {
            using (MySqlConnection m_sqlcon = new MySqlConnection(ConnString))
            {
                m_sqlcon.Open();

                try
                {
                    MySqlCommand cmd = new MySqlCommand(selectFormmgmt, m_sqlcon);
                    var reader = cmd.ExecuteReader();
                    DataSet ds = new DataSet();


                    // formmgmt 에서 부서, 서식코드 Select
                    while (reader.Read())
                    {
                        string data1 = reader["Dept_Code"].ToString();
                        string data2 = reader["TemplateCode"].ToString();
                        list.Add(data1);
                        list.Add(data2);
                    }
                    reader.Close(); // close를 안해주면 밑에서 MySqlDataAdapter 사용 시 예외 발생.


                    // formmgmt 테이블에서 select한 값으로 reservedsenddata 테이블에서 SELECT 후 .lock 파일 생성
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
                    ds.WriteXml(@"C:\Mstation\data\temp\00001_11001_20180725_0808_173017.lock");        // .lock 파일 생성


                    // reservedsenddata 테이블 UPDATE
                    cmd = new MySqlCommand(updateReserved, m_sqlcon);
                    cmd.ExecuteNonQuery();


                    // .lock 파일 이동 + 확장자 변경 
                    string folderName = @"C:\Mstation\data\temp\";
                    string newFolderName = @"C:\Mstation\data\snd\";
                    DirectoryInfo directory = new DirectoryInfo(folderName);

                    foreach (FileInfo file in directory.GetFiles())
                    {
                        if (file.Extension.ToLower().CompareTo(".lock") == 0)
                        {
                            string fileNameOnly = file.Name.Substring(0, file.Name.Length - 5) + ".snd";     // 확장자만 뺀 후 .snd로 교체
                            string fullFileName = file.FullName;
                            File.Move(fullFileName, newFolderName + fileNameOnly);
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Trace.WriteLine(e.Message);
                }
            }
        }

        public void Start()
        {
            SendData sendData = new SendData();
            //Thread th = new Thread(new ThreadStart(sendData.Send));
            th = new Thread(new ThreadStart(sendData.Send));
            th.Start();
        }

        public void Stop()
        {
            SendData sendData = new SendData();
            th = new Thread(new ThreadStart(sendData.Send));
            th.Interrupt(); 
        }
    }
}

