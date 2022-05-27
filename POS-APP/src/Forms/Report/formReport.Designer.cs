namespace POS_APP {
    partial class formReport {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEmpID = new System.Windows.Forms.Label();
            this.btnSignIn = new System.Windows.Forms.Label();
            this.dataGridReport = new System.Windows.Forms.DataGridView();
            this.comboReportDur = new System.Windows.Forms.ComboBox();
            this.dtPick = new System.Windows.Forms.DateTimePicker();
            this.btnGenReport = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Label();
            this.lbldate = new System.Windows.Forms.Label();
            this.comboReportType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReport)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.comboReportDur);
            this.panel1.Controls.Add(this.comboReportType);
            this.panel1.Controls.Add(this.btnSignIn);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 535);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Report";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.lblEmpName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblEmpID);
            this.panel2.Location = new System.Drawing.Point(-1, 428);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(262, 104);
            this.panel2.TabIndex = 0;
            // 
            // lblEmpName
            // 
            this.lblEmpName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblEmpName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEmpName.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpName.Location = new System.Drawing.Point(75, 58);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(166, 34);
            this.lblEmpName.TabIndex = 2;
            this.lblEmpName.Text = "Teerapon Saisrikaew";
            this.lblEmpName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 34);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 34);
            this.label2.TabIndex = 2;
            this.label2.Text = "ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEmpID
            // 
            this.lblEmpID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblEmpID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEmpID.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpID.Location = new System.Drawing.Point(75, 13);
            this.lblEmpID.Name = "lblEmpID";
            this.lblEmpID.Size = new System.Drawing.Size(166, 34);
            this.lblEmpID.TabIndex = 2;
            this.lblEmpID.Text = "1";
            this.lblEmpID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSignIn.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignIn.Location = new System.Drawing.Point(12, 384);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(224, 34);
            this.btnSignIn.TabIndex = 2;
            this.btnSignIn.Text = "log out";
            this.btnSignIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // dataGridReport
            // 
            this.dataGridReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridReport.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dataGridReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReport.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dataGridReport.Location = new System.Drawing.Point(293, 86);
            this.dataGridReport.Name = "dataGridReport";
            this.dataGridReport.Size = new System.Drawing.Size(685, 455);
            this.dataGridReport.TabIndex = 2;
            // 
            // comboReportDur
            // 
            this.comboReportDur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboReportDur.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboReportDur.FormattingEnabled = true;
            this.comboReportDur.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly",
            "Yearly"});
            this.comboReportDur.Location = new System.Drawing.Point(18, 168);
            this.comboReportDur.Name = "comboReportDur";
            this.comboReportDur.Size = new System.Drawing.Size(236, 36);
            this.comboReportDur.TabIndex = 3;
            this.comboReportDur.SelectedIndexChanged += new System.EventHandler(this.comboReport_SelectedIndexChanged);
            // 
            // dtPick
            // 
            this.dtPick.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPick.Location = new System.Drawing.Point(293, 41);
            this.dtPick.Name = "dtPick";
            this.dtPick.Size = new System.Drawing.Size(236, 39);
            this.dtPick.TabIndex = 4;
            // 
            // btnGenReport
            // 
            this.btnGenReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnGenReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenReport.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenReport.Location = new System.Drawing.Point(547, 41);
            this.btnGenReport.Name = "btnGenReport";
            this.btnGenReport.Size = new System.Drawing.Size(172, 39);
            this.btnGenReport.TabIndex = 2;
            this.btnGenReport.Text = "Show report";
            this.btnGenReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGenReport.Click += new System.EventHandler(this.btnGenReport_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(806, 39);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(172, 39);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export to excel";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldate.Location = new System.Drawing.Point(289, 15);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(130, 23);
            this.lbldate.TabIndex = 2;
            this.lbldate.Text = "month / day / year";
            // 
            // comboReportType
            // 
            this.comboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboReportType.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboReportType.FormattingEnabled = true;
            this.comboReportType.Items.AddRange(new object[] {
            "Net Sale",
            "Net Profit"});
            this.comboReportType.Location = new System.Drawing.Point(16, 92);
            this.comboReportType.Name = "comboReportType";
            this.comboReportType.Size = new System.Drawing.Size(236, 36);
            this.comboReportType.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "Report duration";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "Choose report";
            // 
            // formReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 553);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.dtPick);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnGenReport);
            this.Controls.Add(this.dataGridReport);
            this.Controls.Add(this.panel1);
            this.Name = "formReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.formReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEmpID;
        private System.Windows.Forms.Label btnSignIn;
        private System.Windows.Forms.DataGridView dataGridReport;
        private System.Windows.Forms.ComboBox comboReportDur;
        private System.Windows.Forms.DateTimePicker dtPick;
        private System.Windows.Forms.Label btnGenReport;
        private System.Windows.Forms.Label btnExport;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.ComboBox comboReportType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}