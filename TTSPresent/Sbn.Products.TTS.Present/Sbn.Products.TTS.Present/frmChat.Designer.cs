namespace Sbn.Products.TTS.Present
{
    partial class frmChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChat));
            this.button1 = new System.Windows.Forms.Button();
            this.cmdNames = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbar_SendMessage = new System.Windows.Forms.ToolBar();
            this.tbBtn_Font = new System.Windows.Forms.ToolBarButton();
            this.tbBtn_Emoticons = new System.Windows.Forms.ToolBarButton();
            this.cmenu_Emoticons = new System.Windows.Forms.ContextMenu();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rtBox_Main = new Khendys.Controls.ExRichTextBox();
            this.txtText = new Khendys.Controls.ExRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "ارسال";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdNames
            // 
            this.cmdNames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNames.FormattingEnabled = true;
            this.cmdNames.Location = new System.Drawing.Point(440, 7);
            this.cmdNames.Name = "cmdNames";
            this.cmdNames.Size = new System.Drawing.Size(214, 22);
            this.cmdNames.Sorted = true;
            this.cmdNames.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(660, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "آدرس :";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(321, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "اضافه به فهرست";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 85);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 40);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "ذخیره و بستن";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbar_SendMessage
            // 
            this.tbar_SendMessage.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.tbar_SendMessage.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbBtn_Font,
            this.tbBtn_Emoticons});
            this.tbar_SendMessage.ButtonSize = new System.Drawing.Size(50, 24);
            this.tbar_SendMessage.DropDownArrows = true;
            this.tbar_SendMessage.ImageList = this.imageList1;
            this.tbar_SendMessage.Location = new System.Drawing.Point(0, 0);
            this.tbar_SendMessage.Margin = new System.Windows.Forms.Padding(0);
            this.tbar_SendMessage.Name = "tbar_SendMessage";
            this.tbar_SendMessage.ShowToolTips = true;
            this.tbar_SendMessage.Size = new System.Drawing.Size(711, 36);
            this.tbar_SendMessage.TabIndex = 15;
            this.tbar_SendMessage.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
            // 
            // tbBtn_Font
            // 
            this.tbBtn_Font.Name = "tbBtn_Font";
            this.tbBtn_Font.Text = "قلم";
            this.tbBtn_Font.ToolTipText = "Change the font for messages you send";
            this.tbBtn_Font.Visible = false;
            // 
            // tbBtn_Emoticons
            // 
            this.tbBtn_Emoticons.DropDownMenu = this.cmenu_Emoticons;
            this.tbBtn_Emoticons.ImageKey = "AngelSmile.png";
            this.tbBtn_Emoticons.Name = "tbBtn_Emoticons";
            this.tbBtn_Emoticons.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            this.tbBtn_Emoticons.Text = "شکلک";
            this.tbBtn_Emoticons.ToolTipText = "ارسال شکلک";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "AngelSmile.png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.AllowDrop = true;
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(2, 35);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rtBox_Main);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbar_SendMessage);
            this.splitContainer1.Panel2.Controls.Add(this.txtText);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(711, 536);
            this.splitContainer1.SplitterDistance = 393;
            this.splitContainer1.TabIndex = 16;
            // 
            // rtBox_Main
            // 
            this.rtBox_Main.AllowDrop = true;
            this.rtBox_Main.BackColor = System.Drawing.SystemColors.Window;
            this.rtBox_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtBox_Main.DetectUrls = true;
            this.rtBox_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtBox_Main.HideSelection = false;
            this.rtBox_Main.HiglightColor = Khendys.Controls.RtfColor.White;
            this.rtBox_Main.Location = new System.Drawing.Point(0, 0);
            this.rtBox_Main.Name = "rtBox_Main";
            this.rtBox_Main.ReadOnly = true;
            this.rtBox_Main.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rtBox_Main.Size = new System.Drawing.Size(711, 393);
            this.rtBox_Main.TabIndex = 13;
            this.rtBox_Main.TabStop = false;
            this.rtBox_Main.Text = "";
            this.rtBox_Main.TextColor = Khendys.Controls.RtfColor.Black;
            this.rtBox_Main.WordWrap = false;
            this.rtBox_Main.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtBox_Main_LinkClicked);
            this.rtBox_Main.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rtBox_Main_MouseUp);
            // 
            // txtText
            // 
            this.txtText.AllowDrop = true;
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.DetectUrls = true;
            this.txtText.HiglightColor = Khendys.Controls.RtfColor.White;
            this.txtText.Location = new System.Drawing.Point(105, 39);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(603, 94);
            this.txtText.TabIndex = 17;
            this.txtText.Text = "";
            this.txtText.TextColor = Khendys.Controls.RtfColor.Black;
            this.txtText.OnDroped += new System.EventHandler(this.rtBox_Main_OnDroped);
            // 
            // frmChat
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 569);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cmdNames);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmChat";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گفتگو";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChat_FormClosing);
            this.Load += new System.EventHandler(this.frmChat_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.ComboBox cmdNames;
        private System.Windows.Forms.Button btnSave;
        public Khendys.Controls.ExRichTextBox rtBox_Main;
        private System.Windows.Forms.ToolBar tbar_SendMessage;
        private System.Windows.Forms.ToolBarButton tbBtn_Font;
        private System.Windows.Forms.ToolBarButton tbBtn_Emoticons;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenu cmenu_Emoticons;
        private Khendys.Controls.ExRichTextBox txtText;
    }
}