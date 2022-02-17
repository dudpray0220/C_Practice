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
    }
}
