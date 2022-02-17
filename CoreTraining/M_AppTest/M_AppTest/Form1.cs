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

namespace M_AppTest
{
    public partial class Form1 : Form
    {
        Database m_Database = new Database();

        public Form1()
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

        private void Btn_Insert_Click(object sender, EventArgs e)
        {
            List<string> queryList = new List<string>();
            queryList.Add(string.Format(@"Insert into reservedsenddata (JEONSONG_NO, SUSINJA_NM, TemplateCode, BALSONG_DT) values ('{0}', '{1}', '{2}', '{3}');", textNumber.Text, textName.Text, textTemplate.Text, textDatetime.Text));
            queryList.Add("INSERT INTO rsinfotable (RSLinkCode) VALUES (LAST_INSERT_ID());");
            m_Database.ExcuteTransaction(queryList.ToArray());
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string sql_Delete = "DELETE FROM rsinfotable; DELETE FROM reservedsenddata; ALTER TABLE reservedsenddata AUTO_INCREMENT = 1; ALTER TABLE rsinfotable AUTO_INCREMENT = 1; ";
            m_Database.ExcuteNonQuery(sql_Delete);
        }

        private void toolStripFileWrite_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();   // 모달로 새 창 띄움
        }
    }
}
