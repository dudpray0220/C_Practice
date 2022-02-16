namespace M_AppTest
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_FormmgmtSelect = new System.Windows.Forms.Button();
            this.btn_Disconn = new System.Windows.Forms.Button();
            this.btn_Conn = new System.Windows.Forms.Button();
            this.btn_Init = new System.Windows.Forms.Button();
            this.textPwd = new System.Windows.Forms.TextBox();
            this.textUid = new System.Windows.Forms.TextBox();
            this.textPort = new System.Windows.Forms.TextBox();
            this.textDBName = new System.Windows.Forms.TextBox();
            this.textIP = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btn_ReservedSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_FormmgmtSelect
            // 
            this.btn_FormmgmtSelect.Location = new System.Drawing.Point(602, 199);
            this.btn_FormmgmtSelect.Name = "btn_FormmgmtSelect";
            this.btn_FormmgmtSelect.Size = new System.Drawing.Size(167, 23);
            this.btn_FormmgmtSelect.TabIndex = 0;
            this.btn_FormmgmtSelect.Text = "서식관리 테이블 조회";
            this.btn_FormmgmtSelect.UseVisualStyleBackColor = true;
            // 
            // btn_Disconn
            // 
            this.btn_Disconn.Location = new System.Drawing.Point(686, 106);
            this.btn_Disconn.Name = "btn_Disconn";
            this.btn_Disconn.Size = new System.Drawing.Size(83, 24);
            this.btn_Disconn.TabIndex = 15;
            this.btn_Disconn.Text = "Disconnect";
            this.btn_Disconn.UseVisualStyleBackColor = true;
            // 
            // btn_Conn
            // 
            this.btn_Conn.Location = new System.Drawing.Point(686, 76);
            this.btn_Conn.Name = "btn_Conn";
            this.btn_Conn.Size = new System.Drawing.Size(83, 24);
            this.btn_Conn.TabIndex = 16;
            this.btn_Conn.Text = "Connect";
            this.btn_Conn.UseVisualStyleBackColor = true;
            // 
            // btn_Init
            // 
            this.btn_Init.Location = new System.Drawing.Point(691, 46);
            this.btn_Init.Name = "btn_Init";
            this.btn_Init.Size = new System.Drawing.Size(73, 24);
            this.btn_Init.TabIndex = 17;
            this.btn_Init.Text = "Init";
            this.btn_Init.UseVisualStyleBackColor = true;
            this.btn_Init.Click += new System.EventHandler(this.btn_Init_Click);
            // 
            // textPwd
            // 
            this.textPwd.Location = new System.Drawing.Point(565, 78);
            this.textPwd.Name = "textPwd";
            this.textPwd.Size = new System.Drawing.Size(82, 23);
            this.textPwd.TabIndex = 10;
            this.textPwd.Text = "1234qwer";
            this.textPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textUid
            // 
            this.textUid.Location = new System.Drawing.Point(462, 78);
            this.textUid.Name = "textUid";
            this.textUid.Size = new System.Drawing.Size(82, 23);
            this.textUid.TabIndex = 11;
            this.textUid.Text = "root";
            this.textUid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(358, 78);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(82, 23);
            this.textPort.TabIndex = 12;
            this.textPort.Text = "3306";
            this.textPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textDBName
            // 
            this.textDBName.Location = new System.Drawing.Point(220, 78);
            this.textDBName.Name = "textDBName";
            this.textDBName.Size = new System.Drawing.Size(114, 23);
            this.textDBName.TabIndex = 13;
            this.textDBName.Text = "mstation";
            this.textDBName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textIP
            // 
            this.textIP.Location = new System.Drawing.Point(74, 78);
            this.textIP.Name = "textIP";
            this.textIP.Size = new System.Drawing.Size(123, 23);
            this.textIP.TabIndex = 14;
            this.textIP.Text = "172.16.10.109";
            this.textIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(590, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "Pwd";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(493, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "Id";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(385, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "포트";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(254, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "DB이름";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(24, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "DB";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(115, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "서버 IP";
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(39, 142);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(295, 270);
            this.listView1.TabIndex = 18;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btn_ReservedSelect
            // 
            this.btn_ReservedSelect.Location = new System.Drawing.Point(598, 250);
            this.btn_ReservedSelect.Name = "btn_ReservedSelect";
            this.btn_ReservedSelect.Size = new System.Drawing.Size(171, 23);
            this.btn_ReservedSelect.TabIndex = 19;
            this.btn_ReservedSelect.Text = "발송연계 테이블 조회";
            this.btn_ReservedSelect.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_ReservedSelect);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btn_Disconn);
            this.Controls.Add(this.btn_Conn);
            this.Controls.Add(this.btn_Init);
            this.Controls.Add(this.textPwd);
            this.Controls.Add(this.textUid);
            this.Controls.Add(this.textPort);
            this.Controls.Add(this.textDBName);
            this.Controls.Add(this.textIP);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_FormmgmtSelect);
            this.Name = "Form2";
            this.Text = "파일 쓰기 Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_FormmgmtSelect;
        private System.Windows.Forms.Button btn_Disconn;
        private System.Windows.Forms.Button btn_Conn;
        private System.Windows.Forms.Button btn_Init;
        protected System.Windows.Forms.TextBox textPwd;
        protected System.Windows.Forms.TextBox textUid;
        protected System.Windows.Forms.TextBox textPort;
        protected System.Windows.Forms.TextBox textDBName;
        protected System.Windows.Forms.TextBox textIP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btn_ReservedSelect;
    }
}