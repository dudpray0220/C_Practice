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

        private void btn_Init_Click(object sender, EventArgs e)
        {
            m_Database.Init(textIP.Text, textDBName.Text, textPort.Text, textUid.Text, textPwd.Text);
        }

        private void btn_Conn_Click(object sender, EventArgs e)
        {
            m_Database.Connect();
        }

        private void btn_Disconn_Click(object sender, EventArgs e)
        {
            m_Database.Disconnect();
        }

        private void btn_FormmgmtSelect_Click(object sender, EventArgs e, Task<dynamic> data)
        {
            string query = "SELECT Dept_Code, TemplateCode FROM formmgmt;";
            selectWrite_DB.SelectFormmgmt(query);
        }

        private void btn_ReservedSelect_Click(object sender, EventArgs e)
        {
            selectWrite_DB.SelectReserved();
        }
    }
}
