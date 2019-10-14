namespace Sbn.Products.TTS.Present
{
    partial class frmReminderMessage
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReminderMessage));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.label1 = new System.Windows.Forms.Label();
			this.lblActivity = new System.Windows.Forms.Label();
			this.lblRemove = new System.Windows.Forms.Label();
			this.lblOK = new System.Windows.Forms.Label();
			this.lblProject = new System.Windows.Forms.Label();
			this.txtCompleteDesc = new System.Windows.Forms.TextBox();
			this.lblDesc = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			this.splitContainer1.Panel1.Controls.Add(this.lblActivity);
			this.splitContainer1.Panel1.Controls.Add(this.lblRemove);
			this.splitContainer1.Panel1.Controls.Add(this.lblOK);
			this.splitContainer1.Panel1.Controls.Add(this.lblProject);
			this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.txtCompleteDesc);
			this.splitContainer1.Panel2.Controls.Add(this.lblDesc);
			this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.splitContainer1.Size = new System.Drawing.Size(188, 183);
			this.splitContainer1.SplitterDistance = 25;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.MediumPurple;
			this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label1.Image = global::Sbn.Products.TTS.Present.Properties.Resources.bullet_add;
			this.label1.Location = new System.Drawing.Point(61, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(28, 28);
			this.label1.TabIndex = 4;
			this.label1.Click += new System.EventHandler(this.label1_Click_1);
			// 
			// lblActivity
			// 
			this.lblActivity.BackColor = System.Drawing.Color.MediumPurple;
			this.lblActivity.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblActivity.Image = global::Sbn.Products.TTS.Present.Properties.Resources.sheduled_task1;
			this.lblActivity.Location = new System.Drawing.Point(40, 1);
			this.lblActivity.Name = "lblActivity";
			this.lblActivity.Size = new System.Drawing.Size(28, 28);
			this.lblActivity.TabIndex = 3;
			this.lblActivity.Click += new System.EventHandler(this.lblActivity_Click);
			// 
			// lblRemove
			// 
			this.lblRemove.BackColor = System.Drawing.Color.MediumPurple;
			this.lblRemove.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblRemove.Image = global::Sbn.Products.TTS.Present.Properties.Resources.bullet_delete;
			this.lblRemove.Location = new System.Drawing.Point(18, 1);
			this.lblRemove.Name = "lblRemove";
			this.lblRemove.Size = new System.Drawing.Size(28, 28);
			this.lblRemove.TabIndex = 2;
			this.lblRemove.Visible = false;
			this.lblRemove.Click += new System.EventHandler(this.label1_Click);
			// 
			// lblOK
			// 
			this.lblOK.BackColor = System.Drawing.Color.MediumPurple;
			this.lblOK.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblOK.Image = global::Sbn.Products.TTS.Present.Properties.Resources.accept;
			this.lblOK.Location = new System.Drawing.Point(-3, 0);
			this.lblOK.Name = "lblOK";
			this.lblOK.Size = new System.Drawing.Size(28, 28);
			this.lblOK.TabIndex = 0;
			this.lblOK.Click += new System.EventHandler(this.lblOK_Click);
			// 
			// lblProject
			// 
			this.lblProject.BackColor = System.Drawing.Color.MediumPurple;
			this.lblProject.Dock = System.Windows.Forms.DockStyle.Right;
			this.lblProject.Location = new System.Drawing.Point(-105, 0);
			this.lblProject.Name = "lblProject";
			this.lblProject.Size = new System.Drawing.Size(293, 25);
			this.lblProject.TabIndex = 1;
			this.lblProject.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblProject_MouseDown);
			this.lblProject.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblProject_MouseMove);
			this.lblProject.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblProject_MouseUp);
			// 
			// txtCompleteDesc
			// 
			this.txtCompleteDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
			this.txtCompleteDesc.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtCompleteDesc.Location = new System.Drawing.Point(0, 60);
			this.txtCompleteDesc.Multiline = true;
			this.txtCompleteDesc.Name = "txtCompleteDesc";
			this.txtCompleteDesc.Size = new System.Drawing.Size(188, 97);
			this.txtCompleteDesc.TabIndex = 2;
			// 
			// lblDesc
			// 
			this.lblDesc.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblDesc.Location = new System.Drawing.Point(0, 0);
			this.lblDesc.Name = "lblDesc";
			this.lblDesc.Size = new System.Drawing.Size(188, 60);
			this.lblDesc.TabIndex = 0;
			this.lblDesc.Click += new System.EventHandler(this.label2_Click);
			this.lblDesc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDesc_MouseDown);
			this.lblDesc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblDesc_MouseMove);
			this.lblDesc.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblDesc_MouseUp);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// frmReminderMessage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ClientSize = new System.Drawing.Size(188, 183);
			this.Controls.Add(this.splitContainer1);
			this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "frmReminderMessage";
			this.Opacity = 0.8D;
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.Text = "frmSticker";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmSticker_MouseDown);
			this.MouseLeave += new System.EventHandler(this.frmSticker_MouseLeave);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmSticker_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmSticker_MouseUp);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblOK;
        public System.Windows.Forms.Label lblDesc;
        public System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.Label lblRemove;
        private System.Windows.Forms.Label lblActivity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
		public System.Windows.Forms.TextBox txtCompleteDesc;
	}
}