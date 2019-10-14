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
using System.Windows.Forms;
using System.Xml.Linq;

namespace Sbn.Products.TTS.Present
{
    public partial class frmMonth : Form
    {
        public frmMonth()
        {
            InitializeComponent();


            dayView1.NewAppointment += new NewAppointmentEventHandler(dayView1_NewAppointment);
            //dayView1.SelectionChanged += new EventHandler(dayView1_SelectionChanged);
            //dayView1.ResolveAppointments += new ResolveAppointmentsEventHandler(this.dayView1_ResolveAppointments);

			dayView1.WorkingHourEnd = 17;

            //dayView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dayView1_MouseMove);
            dayView1.ViewDayType = ViewType.Monthly;

            InitialReminder();
        }
		List<Appointment> m_Appointments;

		public List<Appointment> InitialReminder()
        {
            try
            {

				if (Main._AddressAction == "") return null;
				ReminderVars.xDocument = XDocument.Load(Main._AddressAction + "\\" + ReminderVars.xmlFileName);
				// if (_Projects.Count == 0)
				{
					var sd = this.dayView1.StartViewDate;
					var ed = this.dayView1.EndViewDate;

					var dd = new MyDateTime(faMonthViewStrip1.FAMonthView.SelectedDateTime);
                    dayView1.StartDate = dd;

                    var Appointments = new List<Appointment>();

                    System.DateTime dt0 = System.DateTime.Now;
                    string sDate0 = ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + " " + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00"); // changed by ghmhm 921105

                    var appointments = from q in ReminderVars.xDocument.Descendants("Appointment")
                                       where q.Attribute("startDate").Value.Contains(dd.Year.ToString("####0000") + "/" + dd.Month.ToString("##00"))
									   || q.Attribute("startDate").Value.Contains(sd.Year.ToString("####0000") + "/" + sd.Month.ToString("##00"))
									   || q.Attribute("startDate").Value.Contains(ed.Year.ToString("####0000") + "/" + ed.Month.ToString("##00"))
									   //from c in q.Descendants("Appointment")
									   select q;

                    foreach (var appoint in appointments)
                    {
                        var app = new Appointment();

                        var d = PersianDateConverter.ToGregorianDate(PersianDate.Parse(appoint.Attribute("startDate").Value , true));

                        app.StartDate = new MyDateTime(System.DateTime.Parse(d));

                    //    if (((Sbn.Controls.FDate.Utils.PersianDate)dt0).Month != app.StartDate.Month)
                    //        OldReminders.Add(s);

                        if (appoint.Attribute("title").Value == "جلسه")
                            app.BorderColor = Color.Red;
                        if (appoint.Attribute("title").Value == "فعالیت روزانه")
                            app.BorderColor = Color.Violet;
                        if (appoint.Attribute("title").Value == "یادآوری")
                            app.BorderColor = Color.Yellow;
                        if (appoint.Attribute("title").Value == "قرارملاقات")
                            app.BorderColor = Color.Orange;

                        if (appoint.Attribute("endDate").Value != "")
                        {
                            d = PersianDateConverter.ToGregorianDate(PersianDate.Parse(appoint.Attribute("endDate").Value, true));
                            app.EndDate = new MyDateTime(System.DateTime.Parse(d));
                        }
                        else
                            app.EndDate = app.StartDate.AddMinutes(15);

                        app.Title = appoint.Attribute("title").Value;
						app.Description = appoint.Attribute("description").Value;


						app.ID =  long.Parse(appoint.Attribute("ID").Value);

                        Appointments.Add(app);
                    }

                    
                    this.dayView1.Invalidate();
					m_Appointments = Appointments;
					return Appointments;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
			return null;


        }


        private void frmMonth_KeyDown(object sender, KeyEventArgs e)
        {
         //   if (e.KeyCode == Keys.Escape) this.Dispose();
        }

        private void frmMonth_Load(object sender, EventArgs e)
        {
			//if(ReminderVars.xDocument == null)

        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void faMonthView_SelectedDateTimeChanged(object sender, EventArgs e)
        {
            var dd = new MyDateTime  (faMonthViewStrip1.FAMonthView.SelectedDateTime);
            dayView1.StartDate = dd;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            dayView1.ViewDayType = ViewType.Monthly;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.dayView1.ViewDayType = ViewType.Day;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.dayView1.ViewDayType = ViewType.Weekly;

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

            this.pnlMonthView.Visible = true;
            this.pnlTelehpne.Visible = false;
            this.pnlMonthView.Dock = DockStyle.Fill;

            this.toolStripButton1.Checked = false;
            this.toolStripButton2.Checked = false;
            this.toolStripButton3.Checked = false;
            this.toolStripButton4.Checked = false;
            this.toolStripButton5.Checked = true;

            dayView1.ViewDayType = ViewType.Monthly;
            InitialReminder();
			InitialReminder();

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            this.pnlMonthView.Visible = true;
            this.pnlTelehpne.Visible = false;
            this.pnlMonthView.Dock = DockStyle.Fill;

            this.toolStripButton1.Checked = false;
            this.toolStripButton3.Checked = false;
            this.toolStripButton2.Checked = false;
            this.toolStripButton4.Checked = true;
            this.toolStripButton5.Checked = false;

            dayView1.ViewDayType = ViewType.Weekly;
            InitialReminder();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.pnlMonthView.Visible = true;
            this.pnlTelehpne.Visible = false;
            this.pnlMonthView.Dock = DockStyle.Fill;

            this.toolStripButton1.Checked = true;
            this.toolStripButton3.Checked = false;
            this.toolStripButton2.Checked = false;
            this.toolStripButton4.Checked = false;
            this.toolStripButton5.Checked = false;

            dayView1.ViewDayType = ViewType.Day;

            InitialReminder();

        }

        private void faMonthViewStrip1_Click(object sender, EventArgs e)
        {
			return;
			var sd = this.faMonthViewStrip1.FAMonthView.SelectedDateTime;


            MyDateTime dd = new  MyDateTime (faMonthViewStrip1.FAMonthView.SelectedDateTime);
            dayView1.StartDate = dd;
			InitialReminder();
			InitialReminder();


		}

		private void NewReminder(string title , Appointment m_App)
		{
			frmReminder frm = new frmReminder();
			frm.txtReminder.Text = title;

			frm.txtTime.Text = m_App.StartDate.Hour.ToString("##00") + ":" + m_App.StartDate.Minute.ToString("##00");
			frm.txtDate.Text = m_App.StartDate.Year.ToString("####0000") + "/" + m_App.StartDate.Month.ToString("##00") + "/" + m_App.StartDate.Day.ToString("##00");
			frm.EndTime = m_App.EndDate.Hour.ToString("##00") + ":" + m_App.EndDate.Minute.ToString("##00");
			frm.txtEndDate.Text = m_App.EndDate.Hour.ToString("##00") + ":" + m_App.EndDate.Minute.ToString("##00");
			if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{

				InitialReminder();

			}
		}

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.pnlMonthView.Visible = false;
            this.pnlTelehpne.Visible = true;
            this.pnlTelehpne.Dock = DockStyle.Fill;

            this.toolStripButton1.Checked = false;
            this.toolStripButton3.Checked = false;
            this.toolStripButton2.Checked = true;
            this.toolStripButton4.Checked = false;
            this.toolStripButton5.Checked = false;

            if (toolStripButton2.Checked)
                initialContacts();
        }
        private void قرارملاقاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Appointment m_App = new Appointment();

            m_App.StartDate = this.dayView1.SelectionStart;
            m_App.EndDate = this.dayView1.SelectionEnd;
            if (dayView1.ViewDayType != ViewType.Day)
                m_App.EndDate = this.dayView1.SelectionStart.AddMinutes(30);


			NewReminder("قرارملاقات", m_App);

        }

        private void جلسهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Appointment m_App = new Appointment();

            m_App.StartDate = this.dayView1.SelectionStart;
            m_App.EndDate = this.dayView1.SelectionEnd;
            if (dayView1.ViewDayType != ViewType.Day)
                m_App.EndDate = this.dayView1.SelectionStart.AddMinutes(30);
			NewReminder("جلسه", m_App);
			
        }

