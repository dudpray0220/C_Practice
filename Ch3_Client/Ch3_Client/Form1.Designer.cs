
namespace Ch3_Client
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxServerIp = new System.Windows.Forms.TextBox();
            this.textBoxInt = new System.Windows.Forms.TextBox();
            this.textBoxFloat = new System.Windows.Forms.TextBox();
            this.textBoxString = new System.Windows.Forms.TextBox();
            this.BtnCon = new System.Windows.Forms.Button();
            this.BtnNetworking = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "접속할 서버 주소 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "int형 데이터 : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "float형 데이터 : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "문자열 데이터 : ";
            // 
            // textBoxServerIp
            // 
            this.textBoxServerIp.Location = new System.Drawing.Point(140, 17);
            this.textBoxServerIp.Name = "textBoxServerIp";
            this.textBoxServerIp.Size = new System.Drawing.Size(172, 23);
            this.textBoxServerIp.TabIndex = 1;
            // 
            // textBoxInt
            // 
            this.textBoxInt.Location = new System.Drawing.Point(125, 66);
            this.textBoxInt.Name = "textBoxInt";
            this.textBoxInt.Size = new System.Drawing.Size(172, 23);
            this.textBoxInt.TabIndex = 1;
            // 
            // textBoxFloat
            // 
            this.textBoxFloat.Location = new System.Drawing.Point(125, 107);
            this.textBoxFloat.Name = "textBoxFloat";
            this.textBoxFloat.Size = new System.Drawing.Size(172, 23);
            this.textBoxFloat.TabIndex = 1;
            // 
            // textBoxString
            // 
            this.textBoxString.Location = new System.Drawing.Point(125, 146);
            this.textBoxString.Name = "textBoxString";
            this.textBoxString.Size = new System.Drawing.Size(172, 23);
            this.textBoxString.TabIndex = 1;
            // 
            // BtnCon
            // 
            this.BtnCon.Location = new System.Drawing.Point(350, 18);
            this.BtnCon.Name = "BtnCon";
            this.BtnCon.Size = new System.Drawing.Size(67, 21);
            this.BtnCon.TabIndex = 2;
            this.BtnCon.Text = "접속";
            this.BtnCon.UseVisualStyleBackColor = true;
            this.BtnCon.Click += new System.EventHandler(this.BtnCon_Click);
            // 
            // BtnNetworking
            // 
            this.BtnNetworking.Location = new System.Drawing.Point(328, 143);
            this.BtnNetworking.Name = "BtnNetworking";
            this.BtnNetworking.Size = new System.Drawing.Size(89, 26);
            this.BtnNetworking.TabIndex = 2;
            this.BtnNetworking.Text = "전송 및 수신";
            this.BtnNetworking.UseVisualStyleBackColor = true;
            this.BtnNetworking.Click += new System.EventHandler(this.BtnNetworking_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 190);
            this.Controls.Add(this.BtnNetworking);
            this.Controls.Add(this.BtnCon);
            this.Controls.Add(this.textBoxString);
            this.Controls.Add(this.textBoxFloat);
            this.Controls.Add(this.textBoxInt);
            this.Controls.Add(this.textBoxServerIp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Simple Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxServerIp;
        private System.Windows.Forms.TextBox textBoxInt;
        private System.Windows.Forms.TextBox textBoxFloat;
        private System.Windows.Forms.TextBox textBoxString;
        private System.Windows.Forms.Button BtnCon;
        private System.Windows.Forms.Button BtnNetworking;
    }
}

