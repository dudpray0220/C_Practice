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
using Dapper;
using DBManager;        // DLL 사용
using Select_Write;

namespace M_AppTest
{
    public partial class Form2 : Form
    {
        Database m_Database = new Database();
        SWDB selectWrite_DB = new SWDB();
        //private string selectFormmgmt = "";
        //private string selectReserve = "";
        //private dynamic[] SelectResult = null;

        public Form2()
        {
            InitializeComponent();
        }

        private void btn_FormmgmtSelect_Click(object sender, EventArgs e)
        {
            string query = "SELECT Dept_Code, TemplateCode FROM formmgmt;";
            selectWrite_DB.Select_FileWrite(query);
            //dataGridView1.DataSource = selectWrite_DB.Select_FileWrite(query).Tables[0];
        }

        // 파일명 자동화를 위해서 첫 번쨰 버튼에 업데이트까지 구현!
        private void btn_ReservedUpdate_Click(object sender, EventArgs e)
        {
            string query = @"UPDATE reservedsenddata a
                                INNER JOIN formmgmt b
                                ON a.TemplateCode = b.TemplateCode
                                SET a.`STATUS` = '재발송', a.FILENAME = '00003_11001_20180725_3333_173017'
                                WHERE STATUS = '미발송' AND
                                NOW() > BALSONG_DT";
            selectWrite_DB.reservedUpdate(query);
        }

        private void btn_ReservedReset_Click(object sender, EventArgs e)
        {
            string query = "UPDATE reservedsenddata SET STATUS = '미발송', FILENAME = '0'";
            selectWrite_DB.reservedUpdate(query);
        }

        private void btn_FileMove_Click(object sender, EventArgs e)
        {
            selectWrite_DB.moveFile();
        }

        private void btn_FileMoveReset_Click(object sender, EventArgs e)
        {
            selectWrite_DB.moveReset();
        }
    }
}