        private void بادآوریToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Appointment m_App = new Appointment();

            m_App.StartDate = this.dayView1.SelectionStart;
            m_App.EndDate = this.dayView1.SelectionEnd;
            if (dayView1.ViewDayType != ViewType.Day)
                m_App.EndDate = this.dayView1.SelectionStart.AddMinutes(30);
			NewReminder("یادآوری", m_App);
		  
        }

        private void dayView1_NewAppointment(object sender, NewAppointmentEventArgs args)
        {

            //Appointment m_App = new Appointment();

            //m_App.StartDate = args.StartDate;
            //m_App.EndDate = args.EndDate;

            //m_App.BorderColor = Color.Black;

            //m_Appointments.Add(m_App);

            //dayView1.Invalidate();
        }

		private void dayView1_ResolveAppointments(object sender, ResolveAppointmentsEventArgs args)
        {
            try
            {
				//return;
                List<Appointment> m_Apps = new List<Appointment>();
				//List<Appointment> Apps = InitialReminder();
				if (m_Appointments != null)
				{

                    foreach (Appointment m_App in m_Appointments)
                        if (m_App.StartDate.Month >= this.dayView1.StartViewDate.Month) 
                            //(m_App.StartDate. <= this.dayView1.EndViewDate.m_GregoryDate))
                            m_Apps.Add(m_App);

                    args.Appointments = m_Apps;

                }
            }
            catch
            {

            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            this.pnlMonthView.Visible = true;
            this.pnlTelehpne.Visible = false;
            this.pnlMonthView.Dock = DockStyle.Fill;

            this.toolStripButton1.Checked = false;
            this.toolStripButton2.Checked = false;
            this.toolStripButton3.Checked = true;
            this.toolStripButton4.Checked = false;
            this.toolStripButton5.Checked = true;

            this.dayView1.ViewDayType = ViewType.Day;
            dayView1.DaysToShow = 5;

        }

        private void سایرفعالیتهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Appointment m_App = new Appointment();

            m_App.StartDate = this.dayView1.SelectionStart;
            m_App.EndDate = this.dayView1.SelectionEnd;
            if (dayView1.ViewDayType != ViewType.Day)
                m_App.EndDate = this.dayView1.SelectionStart.AddMinutes(30);
			NewReminder("فعالیت روزانه", m_App);
			
        }

