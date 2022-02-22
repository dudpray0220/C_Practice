using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;
using System.IO;

namespace Select_Write
{
    public class SWDB
    {
        MySqlConnection m_sqlcon = null;
        string ConnString = "Server=172.16.10.109; Database=mstation; Port=3306; Uid=root; Pwd=1234qwer; convert zero datetime=True";
        string folderName = @"C:\Mstation\data\temp\";
        string newFolderName = @"C:\Mstation\data\dm\";
        string backUpFolderName = @"C:\Mstation\data\backup\";
        Random random = new Random();   // 파일명 테스트 위한 난수
        DirectoryInfo directory = null;


        // frommgmt 테이블 Select 후 값 변수에 담기 메서드 
        public void Select_FileWrite(string query)
        {
            MySqlConnection m_sqlcon = new MySqlConnection(ConnString);
            m_sqlcon.Open();

            try
            {
                using (MySqlCommand command = new MySqlCommand(query, m_sqlcon))
                {
                    var list = new ArrayList();
                    var reader = command.ExecuteReader();
                    DataSet ds = new DataSet();

                    while (reader.Read())
                    {
                        string data1 = reader["Dept_Code"].ToString();
                        string data2 = reader["TemplateCode"].ToString();
                        list.Add(data1);
                        list.Add(data2);
                    }
                    reader.Close();

                    for (int i = 1; i < list.Count; i += 2)
                    {
                        string selectQuery = String.Format(@"SELECT * from reservedsenddata 
                                        WHERE TemplateCode = '{0}' AND
                                        NOW() > BALSONG_DT AND
                                        STATUS = '미발송'
                                        ORDER BY BALSONG_DT LIMIT 5000;", list[i]); // list[i]는 서식코드

                        MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, m_sqlcon);
                        adapter.Fill(ds);       // DataSet 채우기
                    }

                    string[] fields = new string[16]; // 테이블의 컬럼수가 16
                    string[] fields2 = new string[16]; // 테이블의 컬럼수가 16
                    string savePath = String.Format(@"C:\Mstation\data\temp\0000{0}_{1}001_20180725_3333_17301{2}.lock", random.Next(0, 9), random.Next(10, 99), random.Next(0, 9));       // 파일 이름

                    // 컬럼값 담기 for문
                    for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                    {
                        fields[i] = ds.Tables[0].Columns[i].ToString();     // 컬럼값을 돌면서 다 담음. 컬럼값 = fields[i]
                    }

                    if (File.Exists(savePath)) File.Delete(savePath);   // 파일이 존재하면 삭제 후 생성

                    // 모든 Row값 담기 foreach문
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        // Row값 담기 for문
                        for (int i = 1; i < ds.Tables[0].Columns.Count; i++)    // index는 빼고 담으니 int = 1 부터! / 마지막 MMS_STATUS는 14번째 인덱스!
                        {
                            fields2[i] = dr[fields[i]].ToString();
                        }

                        string params3 = fields2[1] + "|" + fields2[9];     // 전송 양식 : 전송넘버|서식코드|나머지^나머지^나머지 (Index는 빼고)
                        // 전송양식대로 파싱하는 for문
                        for (int i = 2; i < ds.Tables[0].Columns.Count; i++)
                        {
                            if (i == 9) continue;  // 서식코드는 위에 추가했으니 continue
                            params3 += "^" + fields2[i];
                        }

                        // 파일에 파싱한 전송 양식대로 한 줄씩 쓰기!
                        using (StreamWriter outputFile = new StreamWriter(savePath, true))
                        {
                            outputFile.WriteLine(params3);
                        }
                    }
                    File.Move(savePath, savePath.Substring(0, savePath.Length - 5) + ".dm", true);    // 파일 다 쓰면 .lock 에서 .dm으로 변경 (unlock)

                    // backup으로 복사 (overwrite 가능)
                    directory = new DirectoryInfo(folderName);
                    foreach (FileInfo file in directory.GetFiles())
                    {
                        if (file.Extension.ToLower().CompareTo(".dm") == 0)
                        {
                            string fileNameOnly = file.Name;
                            string fullFileName = file.FullName;
                            File.Copy(fullFileName, backUpFolderName + fileNameOnly, true);
                        }
                    }

                    // savePath를 파싱하여 table에 UPDATE될 파일이름 생성
                    string[] fName = savePath.Substring(0, savePath.Length - 5).Split(@"\"); // 확장자 .lock 빼기 -> \로 나누기
                    string tableFName = fName[fName.Length - 1];
                    // reservedsenddata 테이블 UPDATE 로직
                    string updateReserved = String.Format(@"UPDATE reservedsenddata a
                                INNER JOIN formmgmt b
                                ON a.TemplateCode = b.TemplateCode
                                SET a.`STATUS` = '재발송', a.FILENAME = '{0}'
                                WHERE STATUS = '미발송' AND
                                NOW() > BALSONG_DT;", tableFName);
                    using (MySqlCommand cmdUpdate = new MySqlCommand(updateReserved, m_sqlcon))
                    {
                        cmdUpdate.ExecuteNonQuery();
                    }
                    m_sqlcon.Close();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
            }
        }

        // reservedsenddata 테이블에 status, filename 업데이트
        public int reservedUpdate(string query)
        {
            MySqlConnection m_sqlcon = new MySqlConnection(ConnString);
            m_sqlcon.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, m_sqlcon);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                return -1;
            }
        }


        public void moveFile()
        {
            directory = new DirectoryInfo(folderName);

            foreach (FileInfo file in directory.GetFiles())
            {
                if (file.Extension.ToLower().CompareTo(".dm") == 0)
                {
                    string fileNameOnly = file.Name;
                    string fullFileName = file.FullName;
                    File.Move(fullFileName, newFolderName + fileNameOnly, true);
                }
            }
        }


        public void moveReset()
        {
            directory = new DirectoryInfo(newFolderName);

            foreach (FileInfo file in directory.GetFiles())
            {
                if (file.Extension.ToLower().CompareTo(".dm") == 0)
                {
                    string fileNameOnly = file.Name; //.Substring(0, file.Name.Length - 3) + ".lock";     // 확장자만 뺀 후 .lock으로 교체
                    string fullFileName = file.FullName;
                    File.Move(fullFileName, folderName + fileNameOnly);
                }
            }
        }
    }
}
