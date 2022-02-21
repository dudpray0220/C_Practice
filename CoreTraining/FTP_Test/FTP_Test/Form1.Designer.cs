namespace FTP_Test
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
            this.label1 = new System.Windows.Forms.Label();
            this.textIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textPWD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_FileSearch = new System.Windows.Forms.Button();
            this.listboxFileNames = new System.Windows.Forms.ListBox();
            this.btn_FileSend = new System.Windows.Forms.Button();
            this.textFileName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // textIP
            // 
            this.textIP.Location = new System.Drawing.Point(56, 33);
            this.textIP.Name = "textIP";
            this.textIP.Size = new System.Drawing.Size(204, 23);
            this.textIP.TabIndex = 1;
            this.textIP.Text = "172.16.10.109";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Port";
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(328, 33);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(100, 23);
            this.textPort.TabIndex = 1;
            this.textPort.Text = "21";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(468, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "User";
            // 
            // textUser
            // 
            this.textUser.Location = new System.Drawing.Point(504, 33);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(100, 23);
            this.textUser.TabIndex = 1;
            this.textUser.Text = "tilon";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(640, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Pwd";
            // 
            // textPWD
            // 
            this.textPWD.Location = new System.Drawing.Point(676, 33);
            this.textPWD.Name = "textPWD";
            this.textPWD.Size = new System.Drawing.Size(100, 23);
            this.textPWD.TabIndex = 1;
            this.textPWD.Text = "1234qwer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "File";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "텍스트 파일|*.txt|모든 파일|*.*";
            this.openFileDialog1.InitialDirectory = "C:\\Users\\byh\\Desktop";
            this.openFileDialog1.Title = "보낼 파일 선택!";
            // 
            // btn_FileSearch
            // 
            this.btn_FileSearch.Location = new System.Drawing.Point(489, 104);
            this.btn_FileSearch.Name = "btn_FileSearch";
            this.btn_FileSearch.Size = new System.Drawing.Size(75, 23);
            this.btn_FileSearch.TabIndex = 2;
            this.btn_FileSearch.Text = "파일 찾기";
            this.btn_FileSearch.UseVisualStyleBackColor = true;
            this.btn_FileSearch.Click += new System.EventHandler(this.btn_FileSearch_Click);
            // 
            // listboxFileNames
            // 
            this.listboxFileNames.FormattingEnabled = true;
            this.listboxFileNames.ItemHeight = 15;
            this.listboxFileNames.Location = new System.Drawing.Point(56, 107);
            this.listboxFileNames.Name = "listboxFileNames";
            this.listboxFileNames.Size = new System.Drawing.Size(414, 244);
            this.listboxFileNames.TabIndex = 3;
            // 
            // btn_FileSend
            // 
            this.btn_FileSend.Location = new System.Drawing.Point(585, 103);
            this.btn_FileSend.Name = "btn_FileSend";
            this.btn_FileSend.Size = new System.Drawing.Size(75, 23);
            this.btn_FileSend.TabIndex = 4;
            this.btn_FileSend.Text = "파일 전송";
            this.btn_FileSend.UseVisualStyleBackColor = true;
            this.btn_FileSend.Click += new System.EventHandler(this.btn_FileSend_Click);
            // 
            // textFileName
            // 
            this.textFileName.Location = new System.Drawing.Point(56, 378);
            this.textFileName.Name = "textFileName";
            this.textFileName.Size = new System.Drawing.Size(662, 23);
            this.textFileName.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 378);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "File";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 422);
            this.Controls.Add(this.textFileName);
            this.Controls.Add(this.btn_FileSend);
            this.Controls.Add(this.listboxFileNames);
            this.Controls.Add(this.btn_FileSearch);
            this.Controls.Add(this.textPWD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textIP);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Mstation_FTP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textPWD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_FileSearch;
        private System.Windows.Forms.ListBox listboxFileNames;
        private System.Windows.Forms.Button btn_FileSend;
        private System.Windows.Forms.TextBox textFileName;
        private System.Windows.Forms.Label label6;
    }
}
