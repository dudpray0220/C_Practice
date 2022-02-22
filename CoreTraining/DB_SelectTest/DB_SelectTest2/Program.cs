using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections;
using System.IO;

namespace DB_SelectTest2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string query = "SELECT Dept_Code, TemplateCode FROM formmgmt;";
            string ConnString = "Server=172.16.10.109; Database=mstation; Port=3306; Uid=root; Pwd=1234qwer; convert zero datetime=True";
            Random random = new Random();
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
                                        STATUS = '미발송'
                                        ORDER BY BALSONG_DT LIMIT 5000;", list[i]); // list[i]는 서식코드

                        Console.WriteLine(list[i]);

                        MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, m_sqlcon);
                        adapter.Fill(ds);       // DataSet 채우기
                    }

                    string[] fields = new string[16]; // 테이블의 컬럼수가 16
                    string[] fields2 = new string[16]; // 테이블의 컬럼수가 16
                                                       //DataRow dr = ds.Tables[0].Rows[0];

                    Console.WriteLine("\n행수: " + ds.Tables[0].Rows.Count);
                    Console.WriteLine("열수: " + ds.Tables[0].Columns.Count + "\n"); // 15
                    string savePath = String.Format(@"C:\Mstation\data\temp\0000{0}_{1}001_20180725_3333_17301{2}.lock", random.Next(0, 9), random.Next(10, 99), random.Next(0, 9));       // 파일 이름
                    string ftpTempPath = String.Format(@"ftp://172.16.10.109/temp/0000{0}_{1}001_20180725_3333_17301{2}.lock", random.Next(0, 9), random.Next(10, 99), random.Next(0, 9));       // 파일 이름

                    // FTP 통신
                    FtpWebRequest req = (FtpWebRequest)WebRequest.Create(ftpTempPath);
                    req.Method = WebRequestMethods.Ftp.UploadFile;
                    req.Credentials = new NetworkCredential("tilon", "1234qwer");

                    // 컬럼값 담기 for문
                    for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                    {
                        fields[i] = ds.Tables[0].Columns[i].ToString();     // 컬럼값을 돌면서 다 담음. 컬럼값 = fields[i]
                        Console.WriteLine(fields[i]);
                        Console.WriteLine();
                    }

                    if (File.Exists(savePath)) File.Delete(savePath);   // 파일이 존재하면 삭제 후 생성
                    // 모든 Row값 담기 foreach문
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        // Row값 담기 for문
                        for (int i = 1; i < ds.Tables[0].Columns.Count; i++)    // index는 빼고 담으니 int = 1 부터! / 마지막 MMS_STATUS는 14번째 인덱스!
                        {
                            fields2[i] = dr[fields[i]].ToString();
                            Console.Write(fields2[i]);
                        }

                        string params3 = fields2[1] + "|" + fields2[9];     // 전송 양식 : 전송넘버|서식코드|나머지^나머지^나머지 (Index는 빼고)
                        // 전송양식대로 파싱하는 for문
                        for (int i = 2; i < ds.Tables[0].Columns.Count; i++)
                        {
                            if (i == 9) continue;  // 서식코드는 위에 추가했으니 continue
                            params3 += "^" + fields2[i];
                        }
                        Console.WriteLine("\n" + params3 + "\n");

                        // 파일에 파싱한 전송 양식대로 한 줄씩 쓰기!
                        using (StreamWriter outputFile = new StreamWriter(savePath, true))
                        {
                            outputFile.WriteLine(params3);
                        }
                    }
                    await using FileStream fileStream = File.Open(savePath, FileMode.Open, FileAccess.Read);       // 첫 경로 = FullPath
                    await using Stream requestStream = req.GetRequestStream();
                    await fileStream.CopyToAsync(requestStream);
                    

                    //string str_params = string.Join(",", fields);  //string 배열을  하나의 string 변수로 만들어줍니다.  사이사이에 ','를 삽입해주면서
                    File.Move(savePath, savePath.Substring(0, savePath.Length - 5) + ".dm", true);    // 파일 다 쓰면 .lock 에서 .dm으로 변경 (unlock)

                    string folderName = @"C:\Mstation\data\temp\";
                    string newFolderName = @"C:\Mstation\data\dm\";
                    string backUpFolderName = @"C:\Mstation\data\backup\";
                    DirectoryInfo directory = new DirectoryInfo(folderName);

                    // backup으로 복사 (overwrite 가능)
                    foreach (FileInfo file in directory.GetFiles())
                    {
                        if (file.Extension.ToLower().CompareTo(".dm") == 0)
                        {
                            string fileNameOnly = file.Name;
                            string fullFileName = file.FullName;
                            File.Copy(fullFileName, backUpFolderName + fileNameOnly, true);
                        }
                    }

                    // dm으로 이동 (overwrite 가능)
                    foreach (FileInfo file in directory.GetFiles())
                    {
                        if (file.Extension.ToLower().CompareTo(".dm") == 0)
                        {
                            string fileNameOnly = file.Name;
                            string fullFileName = file.FullName;
                            File.Move(fullFileName, newFolderName + fileNameOnly, true);
                        }
                    }

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
