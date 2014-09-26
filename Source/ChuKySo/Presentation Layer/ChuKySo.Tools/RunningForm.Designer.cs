namespace ChuKySo.Tools
{
    partial class RunningForm
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
            this.txtLog = new System.Windows.Forms.TextBox();
            this.cboCompanies = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstArea = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstMajor = new System.Windows.Forms.ListBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLog.Location = new System.Drawing.Point(297, 12);
            this.txtLog.MaxLength = 327670000;
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(301, 376);
            this.txtLog.TabIndex = 0;
            // 
            // cboCompanies
            // 
            this.cboCompanies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompanies.FormattingEnabled = true;
            this.cboCompanies.Location = new System.Drawing.Point(77, 12);
            this.cboCompanies.Name = "cboCompanies";
            this.cboCompanies.Size = new System.Drawing.Size(214, 21);
            this.cboCompanies.TabIndex = 1;
            this.cboCompanies.SelectedIndexChanged += new System.EventHandler(this.cboCompanies_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn trang";
            // 
            // lstArea
            // 
            this.lstArea.FormattingEnabled = true;
            this.lstArea.Location = new System.Drawing.Point(10, 22);
            this.lstArea.MultiColumn = true;
            this.lstArea.Name = "lstArea";
            this.lstArea.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstArea.Size = new System.Drawing.Size(279, 134);
            this.lstArea.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Chọn khu vực";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Chọn ngành";
            // 
            // lstMajor
            // 
            this.lstMajor.FormattingEnabled = true;
            this.lstMajor.Location = new System.Drawing.Point(10, 181);
            this.lstMajor.Name = "lstMajor";
            this.lstMajor.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstMajor.Size = new System.Drawing.Size(279, 134);
            this.lstMajor.TabIndex = 5;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(209, 321);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(80, 23);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "Kết thúc";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(10, 321);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(81, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Bắt đầu";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnStop);
            this.pnlMain.Controls.Add(this.lstArea);
            this.pnlMain.Controls.Add(this.btnStart);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.lstMajor);
            this.pnlMain.Location = new System.Drawing.Point(2, 39);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(296, 349);
            this.pnlMain.TabIndex = 9;
            // 
            // RunningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 400);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboCompanies);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RunningForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RunningForm";
            this.Load += new System.EventHandler(this.RunningForm_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ComboBox cboCompanies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstArea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstMajor;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel pnlMain;
    }
}