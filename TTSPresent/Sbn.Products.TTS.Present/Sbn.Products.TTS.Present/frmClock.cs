using Sbn.Controls.FDate.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sbn.Products.TTS.Present
{
    public partial class frmClock : Form
    {
        public frmClock()
        {

            InitializeComponent();

            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;
            //this.Width = 116;

            try
            {
                PersianDate p = new PersianDate();
                this.analogClock3.MonthName= p.Day.ToString() + " " + p.LocalizedMonthName;
                //this.lblMonth.Text = mountName;
                this.analogClock3.DayName = p.LocalizedWeekDayName;
                // this.lblDay.Text = dayName;
            }
            catch
            {

            }
        }

        private void frmClock_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main.frm.InitialProjects();
            Main.frm.Show();
            //this.Hide();
        }




        Point firstPoint = new Point();
        private void analogClock3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // Get the difference between the two points
                int xDiff = firstPoint.X - e.Location.X;
                int yDiff = firstPoint.Y - e.Location.Y;

                // Set the new point
                int x = this.Location.X - xDiff;
                int y = this.Location.Y - yDiff;
                this.Location = new Point(x, y);
            }
        }

        private void analogClock3_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;

        }

        private void analogClock3_MouseUp(object sender, MouseEventArgs e)
        {
            Main._clockPosition.Y = this.Top;
            Main._clockPosition.X = this.Left;
        }

        private void analogClock3_Click(object sender, EventArgs e)
        {
			foreach(frmSticker f in Main._Stickers)
			{
				try
				{
					f.BringToFront();
				}
				catch
				{

				}

			}

        }

        private void analogClock3_Load(object sender, EventArgs e)
        {

        }

        private void frmClock_Load(object sender, EventArgs e)
        {
            /*
            if (this.Size.Height > 107)
                this.Height = 107;
            else
                this.Height = 140;
            */
            this.Height = 110;
            this.Width = 102;
        }

        private void progressBar1_MouseLeave(object sender, EventArgs e)
        {
            this.Height = 110;
        }

        private void progressBar1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Height = 149;
            /*
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (this.Size.Height > 107)
                    this.Height = 107;
                else
                    this.Height = 140;

                this.Width = 98;
            }
            else
            {

            }*/
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            //Main.frm.Show();
        }

        private void analogClock3_DoubleClick(object sender, EventArgs e)
        {
            Main.frm.Show();
            Main.frm.Activate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(!Main._frmMonth.Visible)
                Main._frmMonth.Show();
        }
    }
}
