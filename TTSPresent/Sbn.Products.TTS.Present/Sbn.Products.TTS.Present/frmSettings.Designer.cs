namespace Sbn.Products.TTS.Present
{
    partial class frmSettings
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
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtFrequency = new System.Windows.Forms.TextBox();
			this.txtDuration = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.txtAbsent = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.chSendActivityToSrv = new System.Windows.Forms.CheckBox();
			this.txtIP = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.txtChatPort = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox1.Location = new System.Drawing.Point(382, 17);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.checkBox1.Size = new System.Drawing.Size(109, 20);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "صدای هشدار :";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(308, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "فرکانس :";
			// 
			// txtFrequency
			// 
			this.txtFrequency.Location = new System.Drawing.Point(210, 15);
			this.txtFrequency.Name = "txtFrequency";
			this.txtFrequency.Size = new System.Drawing.Size(92, 23);
			this.txtFrequency.TabIndex = 1;
			this.txtFrequency.Text = "2000";
			// 
			// txtDuration
			// 
			this.txtDuration.Location = new System.Drawing.Point(40, 15);
			this.txtDuration.Name = "txtDuration";
			this.txtDuration.Size = new System.Drawing.Size(91, 23);
			this.txtDuration.TabIndex = 2;
			this.txtDuration.Text = "500";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(137, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "مدت :";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 273);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 10;
			this.button1.Text = "تایید";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtAddress
			// 
			this.txtAddress.Location = new System.Drawing.Point(40, 112);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtAddress.Size = new System.Drawing.Size(447, 23);
			this.txtAddress.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(339, 93);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(158, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "محل ذخیره سازی فعالیتها :";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(2, 111);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(32, 24);
			this.button2.TabIndex = 6;
			this.button2.Text = "...";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// txtAbsent
			// 
			this.txtAbsent.Location = new System.Drawing.Point(40, 160);
			this.txtAbsent.Name = "txtAbsent";
			this.txtAbsent.Size = new System.Drawing.Size(447, 23);
			this.txtAbsent.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(210, 141);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(279, 16);
			this.label4.TabIndex = 9;
			this.label4.Text = "ساعات عدم حضور : (12:00-13:00;17:00-18:00)";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(40, 186);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(412, 23);
			this.txtName.TabIndex = 8;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(451, 189);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(33, 16);
			this.label5.TabIndex = 11;
			this.label5.Text = "نام :";
			// 
			// chSendActivityToSrv
			// 
			this.chSendActivityToSrv.AutoSize = true;
			this.chSendActivityToSrv.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chSendActivityToSrv.Location = new System.Drawing.Point(239, 58);
			this.chSendActivityToSrv.Name = "chSendActivityToSrv";
			this.chSendActivityToSrv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.chSendActivityToSrv.Size = new System.Drawing.Size(258, 20);
			this.chSendActivityToSrv.TabIndex = 3;
			this.chSendActivityToSrv.Text = "گزارش فعالیتهای انجام شده به مدیر واحد :";
			this.chSendActivityToSrv.UseVisualStyleBackColor = true;
			// 
			// txtIP
			// 
			this.txtIP.Location = new System.Drawing.Point(40, 54);
			this.txtIP.Name = "txtIP";
			this.txtIP.Size = new System.Drawing.Size(133, 23);
			this.txtIP.TabIndex = 4;
			this.txtIP.Text = "192.168.250.*";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(179, 58);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 16);
			this.label6.TabIndex = 15;
			this.label6.Text = "آدرس IP :";
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox2.Checked = true;
			this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox2.Enabled = false;
			this.checkBox2.Location = new System.Drawing.Point(264, 215);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.checkBox2.Size = new System.Drawing.Size(222, 20);
			this.checkBox2.TabIndex = 9;
			this.checkBox2.Text = "ذخیره سازی آخرین وضعیت ساعت :";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// txtChatPort
			// 
			this.txtChatPort.Location = new System.Drawing.Point(308, 241);
			this.txtChatPort.Name = "txtChatPort";
			this.txtChatPort.Size = new System.Drawing.Size(92, 23);
			this.txtChatPort.TabIndex = 16;
			this.txtChatPort.Text = "1300";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(406, 244);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(78, 16);
			this.label7.TabIndex = 17;
			this.label7.Text = "پورت گفتگو :";
			// 
			// frmSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(509, 308);
			this.Controls.Add(this.txtChatPort);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtIP);
			this.Controls.Add(this.chSendActivityToSrv);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtAbsent);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.txtAddress);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtDuration);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtFrequency);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.checkBox1);
			this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.Name = "frmSettings";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "تنظیمات";
			this.Load += new System.EventHandler(this.frmSettings_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFrequency;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtAbsent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chSendActivityToSrv;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.TextBox txtChatPort;
		private System.Windows.Forms.Label label7;
	}
}