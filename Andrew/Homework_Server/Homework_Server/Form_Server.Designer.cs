namespace Homework_Server
{
    partial class Form_Server
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxClientIP = new System.Windows.Forms.TextBox();
            this.textBoxClientPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxRcvFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDataSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client IP :";
            // 
            // textBoxClientIP
            // 
            this.textBoxClientIP.Location = new System.Drawing.Point(102, 15);
            this.textBoxClientIP.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxClientIP.Name = "textBoxClientIP";
            this.textBoxClientIP.ReadOnly = true;
            this.textBoxClientIP.Size = new System.Drawing.Size(212, 23);
            this.textBoxClientIP.TabIndex = 1;
            // 
            // textBoxClientPort
            // 
            this.textBoxClientPort.Location = new System.Drawing.Point(420, 15);
            this.textBoxClientPort.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxClientPort.Name = "textBoxClientPort";
            this.textBoxClientPort.ReadOnly = true;
            this.textBoxClientPort.Size = new System.Drawing.Size(52, 23);
            this.textBoxClientPort.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Client Port :";
            // 
            // textBoxRcvFileName
            // 
            this.textBoxRcvFileName.Location = new System.Drawing.Point(102, 59);
            this.textBoxRcvFileName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxRcvFileName.Name = "textBoxRcvFileName";
            this.textBoxRcvFileName.ReadOnly = true;
            this.textBoxRcvFileName.Size = new System.Drawing.Size(370, 23);
            this.textBoxRcvFileName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "File Name :";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(260, 97);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(4);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(212, 23);
            this.txtStatus.TabIndex = 7;
            this.txtStatus.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 101);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Connection Status:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtDataSize
            // 
            this.txtDataSize.Location = new System.Drawing.Point(102, 97);
            this.txtDataSize.Margin = new System.Windows.Forms.Padding(4);
            this.txtDataSize.Name = "txtDataSize";
            this.txtDataSize.ReadOnly = true;
            this.txtDataSize.Size = new System.Drawing.Size(30, 23);
            this.txtDataSize.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 101);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Data Size :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Form_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 150);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDataSize);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxRcvFileName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxClientPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxClientIP);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_Server";
            this.Text = "Form_Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Server_FormClosing);
            this.Load += new System.EventHandler(this.Form_Server_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxClientIP;
        private System.Windows.Forms.TextBox textBoxClientPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxRcvFileName;
        private System.Windows.Forms.Label label3;
        private TextBox txtStatus;
        private Label label4;
        private TextBox txtDataSize;
        private Label label5;
    }
}
