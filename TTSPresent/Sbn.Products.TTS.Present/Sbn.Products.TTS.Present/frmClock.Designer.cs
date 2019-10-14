namespace Sbn.Products.TTS.Present
{
    partial class frmClock
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblShowActivity = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.analogClock3 = new AnalogClockControl.AnalogClock();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.White;
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.progressBar1.Location = new System.Drawing.Point(2, 100);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(96, 26);
            this.progressBar1.Step = 5;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Value = 44;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            this.progressBar1.MouseLeave += new System.EventHandler(this.progressBar1_MouseLeave);
            this.progressBar1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.progressBar1_MouseMove);
            // 
            // lblShowActivity
            // 
            this.lblShowActivity.BackColor = System.Drawing.Color.White;
            this.lblShowActivity.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblShowActivity.Location = new System.Drawing.Point(1, 112);
            this.lblShowActivity.Name = "lblShowActivity";
            this.lblShowActivity.Size = new System.Drawing.Size(97, 37);
            this.lblShowActivity.TabIndex = 36;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Sbn.Products.TTS.Present.Properties.Resources.Calendar;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(87, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(11, 11);
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // analogClock3
            // 
            this.analogClock3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.analogClock3.BackColor = System.Drawing.Color.Transparent;
            this.analogClock3.BackgroundImage = global::Sbn.Products.TTS.Present.Properties.Resources.clock31;
            this.analogClock3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.analogClock3.Cursor = System.Windows.Forms.Cursors.Default;
            this.analogClock3.DayName = "";
            this.analogClock3.Draw1MinuteTicks = false;
            this.analogClock3.Draw5MinuteTicks = true;
            this.analogClock3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.analogClock3.HourHandColor = System.Drawing.Color.MediumBlue;
            this.analogClock3.Location = new System.Drawing.Point(3, 3);
            this.analogClock3.Margin = new System.Windows.Forms.Padding(0);
            this.analogClock3.MinuteHandColor = System.Drawing.Color.MediumBlue;
            this.analogClock3.MonthName = "";
            this.analogClock3.Name = "analogClock3";
            this.analogClock3.SecondHandColor = System.Drawing.Color.DarkRed;
            this.analogClock3.Size = new System.Drawing.Size(96, 96);
            this.analogClock3.TabIndex = 3;
            this.analogClock3.TabStop = false;
            this.analogClock3.TicksColor = System.Drawing.Color.Black;
            this.analogClock3.Load += new System.EventHandler(this.analogClock3_Load);
            this.analogClock3.Click += new System.EventHandler(this.analogClock3_Click);
            this.analogClock3.DoubleClick += new System.EventHandler(this.analogClock3_DoubleClick);
            this.analogClock3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.analogClock3_MouseDown);
            this.analogClock3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.analogClock3_MouseMove);
            this.analogClock3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.analogClock3_MouseUp);
            // 
            // frmClock
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(116, 118);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblShowActivity);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.analogClock3);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmClock";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClock_FormClosing);
            this.Load += new System.EventHandler(this.frmClock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ProgressBar progressBar1;
        public AnalogClockControl.AnalogClock analogClock3;
        public System.Windows.Forms.Label lblShowActivity;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}