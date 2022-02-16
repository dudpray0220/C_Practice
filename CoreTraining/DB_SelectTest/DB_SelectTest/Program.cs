using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using System.Collections;

namespace DB_SelectTest
{
    internal class Program
    {
        // Dapper Select 값 담기 시도 1
        static void Main(string[] args)
        {
            IDbConnection connectionFactory()
            {
                string ConnString = "Server=172.16.10.109; Database=mstation; Uid=root; Pwd=1234qwer";
                IDbConnection db = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
                return db;
            }
            string sql = "SELECT Dept_Code, TemplateCode FROM formmgmt;";

            using (var connection = connectionFactory())
            {
                var result = connection.Query(sql).ToArray();
                Console.WriteLine("-- dynamic mapping:" + result.Count() + "\n");

                foreach (var p in result)
                {
                    Console.WriteLine(string.Format("부서코드:{0}, 서식코드:{1}", p.Dept_Code, p.TemplateCode));
                }
                Console.WriteLine();

                // 이것으로 씁시다!
                Console.WriteLine(result.Length);
                Console.WriteLine(result.Count() + "\n");
                //for (int i = 0; i < result.Count(); i++)
                //{
                //    //Console.WriteLine(result[i].Dept_Code + " : " + result[i].TemplateCode);
                //}

                string[] arr = ((IEnumerable)result).Cast<object>()
                                 .Select(x => x.ToString())
                                 .ToArray();

                for (int i = 0; i < result.Length; i++)
                {
                    Console.WriteLine(arr[i]);
                }
                Console.WriteLine(arr[0]);
            }
        }
    }
}