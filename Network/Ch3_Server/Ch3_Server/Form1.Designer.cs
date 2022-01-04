
namespace Ch3_Server
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.textBoxClient = new System.Windows.Forms.TextBox();
            this.startConBtn = new System.Windows.Forms.Button();
            this.startNetworkBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "서버 ip :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "접속자 ip :";
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(101, 11);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(184, 23);
            this.textBoxServer.TabIndex = 1;
            // 
            // textBoxClient
            // 
            this.textBoxClient.Location = new System.Drawing.Point(101, 45);
            this.textBoxClient.Name = "textBoxClient";
            this.textBoxClient.Size = new System.Drawing.Size(184, 23);
            this.textBoxClient.TabIndex = 1;
            // 
            // startConBtn
            // 
            this.startConBtn.Location = new System.Drawing.Point(317, 12);
            this.startConBtn.Name = "startConBtn";
            this.startConBtn.Size = new System.Drawing.Size(76, 21);
            this.startConBtn.TabIndex = 2;
            this.startConBtn.Text = "접속 시작";
            this.startConBtn.UseVisualStyleBackColor = true;
            this.startConBtn.Click += new System.EventHandler(this.startConBtn_Click);
            // 
            // startNetworkBtn
            // 
            this.startNetworkBtn.Location = new System.Drawing.Point(87, 92);
            this.startNetworkBtn.Name = "startNetworkBtn";
            this.startNetworkBtn.Size = new System.Drawing.Size(235, 26);
            this.startNetworkBtn.TabIndex = 3;
            this.startNetworkBtn.Text = "송수신 시작";
            this.startNetworkBtn.UseVisualStyleBackColor = true;
            this.startNetworkBtn.Click += new System.EventHandler(this.startNetworkBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 130);
            this.Controls.Add(this.startNetworkBtn);
            this.Controls.Add(this.startConBtn);
            this.Controls.Add(this.textBoxClient);
            this.Controls.Add(this.textBoxServer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Simple Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.TextBox textBoxClient;
        private System.Windows.Forms.Button startConBtn;
        private System.Windows.Forms.Button startNetworkBtn;
    }
}

