﻿namespace M_AppTest
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_FormmgmtSelect
            // 
            this.btn_FormmgmtSelect.Location = new System.Drawing.Point(571, 37);
            this.btn_FormmgmtSelect.Name = "btn_FormmgmtSelect";
            this.btn_FormmgmtSelect.Size = new System.Drawing.Size(217, 23);
            this.btn_FormmgmtSelect.TabIndex = 0;
            this.btn_FormmgmtSelect.Text = "서식, 발송연계 조회 후 File Write";
            this.btn_FormmgmtSelect.UseVisualStyleBackColor = true;
            this.btn_FormmgmtSelect.Click += new System.EventHandler(this.btn_FormmgmtSelect_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 145);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(502, 293);
            this.dataGridView1.TabIndex = 20;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_FormmgmtSelect);
            this.Name = "Form2";
            this.Text = "파일 쓰기 Test";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_FormmgmtSelect;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}