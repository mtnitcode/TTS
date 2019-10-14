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
    public partial class frmSticker : Form
    {
        public frmSticker()
        {
            InitializeComponent();
        }

		void deleteTodo()
		{
			try
			{
				string[] allLines = File.ReadAllLines(Utility._ToDoListFilePath);
				List<string> sb = new List<string>();

				foreach (string s in allLines)
				{
					if (s.Split(';')[2] != this.lblTitle.Text || s.Split(';')[1] != this.txtCompleteDesc.Text)
					{
						sb.Add(s);
					}
				}

				File.WriteAllLines(Utility._ToDoListFilePath, sb.ToArray());
			}
			catch
			{

			}
		}

		void applyAction(bool delele)
        {
            try
            {
                //string sdesc = "";

                if (delele)
                {
					if (MessageBox.Show("آیا این مورد حذف شود ؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
					{
						deleteTodo();
						Main._ToDoChange = true;
						this.Dispose();
						return;
					}
                }
                else

                {

					frmNewAction frm = new frmNewAction();

					frm.cmdProjects.Text = this.lblProject.Text;
					frm.cmdLatestActions.Text = this.lblTitle.Text;
					frm.txtCpmpleteDesc.Text = this.txtCompleteDesc.Text;
					if (frm.ShowDialog() == DialogResult.OK)
					{
						/*

						List<string> lines = new List<string>();
						lines.Add(action);
						File.AppendAllLines(Utility._Actions, lines.ToArray());
						*/
						DateTime dt0 = DateTime.Now;
						string sDate0 = ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + " " + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00"); // changed by ghmhm 921105
						var action = this.lblProject.Text + ";" + this.txtCompleteDesc.Text.Replace(";", "") + ";" + this.lblTitle.Text.Replace(";", "") + ";"
									+ ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + ";" + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00") + ";;;" + System.Security.Principal.WindowsIdentity.GetCurrent().Name;


						if (Main._SendActivityToServer)
						{
							TCPClient.SendMessage(Main._ActivityServerIPAddress, "UserActivity;#;" + action, int.Parse(Utility._ChatPort));
						}
						deleteTodo();
						Main._ToDoChange = true;
						this.Dispose();

					}

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
            applyAction(false);
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
                Main.frm.cmdLatestActions.Text = this.lblTitle.Text;
				Main.frm.txtDescription.Text = this.txtCompleteDesc.Text;
				if (Main.frm.ShowDialog() == DialogResult.OK)
				{
					deleteTodo();
					Main._SecondsPass = 0;
					this.Dispose();
				}
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

        private void lblAdd_Click(object sender, EventArgs e)
        {
            frmToDoActions frm = new frmToDoActions();
            frm.Show();
        }

		private void label1_Click_1(object sender, EventArgs e)
		{

		}
	}
}
