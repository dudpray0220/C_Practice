namespace M_AppTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripFileWrite = new System.Windows.Forms.ToolStripLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textNumber = new System.Windows.Forms.TextBox();
            this.textTemplate = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Btn_Insert = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textIP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textDBName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textPort = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textUid = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textPwd = new System.Windows.Forms.TextBox();
            this.btn_Init = new System.Windows.Forms.Button();
            this.btn_Conn = new System.Windows.Forms.Button();
            this.btn_Disconn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textDatetime = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripFileWrite});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(805, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "발송테스트";
            // 
            // toolStripFileWrite
            // 
            this.toolStripFileWrite.Name = "toolStripFileWrite";
            this.toolStripFileWrite.Size = new System.Drawing.Size(57, 22);
            this.toolStripFileWrite.Text = "File Write";
            this.toolStripFileWrite.Click += new System.EventHandler(this.toolStripFileWrite_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "전송 넘버";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "서식 코드";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "이름";
            // 
            // textNumber
            // 
            this.textNumber.Location = new System.Drawing.Point(53, 239);
            this.textNumber.Name = "textNumber";
            this.textNumber.Size = new System.Drawing.Size(82, 23);
            this.textNumber.TabIndex = 2;
            // 
            // textTemplate
            // 
            this.textTemplate.Location = new System.Drawing.Point(292, 239);
            this.textTemplate.Name = "textTemplate";
            this.textTemplate.Size = new System.Drawing.Size(82, 23);
            this.textTemplate.TabIndex = 2;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(171, 239);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(82, 23);
            this.textName.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 383);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(805, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Btn_Insert
            // 
            this.Btn_Insert.Location = new System.Drawing.Point(637, 238);
            this.Btn_Insert.Name = "Btn_Insert";
            this.Btn_Insert.Size = new System.Drawing.Size(132, 23);
            this.Btn_Insert.TabIndex = 3;
            this.Btn_Insert.Text = "MariaDB Insert";
            this.Btn_Insert.UseVisualStyleBackColor = true;
            this.Btn_Insert.Click += new System.EventHandler(this.Btn_Insert_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(115, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "서버 IP";
            // 
            // textIP
            // 
            this.textIP.Location = new System.Drawing.Point(74, 61);
            this.textIP.Name = "textIP";
            this.textIP.Size = new System.Drawing.Size(123, 23);
            this.textIP.TabIndex = 2;
            this.textIP.Text = "172.16.10.109";
            this.textIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(254, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "DB이름";
            // 
            // textDBName
            // 
            this.textDBName.Location = new System.Drawing.Point(220, 61);
            this.textDBName.Name = "textDBName";
            this.textDBName.Size = new System.Drawing.Size(114, 23);
            this.textDBName.TabIndex = 2;
            this.textDBName.Text = "mstation";
            this.textDBName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(385, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "포트";
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(358, 61);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(82, 23);
            this.textPort.TabIndex = 2;
            this.textPort.Text = "3306";
            this.textPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(493, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "Id";
            // 
            // textUid
            // 
            this.textUid.Location = new System.Drawing.Point(462, 61);
            this.textUid.Name = "textUid";
            this.textUid.Size = new System.Drawing.Size(82, 23);
            this.textUid.TabIndex = 2;
            this.textUid.Text = "root";
            this.textUid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(590, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 15);
            this.label9.TabIndex = 1;
            this.label9.Text = "Pwd";
            // 
            // textPwd
            // 
            this.textPwd.Location = new System.Drawing.Point(565, 61);
            this.textPwd.Name = "textPwd";
            this.textPwd.Size = new System.Drawing.Size(82, 23);
            this.textPwd.TabIndex = 2;
            this.textPwd.Text = "1234qwer";
            this.textPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Init
            // 
            this.btn_Init.Location = new System.Drawing.Point(691, 29);
            this.btn_Init.Name = "btn_Init";
            this.btn_Init.Size = new System.Drawing.Size(73, 24);
            this.btn_Init.TabIndex = 3;
            this.btn_Init.Text = "Init";
            this.btn_Init.UseVisualStyleBackColor = true;
            this.btn_Init.Click += new System.EventHandler(this.btn_Init_Click);
            // 
            // btn_Conn
            // 
            this.btn_Conn.Location = new System.Drawing.Point(686, 59);
            this.btn_Conn.Name = "btn_Conn";
            this.btn_Conn.Size = new System.Drawing.Size(83, 24);
            this.btn_Conn.TabIndex = 3;
            this.btn_Conn.Text = "Connect";
            this.btn_Conn.UseVisualStyleBackColor = true;
            this.btn_Conn.Click += new System.EventHandler(this.btn_Conn_Click);
            // 
            // btn_Disconn
            // 
            this.btn_Disconn.Location = new System.Drawing.Point(686, 89);
            this.btn_Disconn.Name = "btn_Disconn";
            this.btn_Disconn.Size = new System.Drawing.Size(83, 24);
            this.btn_Disconn.TabIndex = 3;
            this.btn_Disconn.Text = "Disconnect";
            this.btn_Disconn.UseVisualStyleBackColor = true;
            this.btn_Disconn.Click += new System.EventHandler(this.btn_Disconn_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(24, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "DB";
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(590, 340);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(183, 23);
            this.btn_Delete.TabIndex = 5;
            this.btn_Delete.Text = "MariaDB All Data Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(464, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Datetime";
            // 
            // textDatetime
            // 
            this.textDatetime.Location = new System.Drawing.Point(409, 239);
            this.textDatetime.Name = "textDatetime";
            this.textDatetime.Size = new System.Drawing.Size(159, 23);
            this.textDatetime.TabIndex = 2;
            this.textDatetime.Text = "0000-00-00 00:00:00";
            this.textDatetime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 405);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Btn_Insert);
            this.Controls.Add(this.btn_Disconn);
            this.Controls.Add(this.btn_Conn);
            this.Controls.Add(this.btn_Init);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.textDatetime);
            this.Controls.Add(this.textTemplate);
            this.Controls.Add(this.textPwd);
            this.Controls.Add(this.textUid);
            this.Controls.Add(this.textPort);
            this.Controls.Add(this.textDBName);
            this.Controls.Add(this.textIP);
            this.Controls.Add(this.textNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Table Insert";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripFileWrite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button Btn_Insert;
        protected System.Windows.Forms.TextBox textTemplate;
        protected System.Windows.Forms.TextBox textName;
        protected System.Windows.Forms.TextBox textNumber;
        private System.Windows.Forms.Label label5;
        protected System.Windows.Forms.TextBox textIP;
        private System.Windows.Forms.Label label6;
        protected System.Windows.Forms.TextBox textDBName;
        private System.Windows.Forms.Label label7;
        protected System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.Label label8;
        protected System.Windows.Forms.TextBox textUid;
        private System.Windows.Forms.Label label9;
        protected System.Windows.Forms.TextBox textPwd;
        private System.Windows.Forms.Button btn_Init;
        private System.Windows.Forms.Button btn_Conn;
        private System.Windows.Forms.Button btn_Disconn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox textDatetime;
    }
}
