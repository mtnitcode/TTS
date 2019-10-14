namespace Sbn.Products.TTS.Present
{
    partial class frmLeitnerCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLeitnerCard));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblSave = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblAdd = new System.Windows.Forms.Label();
            this.lblOK = new System.Windows.Forms.Label();
            this.lblRemove = new System.Windows.Forms.Label();
            this.txtQ = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtR = new System.Windows.Forms.TextBox();
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
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.splitContainer1.Panel1.Controls.Add(this.lblSave);
            this.splitContainer1.Panel1.Controls.Add(this.lblHeader);
            this.splitContainer1.Panel1.Controls.Add(this.lblAdd);
            this.splitContainer1.Panel1.Controls.Add(this.lblOK);
            this.splitContainer1.Panel1.Controls.Add(this.lblRemove);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtQ);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.txtR);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(235, 204);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblSave
            // 
            this.lblSave.BackColor = System.Drawing.Color.Transparent;
            this.lblSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSave.Image = global::Sbn.Products.TTS.Present.Properties.Resources.save_as;
            this.lblSave.Location = new System.Drawing.Point(72, 1);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(28, 28);
            this.lblSave.TabIndex = 7;
            this.lblSave.Visible = false;
            this.lblSave.Click += new System.EventHandler(this.lblSave_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.lblHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblHeader.Location = new System.Drawing.Point(95, 4);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(141, 23);
            this.lblHeader.TabIndex = 6;
            this.lblHeader.Text = "کارت شماره :";
            this.lblHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.lblHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.lblHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            // 
            // lblAdd
            // 
            this.lblAdd.BackColor = System.Drawing.Color.Transparent;
            this.lblAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAdd.Image = global::Sbn.Products.TTS.Present.Properties.Resources.bullet_add;
            this.lblAdd.Location = new System.Drawing.Point(49, 2);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(28, 28);
            this.lblAdd.TabIndex = 5;
            this.lblAdd.Click += new System.EventHandler(this.lblAdd_Click);
            // 
            // lblOK
            // 
            this.lblOK.BackColor = System.Drawing.Color.Transparent;
            this.lblOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOK.Image = global::Sbn.Products.TTS.Present.Properties.Resources.accept;
            this.lblOK.Location = new System.Drawing.Point(0, 1);
            this.lblOK.Name = "lblOK";
            this.lblOK.Size = new System.Drawing.Size(28, 28);
            this.lblOK.TabIndex = 0;
            this.lblOK.Click += new System.EventHandler(this.lblOK_Click);
            // 
            // lblRemove
            // 
            this.lblRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRemove.Image = global::Sbn.Products.TTS.Present.Properties.Resources.cancel;
            this.lblRemove.Location = new System.Drawing.Point(26, 3);
            this.lblRemove.Name = "lblRemove";
            this.lblRemove.Size = new System.Drawing.Size(25, 25);
            this.lblRemove.TabIndex = 2;
            this.lblRemove.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtQ
            // 
            this.txtQ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQ.Location = new System.Drawing.Point(0, 1);
            this.txtQ.Multiline = true;
            this.txtQ.Name = "txtQ";
            this.txtQ.Size = new System.Drawing.Size(232, 78);
            this.txtQ.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Image = global::Sbn.Products.TTS.Present.Properties.Resources.page_magnifier;
            this.label2.Location = new System.Drawing.Point(-4, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 28);
            this.label2.TabIndex = 6;
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // txtR
            // 
            this.txtR.BackColor = System.Drawing.Color.LightCyan;
            this.txtR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtR.Location = new System.Drawing.Point(0, 85);
            this.txtR.Multiline = true;
            this.txtR.Name = "txtR";
            this.txtR.Size = new System.Drawing.Size(232, 93);
            this.txtR.TabIndex = 8;
            // 
            // frmLeitnerCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(235, 204);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmLeitnerCard";
            this.Opacity = 0.8D;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSticker";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLeitnerCard_KeyDown);
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
        private System.Windows.Forms.Label lblAdd;
        public System.Windows.Forms.Label lblSave;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtQ;
        public System.Windows.Forms.TextBox txtR;
        public System.Windows.Forms.Label lblHeader;
        public System.Windows.Forms.Label lblOK;
        public System.Windows.Forms.Label lblRemove;
    }
}