        bool _viewTask = false;

        private void toolStripButton6_CheckStateChanged(object sender, EventArgs e)
        {
            if (toolStripButton6.Checked)
                _viewTask = true;

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            dayView1.HalfHourHeight = trackBar1.Value;
        }


        void initialContacts()
        {
            try
            {
                this.dataGridView1.Rows.Clear();

                System.IO.StreamReader sw = new System.IO.StreamReader(Main._AddressAction + "\\Contacts.txt");

                List<string> lines = new List<string>();

                int l = 0;

                while (!sw.EndOfStream)
                {

                    string sl = sw.ReadLine();

                    lines.Add(sl);

                }

                sw.Close();

                List<object> ActionSt = new List<object>();

                foreach (string s in lines)
                {
                    string[] ss = s.Split(';');

                    string ip = "";
                    string email = "";
                    email = ss[2];

                    ip = ss[0];

                    string name = "";
                    name = ss[1];

                    this.dataGridView1.Rows.Add(ip, name, email);

                    //ActionSt.Add(new { PhoneNumber = ip, Name = name, Desc = email });

                }
            }
            catch { }
            //this.bindingSource1.DataSource = Utility.GetReceivers();
            // this.dataGridView1.DataSource = Utility.GetReceivers();


        }

        void applyAction()
        {
            try
            {

                // string selectedAction = "";

                // selectedAction = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                StringBuilder sb = new StringBuilder();

                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {

                    if (row.Cells[0].Value != null && row.Cells[0].Value != null && row.Cells[1].Value != null)
                    {

                        string tel = (row.Cells[0].Value == null) ? "" : row.Cells[0].Value.ToString();
                        string name = (row.Cells[1].Value == null) ? "" : row.Cells[1].Value.ToString();
                        string email = (row.Cells[2].Value == null) ? "" : row.Cells[2].Value.ToString();

                        sb.Append(tel + ";" + name + ";" + email + "\r\n");
                    }

                }

                File.WriteAllText(Main._AddressAction + "\\Contacts.txt", sb.ToString());

                MessageBox.Show("فهرست تماسها ذخیر شد.", "پیام", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + "\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            applyAction();
        }
        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteFromXMLAndTreeView(this.dayView1.SelectedAppointment.ID.ToString());
           // applyReminder(true);

        }

        private void frmMonth_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public bool deleteFromXMLAndTreeView(string wordID)
        {
            try
            {
                if (MessageBox.Show("آیا این مورد حذف شود ؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes) return false;

                var destinationElement = (from q in ReminderVars.xDocument.Descendants("Appointment")
                                          where q.Attribute("ID").Value == wordID.ToString()
                                          select q).First();
                destinationElement.Remove();
				destinationElement = null;


				ReminderVars.xDocument.Save(Main._AddressAction + "\\" + ReminderVars.xmlFileName);

                InitialReminder();

                return true;
            }
            catch (Exception ex)
            {
                //StackFrame file_info = new StackFrame(true);
                //                error(ref file_info, ex.Message);
                return false;
            }

            
        }
        public static bool addToXMLAndTreeView(string project ,  string title, string desc,bool isrepeat , bool isautomatic , string startdate , string enddate )
        {
            try
            {
                XElement destinationBox;
                int maxID = 0;
                try
                {
                    maxID = (from q in ReminderVars.xDocument.Descendants("Appointment")
                             select (int)q.Attribute("ID")).Max();
                }
                catch { }
                maxID++;

                destinationBox = (from q in ReminderVars.xDocument.Descendants("Reminder")
                                  select q).First();

                destinationBox.Add(
                        new XElement("Appointment", new XAttribute("ID", maxID),
                            new XAttribute("project", project),
                            new XAttribute("title", title),
                            new XAttribute("description", desc),
                            new XAttribute("isrepeat", isrepeat.ToString()),
                            new XAttribute("isautostart", isautomatic.ToString()),
                            new XAttribute("startDate", startdate) ,
                            new XAttribute("endDate", enddate)
                            )
                        );
                ReminderVars.xDocument.Save(Main._AddressAction + "\\"+ ReminderVars.xmlFileName);
                return true;
            }
            catch (Exception ex)
            {
				MessageBox.Show(ex.StackTrace + "\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
            }
        }

    }

    public static class ReminderVars
    {
        public static XDocument xDocument;
        public static string xmlFileName = "Reminder.xml";
        public static string usersFolder = Main._AddressAction;
    }
}
