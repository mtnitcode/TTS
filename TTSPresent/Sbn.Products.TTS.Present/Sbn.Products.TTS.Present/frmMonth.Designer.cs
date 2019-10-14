using Sbn.Controls.EventCalendar;
using System;

namespace Sbn.Products.TTS.Present
{
    partial class frmMonth
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
			Sbn.Controls.EventCalendar.DrawTool drawTool1 = new Sbn.Controls.EventCalendar.DrawTool();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMonth));
			this.dayView1 = new Sbn.Controls.EventCalendar.DayView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.جلسهToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.قرارملاقاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.بادآوریToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.سایرفعالیتهاToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.حذفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.faMonthViewStrip1 = new Sbn.Controls.FDate.Win.Controls.FaMonthViewStrip();
			this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
			this.pnlTelehpne = new System.Windows.Forms.Panel();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pnlMonthView = new System.Windows.Forms.Panel();
			this.کارهایانجامشدهToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.یادآوریToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.pnlTelehpne.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.pnlMonthView.SuspendLayout();
			this.SuspendLayout();
			// 
			// dayView1
			// 
			drawTool1.DayView = this.dayView1;
			this.dayView1.ActiveTool = drawTool1;
			this.dayView1.ContextMenuStrip = this.contextMenuStrip1;
			this.dayView1.DaysToShow = 42;
			this.dayView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dayView1.EditTextByClick = false;
			this.dayView1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dayView1.HalfHourHeight = 30;
			this.dayView1.Location = new System.Drawing.Point(0, 0);
			this.dayView1.Name = "dayView1";
			this.dayView1.Size = new System.Drawing.Size(1210, 594);
			this.dayView1.StartHour = 7;
			this.dayView1.TabIndex = 39;
			this.dayView1.Text = "dayView1";
			this.dayView1.TimeStep = 4;
			this.dayView1.ViewDayType = Sbn.Controls.EventCalendar.ViewType.Monthly;
			this.dayView1.WorkingHourEnd = 12;
			this.dayView1.WorkingMinuteEnd = 0;
			this.dayView1.WorkingMinuteStart = 0;
			this.dayView1.ResolveAppointments += new Sbn.Controls.EventCalendar.ResolveAppointmentsEventHandler(this.dayView1_ResolveAppointments);
			this.dayView1.NewAppointment += new Sbn.Controls.EventCalendar.NewAppointmentEventHandler(this.dayView1_NewAppointment);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.جلسهToolStripMenuItem,
            this.قرارملاقاتToolStripMenuItem,
            this.بادآوریToolStripMenuItem,
            this.سایرفعالیتهاToolStripMenuItem,
            this.toolStripSeparator4,
            this.حذفToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(140, 120);
			// 
			// جلسهToolStripMenuItem
			// 
			this.جلسهToolStripMenuItem.Name = "جلسهToolStripMenuItem";
			this.جلسهToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.جلسهToolStripMenuItem.Text = "جلسه";
			this.جلسهToolStripMenuItem.Click += new System.EventHandler(this.جلسهToolStripMenuItem_Click);
			// 
			// قرارملاقاتToolStripMenuItem
			// 
			this.قرارملاقاتToolStripMenuItem.Name = "قرارملاقاتToolStripMenuItem";
			this.قرارملاقاتToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.قرارملاقاتToolStripMenuItem.Text = "قرار ملاقات";
			this.قرارملاقاتToolStripMenuItem.Click += new System.EventHandler(this.قرارملاقاتToolStripMenuItem_Click);
			// 
			// بادآوریToolStripMenuItem
			// 
			this.بادآوریToolStripMenuItem.Name = "بادآوریToolStripMenuItem";
			this.بادآوریToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.بادآوریToolStripMenuItem.Text = "یادآوری";
			this.بادآوریToolStripMenuItem.Click += new System.EventHandler(this.بادآوریToolStripMenuItem_Click);
			// 
			// سایرفعالیتهاToolStripMenuItem
			// 
			this.سایرفعالیتهاToolStripMenuItem.Name = "سایرفعالیتهاToolStripMenuItem";
			this.سایرفعالیتهاToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.سایرفعالیتهاToolStripMenuItem.Text = "فعالیت روزانه";
			this.سایرفعالیتهاToolStripMenuItem.Click += new System.EventHandler(this.سایرفعالیتهاToolStripMenuItem_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(136, 6);
			// 
			// حذفToolStripMenuItem
			// 
			this.حذفToolStripMenuItem.Name = "حذفToolStripMenuItem";
			this.حذفToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.حذفToolStripMenuItem.Text = "حذف";
			this.حذفToolStripMenuItem.Click += new System.EventHandler(this.حذفToolStripMenuItem_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.trackBar1);
			this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
			this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.pnlTelehpne);
			this.splitContainer1.Panel2.Controls.Add(this.pnlMonthView);
			this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.splitContainer1.Size = new System.Drawing.Size(1210, 753);
			this.splitContainer1.SplitterDistance = 155;
			this.splitContainer1.TabIndex = 40;
			// 
			// trackBar1
			// 
			this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.trackBar1.Location = new System.Drawing.Point(1129, 38);
			this.trackBar1.Maximum = 20;
			this.trackBar1.Minimum = 10;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(78, 45);
			this.trackBar1.TabIndex = 41;
			this.trackBar1.Value = 18;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// toolStrip1
			// 
			this.toolStrip1.AutoSize = false;
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.faMonthViewStrip1,
            this.toolStripButton5,
            this.toolStripButton4,
            this.toolStripButton1,
            this.toolStripButton3,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripSeparator3,
            this.toolStripButton6,
            this.toolStripButton7});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.Size = new System.Drawing.Size(1210, 155);
			this.toolStrip1.TabIndex = 42;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(83, 152);
			this.toolStripLabel1.Text = "     بزرگنمایی     ";
			this.toolStripLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.toolStripLabel1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			// 
			// faMonthViewStrip1
			// 
			this.faMonthViewStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.faMonthViewStrip1.Name = "faMonthViewStrip1";
			this.faMonthViewStrip1.Size = new System.Drawing.Size(166, 152);
			this.faMonthViewStrip1.Click += new System.EventHandler(this.faMonthViewStrip1_Click);
			// 
			// toolStripButton5
			// 
			this.toolStripButton5.Image = global::Sbn.Products.TTS.Present.Properties.Resources.calendar_selection_month128;
			this.toolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton5.Name = "toolStripButton5";
			this.toolStripButton5.Size = new System.Drawing.Size(147, 152);
			this.toolStripButton5.Text = "ماهانه";
			this.toolStripButton5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton5.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
			this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
			// 
			// toolStripButton4
			// 
			this.toolStripButton4.Image = global::Sbn.Products.TTS.Present.Properties.Resources.calendar_selection_week128;
			this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Size = new System.Drawing.Size(147, 152);
			this.toolStripButton4.Text = "هفتگی";
			this.toolStripButton4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton4.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
			this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.Image = global::Sbn.Products.TTS.Present.Properties.Resources.calendar_selection_day128;
			this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(147, 152);
			this.toolStripButton1.Text = "روزانه";
			this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.AutoSize = false;
			this.toolStripButton3.Image = global::Sbn.Products.TTS.Present.Properties.Resources.calendar_selection_week1281;
			this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(150, 152);
			this.toolStripButton3.Text = "5 روزه";
			this.toolStripButton3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton3.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
			this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 155);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.Image = global::Sbn.Products.TTS.Present.Properties.Resources.phone_handset;
			this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(51, 152);
			this.toolStripButton2.Text = "دفتر تلفن";
			this.toolStripButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton2.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
			this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 155);
			// 
			// toolStripButton6
			// 
			this.toolStripButton6.CheckOnClick = true;
			this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton6.Image = global::Sbn.Products.TTS.Present.Properties.Resources.editpaste;
			this.toolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton6.Name = "toolStripButton6";
			this.toolStripButton6.Size = new System.Drawing.Size(132, 152);
			this.toolStripButton6.Text = "toolStripButton6";
			this.toolStripButton6.Visible = false;
			this.toolStripButton6.CheckStateChanged += new System.EventHandler(this.toolStripButton6_CheckStateChanged);
			this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
			// 
			// toolStripButton7
			// 
			this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton7.Image = global::Sbn.Products.TTS.Present.Properties.Resources.exit1;
			this.toolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton7.Name = "toolStripButton7";
			this.toolStripButton7.Size = new System.Drawing.Size(132, 152);
			this.toolStripButton7.Text = "toolStripButton7";
			this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
			// 
			// pnlTelehpne
			// 
			this.pnlTelehpne.Controls.Add(this.splitContainer2);
			this.pnlTelehpne.Location = new System.Drawing.Point(403, 81);
			this.pnlTelehpne.Name = "pnlTelehpne";
			this.pnlTelehpne.Size = new System.Drawing.Size(666, 347);
			this.pnlTelehpne.TabIndex = 41;
			this.pnlTelehpne.Visible = false;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.button2);
			this.splitContainer2.Panel1.Controls.Add(this.label1);
			this.splitContainer2.Panel1.Controls.Add(this.textBox1);
			this.splitContainer2.Panel1.Controls.Add(this.button1);
			this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.dataGridView1);
			this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.splitContainer2.Size = new System.Drawing.Size(666, 347);
			this.splitContainer2.SplitterDistance = 250;
			this.splitContainer2.TabIndex = 32;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(2, 242);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(245, 46);
			this.button2.TabIndex = 3;
			this.button2.Text = "جستجو";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Visible = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(138, 196);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(97, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "عبارت جستجو :";
			this.label1.Visible = false;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(3, 215);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(244, 23);
			this.textBox1.TabIndex = 1;
			this.textBox1.Visible = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(2, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(245, 161);
			this.button1.TabIndex = 0;
			this.button1.Text = "ذخیره سازی تغییرات";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToOrderColumns = true;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(412, 347);
			this.dataGridView1.TabIndex = 31;
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "IP";
			this.Column1.HeaderText = "شماره";
			this.Column1.Name = "Column1";
			this.Column1.Width = 250;
			// 
			// Column2
			// 
			this.Column2.DataPropertyName = "Desc";
			this.Column2.HeaderText = "نام";
			this.Column2.Name = "Column2";
			this.Column2.Width = 250;
			// 
			// Column3
			// 
			this.Column3.DataPropertyName = "Email";
			this.Column3.HeaderText = "شرح";
			this.Column3.Name = "Column3";
			this.Column3.Width = 250;
			// 
			// pnlMonthView
			// 
			this.pnlMonthView.Controls.Add(this.dayView1);
			this.pnlMonthView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMonthView.Location = new System.Drawing.Point(0, 0);
			this.pnlMonthView.Name = "pnlMonthView";
			this.pnlMonthView.Size = new System.Drawing.Size(1210, 594);
			this.pnlMonthView.TabIndex = 40;
			// 
			// کارهایانجامشدهToolStripMenuItem
			// 
			this.کارهایانجامشدهToolStripMenuItem.Name = "کارهایانجامشدهToolStripMenuItem";
			this.کارهایانجامشدهToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.کارهایانجامشدهToolStripMenuItem.Text = "کارهای انجام شده";
			// 
			// یادآوریToolStripMenuItem
			// 
			this.یادآوریToolStripMenuItem.Name = "یادآوریToolStripMenuItem";
			this.یادآوریToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.یادآوریToolStripMenuItem.Text = "یادآوری";
			// 
			// frmMonth
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(1210, 753);
			this.Controls.Add(this.splitContainer1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMonth";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "تقویم و دفتر تلفن";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMonth_FormClosing);
			this.Load += new System.EventHandler(this.frmMonth_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMonth_KeyDown);
			this.contextMenuStrip1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.pnlTelehpne.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.pnlMonthView.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private Controls.EventCalendar.DayView dayView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Controls.FDate.Win.Controls.FaMonthViewStrip faMonthViewStrip1;
        private System.Windows.Forms.ToolStripMenuItem کارهایانجامشدهToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem یادآوریToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Panel pnlTelehpne;
        private System.Windows.Forms.Panel pnlMonthView;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem قرارملاقاتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem بادآوریToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem جلسهToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripMenuItem سایرفعالیتهاToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem حذفToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}