namespace Calendar
{
    partial class Form2
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
            Sbn.Controls.EventCalendar.DrawTool drawTool1 = new Sbn.Controls.EventCalendar.DrawTool();
            this.dayView1 = new Sbn.Controls.EventCalendar.DayView();
            this.faDatePicker1 = new Sbn.Controls.FDate.Win.Controls.FADatePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dayView1
            // 
            drawTool1.DayView = this.dayView1;
            this.dayView1.ActiveTool = drawTool1;
            this.dayView1.EditTextByClick = false;
            this.dayView1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.dayView1.Location = new System.Drawing.Point(12, 30);
            this.dayView1.Name = "dayView1";
            this.dayView1.Size = new System.Drawing.Size(865, 566);
            this.dayView1.TabIndex = 0;
            this.dayView1.Text = "dayView1";
            this.dayView1.TimeStep = 3;
            this.dayView1.ViewDayType = Sbn.Controls.EventCalendar.ViewType.Monthly;
            // 
            // faDatePicker1
            // 
            this.faDatePicker1.Location = new System.Drawing.Point(561, 4);
            this.faDatePicker1.Name = "faDatePicker1";
            this.faDatePicker1.Size = new System.Drawing.Size(120, 20);
            this.faDatePicker1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(319, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 616);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.faDatePicker1);
            this.Controls.Add(this.dayView1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private Sbn.Controls.EventCalendar.DayView dayView1;
        private Sbn.Controls.FDate.Win.Controls.FADatePicker faDatePicker1;
        private System.Windows.Forms.Button button1;
    }
}