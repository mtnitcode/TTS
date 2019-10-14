namespace Sbn.Products.TTS.Present
{
    partial class frmSticker
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSticker));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.lblAdd = new System.Windows.Forms.Label();
			this.lblActivity = new System.Windows.Forms.Label();
			this.lblRemove = new System.Windows.Forms.Label();
			this.lblOK = new System.Windows.Forms.Label();
			this.lblProject = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.txtCompleteDesc = new System.Windows.Forms.TextBox();
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
			this.splitContainer1.Panel1.Controls.Add(this.lblAdd);
			this.splitContainer1.Panel1.Controls.Add(this.lblActivity);
			this.splitContainer1.Panel1.Controls.Add(this.lblRemove);
			this.splitContainer1.Panel1.Controls.Add(this.lblOK);
			this.splitContainer1.Panel1.Controls.Add(this.lblProject);
			this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.txtCompleteDesc);
			this.splitContainer1.Panel2.Controls.Add(this.lblTitle);
			this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.splitContainer1.Size = new System.Drawing.Size(188, 183);
			this.splitContainer1.SplitterDistance = 25;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 0;
			// 
			// lblAdd
			// 
			this.lblAdd.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.lblAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblAdd.Image = global::Sbn.Products.TTS.Present.Properties.Resources.bullet_add;
			this.lblAdd.Location = new System.Drawing.Point(64, 1);
			this.lblAdd.Name = "lblAdd";
			this.lblAdd.Size = new System.Drawing.Size(28, 28);
			this.lblAdd.TabIndex = 5;
			this.lblAdd.Click += new System.EventHandler(this.lblAdd_Click);
			// 
			// lblActivity
			// 
			this.lblActivity.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblActivity.Image = global::Sbn.Products.TTS.Present.Properties.Resources.sheduled_task1;
			this.lblActivity.Location = new System.Drawing.Point(42, 1);
			this.lblActivity.Name = "lblActivity";
			this.lblActivity.Size = new System.Drawing.Size(28, 28);
			this.lblActivity.TabIndex = 3;
			this.lblActivity.Click += new System.EventHandler(this.lblActivity_Click);
			// 
			// lblRemove
			// 
			this.lblRemove.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblRemove.Image = global::Sbn.Products.TTS.Present.Properties.Resources.bullet_delete;
			this.lblRemove.Location = new System.Drawing.Point(19, 1);
			this.lblRemove.Name = "lblRemove";
			this.lblRemove.Size = new System.Drawing.Size(28, 28);
			this.lblRemove.TabIndex = 2;
			this.lblRemove.Click += new System.EventHandler(this.label1_Click);
			// 
			// lblOK
			// 
			this.lblOK.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblOK.Image = global::Sbn.Products.TTS.Present.Properties.Resources.accept;
			this.lblOK.Location = new System.Drawing.Point(-2, 0);
			this.lblOK.Name = "lblOK";
			this.lblOK.Size = new System.Drawing.Size(28, 28);
			this.lblOK.TabIndex = 0;
			this.lblOK.Click += new System.EventHandler(this.lblOK_Click);
			// 
			// lblProject
			// 
			this.lblProject.Dock = System.Windows.Forms.DockStyle.Right;
			this.lblProject.Location = new System.Drawing.Point(-105, 0);
			this.lblProject.Name = "lblProject";
			this.lblProject.Size = new System.Drawing.Size(293, 25);
			this.lblProject.TabIndex = 1;
			this.lblProject.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblProject_MouseDown);
			this.lblProject.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblProject_MouseMove);
			this.lblProject.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblProject_MouseUp);
			// 
			// lblTitle
			// 
			this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblTitle.Location = new System.Drawing.Point(0, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(188, 65);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Click += new System.EventHandler(this.label2_Click);
			this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDesc_MouseDown);
			this.lblTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblDesc_MouseMove);
			this.lblTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblDesc_MouseUp);
			// 
			// txtCompleteDesc
			// 
			this.txtCompleteDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
			this.txtCompleteDesc.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtCompleteDesc.Location = new System.Drawing.Point(0, 65);
			this.txtCompleteDesc.Multiline = true;
			this.txtCompleteDesc.Name = "txtCompleteDesc";
			this.txtCompleteDesc.Size = new System.Drawing.Size(188, 92);
			this.txtCompleteDesc.TabIndex = 1;
			// 
			// frmSticker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.ClientSize = new System.Drawing.Size(188, 183);
			this.Controls.Add(this.splitContainer1);
			this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "frmSticker";
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
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.Label lblRemove;
        private System.Windows.Forms.Label lblActivity;
        private System.Windows.Forms.Label lblAdd;
		public System.Windows.Forms.TextBox txtCompleteDesc;
	}
}