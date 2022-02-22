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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_ReservedUpdate = new System.Windows.Forms.Button();
            this.btn_ReservedReset = new System.Windows.Forms.Button();
            this.btn_FileMove = new System.Windows.Forms.Button();
            this.btn_FileMoveReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_FormmgmtSelect
            // 
            this.btn_FormmgmtSelect.Location = new System.Drawing.Point(571, 37);
            this.btn_FormmgmtSelect.Name = "btn_FormmgmtSelect";
            this.btn_FormmgmtSelect.Size = new System.Drawing.Size(217, 23);
            this.btn_FormmgmtSelect.TabIndex = 0;
            this.btn_FormmgmtSelect.Text = "File Write and Table UPDATE";
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
            // btn_ReservedUpdate
            // 
            this.btn_ReservedUpdate.Location = new System.Drawing.Point(571, 96);
            this.btn_ReservedUpdate.Name = "btn_ReservedUpdate";
            this.btn_ReservedUpdate.Size = new System.Drawing.Size(217, 23);
            this.btn_ReservedUpdate.TabIndex = 21;
            this.btn_ReservedUpdate.Text = "발송연계 테이블 업데이트";
            this.btn_ReservedUpdate.UseVisualStyleBackColor = true;
            this.btn_ReservedUpdate.Click += new System.EventHandler(this.btn_ReservedUpdate_Click);
            // 
            // btn_ReservedReset
            // 
            this.btn_ReservedReset.Location = new System.Drawing.Point(572, 403);
            this.btn_ReservedReset.Name = "btn_ReservedReset";
            this.btn_ReservedReset.Size = new System.Drawing.Size(216, 22);
            this.btn_ReservedReset.TabIndex = 22;
            this.btn_ReservedReset.Text = "발송연계 테이블 리셋";
            this.btn_ReservedReset.UseVisualStyleBackColor = true;
            this.btn_ReservedReset.Click += new System.EventHandler(this.btn_ReservedReset_Click);
            // 
            // btn_FileMove
            // 
            this.btn_FileMove.Location = new System.Drawing.Point(624, 162);
            this.btn_FileMove.Name = "btn_FileMove";
            this.btn_FileMove.Size = new System.Drawing.Size(109, 23);
            this.btn_FileMove.TabIndex = 23;
            this.btn_FileMove.Text = "파일 이동";
            this.btn_FileMove.UseVisualStyleBackColor = true;
            this.btn_FileMove.Click += new System.EventHandler(this.btn_FileMove_Click);
            // 
            // btn_FileMoveReset
            // 
            this.btn_FileMoveReset.Location = new System.Drawing.Point(624, 215);
            this.btn_FileMoveReset.Name = "btn_FileMoveReset";
            this.btn_FileMoveReset.Size = new System.Drawing.Size(109, 23);
            this.btn_FileMoveReset.TabIndex = 24;
            this.btn_FileMoveReset.Text = "파일 이동 리셋";
            this.btn_FileMoveReset.UseVisualStyleBackColor = true;
            this.btn_FileMoveReset.Click += new System.EventHandler(this.btn_FileMoveReset_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 450);
            this.Controls.Add(this.btn_FileMoveReset);
            this.Controls.Add(this.btn_FileMove);
            this.Controls.Add(this.btn_ReservedReset);
            this.Controls.Add(this.btn_ReservedUpdate);
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
        private System.Windows.Forms.Button btn_ReservedUpdate;
        private System.Windows.Forms.Button btn_ReservedReset;
        private System.Windows.Forms.Button btn_FileMove;
        private System.Windows.Forms.Button btn_FileMoveReset;
    }
}