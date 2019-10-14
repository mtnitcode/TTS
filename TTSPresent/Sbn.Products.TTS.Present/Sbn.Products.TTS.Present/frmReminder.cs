using Sbn.Controls.EventCalendar;
using Sbn.Controls.FDate.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sbn.Products.TTS.Present
{
    public partial class frmReminder : Form
    {
       // List<string> _Projects = new List<string>();

        //Dictionary<int, object> _Queue = new Dictionary<int, object>();

        public string EndTime = "";

        List<object> _Queue = new List<object>();

        public void InitialReminders()
        {
            try
            {
             //   if ( _Projects.Count == 0)
                {

					var apps = Main._frmMonth.InitialReminder();

                    _Queue = new List<object>();

                    foreach (Appointment a in apps)
                    {
                        //string[] ss = s.Split(';');

                        var obj = new { Time = a.StartDate.ToLongDateString() , Desc = a.Title, Auto = "False" };

                        _Queue.Add(obj);
                    }
                }

                this.bindingSource1.DataSource = _Queue;

            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

		public void InitialProjects()
		{
			try
			{
				if (_Projects.Count == 0)
				{


					List<string> lines = Utility.GetProjects();



					lines.Reverse();
					foreach (string s in lines)
					{
						string[] ss = s.Split(';');

						if (ss[0] != "" && !_Projects.Contains(ss[0]))
						{
							_Projects.Add(ss[0]);
						}
					}
				}

				this.cmdProjects.DataSource = null;
				this.cmdProjects.DataSource = _Projects;
			}
			catch (Exception ex)
			{
				//MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}


		}

        void SaveActivity()
        {
            try
            {

                string sDate = txtDate.Text + " " + txtTime.Text + ":00";
                PersianDate pd = new PersianDate();
                try
                {
                    pd = PersianDate.Parse(sDate, true);
                }
                catch
                {
                    MessageBox.Show("تاریخ و زمان را صحیح وارد نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime dt0 = DateTime.Now;
                string sDate0 = pd.ToString("d") + " " + pd.Hour.ToString("##00") + ":" + pd.Minute.ToString("##00") + ":" + pd.Second.ToString("##00"); // changed by ghmhm 921105
                string sEDate0 = pd.ToString("d") + " " + this.txtEndDate.Text + ":" + pd.Second.ToString("##00"); // changed by ghmhm 921105


                if (frmMonth.addToXMLAndTreeView(this.cmdProjects.Text, this.txtReminder.Text, this.txtDescription.Text, this.chRepeate.Checked, this.chCalculateTime.Checked, sDate0, sEDate0)) 
                {

                }
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + "\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
		List<string> _Projects = new List<string>();


		public frmReminder()
        {
            InitializeComponent();
			InitialProjects();


		}


		private void frmReminder_Load(object sender, EventArgs e)
        {
			

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                SaveActivity();

            }
            catch(Exception ex){
                //MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.Size.Height <= 300)
                this.Height = 590;
			InitialReminders();
			//InitialProjects();

		}

        private void frmReminder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Dispose();
        }

        private void chRepeate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chRepeate.Checked)
            {
                this.txtDate.Enabled = false;
               // this.chCalculateTime.Enabled = false;
            }
            else
            { this.txtDate.Enabled = true;
           // this.chCalculateTime.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //applyAction(true);
        }

        private void faMonthView_SelectedDateTimeChanged(object sender, EventArgs e)
        {
            this.txtDate.Text = ((PersianDate)this.faMonthView.SelectedDateTime).ToString("d");
        }
    }
}
