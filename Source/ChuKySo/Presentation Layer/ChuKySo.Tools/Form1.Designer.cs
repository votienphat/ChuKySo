namespace ChuKySo.Tools
{
    partial class frmMain
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
            this.txtLink = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtScrapperLog = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(12, 12);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(476, 20);
            this.txtLink.TabIndex = 0;
            this.txtLink.Text = "http://bocaodn.tienphong.vn/?m=public&a=bocao&catid=1167&keyword=&limit=10";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(494, 10);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(81, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtScrapperLog
            // 
            this.txtScrapperLog.Location = new System.Drawing.Point(12, 38);
            this.txtScrapperLog.Multiline = true;
            this.txtScrapperLog.Name = "txtScrapperLog";
            this.txtScrapperLog.ReadOnly = true;
            this.txtScrapperLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtScrapperLog.Size = new System.Drawing.Size(649, 306);
            this.txtScrapperLog.TabIndex = 2;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(581, 9);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(80, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 356);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.txtScrapperLog);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtLink);
            this.Name = "frmMain";
            this.Text = "Tool Chữ Ký Số";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtScrapperLog;
        private System.Windows.Forms.Button btnStop;
    }
}

