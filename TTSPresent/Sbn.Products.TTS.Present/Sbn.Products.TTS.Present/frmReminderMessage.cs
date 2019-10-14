using Sbn.Libs.TCPListener;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sbn.Products.TTS.Present
{
    public partial class frmReminderMessage : Form
    {
        public frmReminderMessage()
        {
            InitializeComponent();
        }


        void SaveAction()
        {
            try
            {
                //string sdesc = "";

  
               //if (frmToDoActions.InputBox("سوال", "توضیح :", ref sdesc) != System.Windows.Forms.DialogResult.OK) return;

                string selectedAction = "";

                selectedAction = this.lblDesc.Text;


                    DateTime dt0 = DateTime.Now;
                    string sDate0 = ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + " " + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00"); // changed by ghmhm 921105

				List<string> lines = new List<string>();
				lines.Add(this.lblProject.Text + ";" + this.txtCompleteDesc.Text.Replace(";", "") + ";" + selectedAction.Replace(";", "") + ";"
								+ ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + ";" + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00") + ";;;" + System.Security.Principal.WindowsIdentity.GetCurrent().Name);

				File.AppendAllLines(Utility._Actions, lines.ToArray());


				if (Main._SendActivityToServer)
                    {
                        TCPClient.SendMessage(Main._ActivityServerIPAddress, "UserActivity;#;" + this.lblProject.Text + ";" + this.txtCompleteDesc.Text.Replace(";", "") + ";" + selectedAction.Replace(";", "") + ";"
                                + ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + ";" + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00") + ";;;" + System.Security.Principal.WindowsIdentity.GetCurrent().Name, int.Parse(Utility._ChatPort));
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + "\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void applyAction(bool delele)
        {
            try
            {
                if (delele)
                {
                    if (MessageBox.Show("آیا این مورد حذف شود ؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes) return;

                    string selectedAction = "";

                    selectedAction = this.txtCompleteDesc.Text;

                    string[] allLines = File.ReadAllLines(Main._AddressAction + "\\RepeatReminder.txt");
                    StringBuilder sb = new StringBuilder();

                    foreach (string s in allLines)
                    {

                        if (s.Split(';')[0] != selectedAction)
                        {
                            sb.Append(s + "\r\n");

                        }
                    }

                    File.WriteAllText(Main._AddressAction + "\\RepeatReminder.txt", sb.ToString());
					
                    this.Dispose();

                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + "\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        Point firstPoint = new Point();

        private void frmSticker_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void frmSticker_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void frmSticker_MouseLeave(object sender, EventArgs e)
        {

        }

        private void frmSticker_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblOK_Click(object sender, EventArgs e)
        {
            SaveAction();
            this.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           applyAction(true);

        }

        private void lblActivity_Click(object sender, EventArgs e)
        {
            try
            {

                Main.frm.cmdProjects.Text = this.lblProject.Text;
                Main.frm.txtDescription.Text = this.lblDesc.Text;
                Main.frm.Show();
                Main._SecondsPass = 0;

                this.Dispose();
            }
            catch
            {

            }
        }

        private void lblDesc_MouseUp(object sender, MouseEventArgs e)
        {
            
            Main._clockPosition.Y = this.Top;
            Main._clockPosition.X = this.Left;
        }

        private void lblDesc_MouseMove(object sender, MouseEventArgs e)
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

        private void lblDesc_MouseDown(object sender, MouseEventArgs e)
        {

            this.timer1.Stop();
            this.Visible = true;

            firstPoint = e.Location;

        }

        private void lblProject_MouseMove(object sender, MouseEventArgs e)
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

        private void lblProject_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;

        }

        private void lblProject_MouseUp(object sender, MouseEventArgs e)
        {
            Main._clockPosition.Y = this.Top;
            Main._clockPosition.X = this.Left;

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            frmReminder frm = new frmReminder();
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Visible == false)
                this.Visible = true;
            else
                this.Visible = false;
        }
    }
}
