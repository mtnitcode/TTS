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
    public partial class Form1 : Form
    {

//        public int _IntervalToNextAction = 0;
        public Form1()
        {
            InitializeComponent();
            InitialProjects();

            DateTime dt0 = DateTime.Now;
            string sDate0 = ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + " " + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00"); // changed by ghmhm 921105

            this.txtMonth.Text = ((Sbn.Controls.FDate.Utils.PersianDate)dt0).Month.ToString();

        }

        string _oldTask = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Height = 200;
            _oldTask = this.cmdLatestActions.Text;
        //    timer1.Start();
        }

        public List<string> _Actions = new List<string>();
        public List<string> _Projects = new List<string>();

        public string currentProject = "";
        public string currentActivity = "";

        public void InitialProjects()
        {
            try
            {
                //this.cmdProjects.Items.Clear();
				List<string> lines = Utility.GetProjects();
				if (lines == null) return;

				var lineCount = lines.Count;

				if (_Actions.Count == 0 || _Projects.Count == 0)
                {
                    lines.Reverse();
                    foreach (string s in lines)
                    {
                        string[] ss = s.Split(';');

                        if (ss[0] != "" && !_Projects.Contains(ss[0]))
                        {
                            _Projects.Add(ss[0]);
                        }

                        //if (ss[1] != "" && !_Actions.Contains(ss[1]))
                        //{
                        //    _Actions.Add(ss[1]);
                        //}

                    }
                }

                this.cmdProjects.DataSource = null;
                this.cmdProjects.DataSource = _Projects;
                //this.cmdLatestActions.DataSource = null;
                //this.cmdLatestActions.DataSource = _Actions;


            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InitialActions()
        {
            try
            {


                _Actions = new List<string>();
				List<string> lines = Utility.GetProjects();

				if (lines == null) return;
                {
                    lines.Reverse();
                    foreach (string s in lines)
                    {
                        string[] ss = s.Split(';');

                        if (ss[0] == this.cmdProjects.Text && ss[1] != "" && !_Actions.Contains(ss[1]))
                        {
                            _Actions.Add(ss[1]);
                        }

                    }
                }

                this.cmdLatestActions.DataSource = null;
                this.cmdLatestActions.DataSource = _Actions;


            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public bool SaveActivity()
        {
            try
            {
                DateTime dt0 = DateTime.Now;
                string sDate0 = ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + " " + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00"); // changed by ghmhm 921105

                if (_oldTask != this.currentActivity || this.txtDescription.Text != "")
                {

                    Main._SecondsPass = 0;
					List<string> lines = new List<string>();
					lines.Add(this.cmdProjects.Text.Replace(";", "") + ";" + this.txtDescription.Text.Replace(";", "") + ";" + this.cmdLatestActions.Text.Replace(";", "") + ";"
								+ ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + ";" + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00") + ";;;" + System.Security.Principal.WindowsIdentity.GetCurrent().Name);

					File.AppendAllLines(Utility._Actions, lines.ToArray());
                    //System.IO.StreamWriter sw1 = System.IO.File.AppendText(Main._AddressAction + "\\Actions.txt");
                    ////                System.IO.StreamWriter sw = new System.IO.StreamWriter();
                    //sw1.WriteLine(this.cmdProjects.Text.Replace(";", "") + ";" + this.txtDescription.Text.Replace(";", "") + ";" + this.cmdLatestActions.Text.Replace(";", "") + ";"
                    //            + ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + ";" + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00") + ";;;" + System.Security.Principal.WindowsIdentity.GetCurrent().Name);

                    //sw1.Close();
                }

                if (this.chStopActivity.Checked) return false;
                if (this.cmdProjects.Text == "")
                {
                    MessageBox.Show("نام پروژه را تعیین نمایید!", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }



				List<string> lines1 = new List<string>();
				lines1.Add(this.currentProject.Replace(";", "") + ";" + this.currentActivity.Replace(";", "") + ";" + this.txtDescription.Text.Replace(";", "") + ";"
							+ ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + ";" + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00") + ";" + _IsPresent.ToString() + ";" + this.txtDistanceToNextAction.Text + ";" + System.Security.Principal.WindowsIdentity.GetCurrent().Name);

				File.AppendAllLines(Utility._DailyActivities, lines1.ToArray());
                ///

                if (!_Actions.Contains(this.cmdLatestActions.Text) || !_Projects.Contains(this.cmdProjects.Text))
                {
					List<string> lines = new List<string>();
					lines.Add(this.currentProject.Replace(";", "") + ";" + this.currentActivity.Replace(";", ""));
					File.AppendAllLines(Utility._ProjectFilePath, lines.ToArray());
                }

                ///
                if (!_Actions.Contains(this.cmdLatestActions.Text))
                    _Actions.Insert(0, this.cmdLatestActions.Text);


                if (!_Projects.Contains(this.cmdProjects.Text))
                    _Projects.Insert(0, this.cmdProjects.Text);

                this.txtDescription.Text = "";


                _oldTask = this.cmdLatestActions.Text;
                Main.frmClck.lblShowActivity.Text = this.cmdLatestActions.Text;


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + "\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
			_IsPresent = true;

			if (this.chStopActivity.Checked)
            {
                this.Hide();
                return;
            }

            if (txtDistanceToNextAction.Text != "")
            {
                int ol = 0;
                if (int.TryParse(this.txtDistanceToNextAction.Text, out ol))
                {
                    //if (_oldTask != this.cmdLatestActions.Text)
                    {
                        this.currentActivity = this.cmdLatestActions.Text;
                        this.currentProject = this.cmdProjects.Text;
                        if (SaveActivity())
                        {

                            _IntervalToNextAction = ol * 60;
                            this.timer1.Stop();
                            this.Hide();
                        }
                    }
                   // else
                   // {
                   //     this.timer1.Stop();
                   //     this.Hide();
                   // }
                }
                else
                {
                    MessageBox.Show("زمان فعالیت بعدی را تعیین نمایید!", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("زمان فعالیت بعدی را تعیین نمایید!", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
            }
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                button2_Click(null, null);
        }

        public int _IntervalToNextAction = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (txtDistanceToNextAction.Text != "")
            {
                int ol = 0;
                if (int.TryParse(this.txtDistanceToNextAction.Text, out ol))
                {

                    _IntervalToNextAction = ol * 60;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("زمان فعالیت بعدی را تعیین نمایید!", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("زمان فعالیت بعدی را تعیین نمایید!", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
            }
        }

        int _SecondPass = 0;
		bool _IsPresent = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_SecondPass++ >= 180)
            {
                this.timer1.Stop();
				_IsPresent = false;
                if (SaveActivity())
                {
                    _SecondPass = 0;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Hide();
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dailyReport = false;
            int m = 0;
            if (this.txtMonth.Text != "" && int.TryParse(this.txtMonth.Text, out m))
                if (m > 12 || m <= 0)
                {
                    MessageBox.Show("مقدار ماه را تعیین نمایید!", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    this.txtMonth.Text = "";
                    return;
                }


          //  if (this.Size.Height <= 200)
            {
                this.Height = 600;
            }

            float total = 0;

            var st = Utility.MakeActionStatistic(this.txtMonth.Text , out total);
            this.bindingSource1.DataSource = null;
            this.bindingSource1.DataSource = st;
            this.toolStripTextBox1.Text = total.ToString();
            if (total > 0)
            {
                int h = (int)(total / 60);
                int rem = 0;
                Math.DivRem((int)Math.Round(total , 0) , 60, out rem);
                this.tstxtHourTotal.Text = h.ToString() + ":" + rem;

            }


        }
        bool dailyReport = true;
        private void button4_Click(object sender, EventArgs e)
        {
            dailyReport = true;
            int m = 0;

            DateTime dt0 = DateTime.Now;
            this.txtMonth.Text = ((Sbn.Controls.FDate.Utils.PersianDate)dt0).Month.ToString();

            if (this.txtMonth.Text != "" && int.TryParse(this.txtMonth.Text, out m))
                if (m > 12 || m <= 0)
                {
                    MessageBox.Show("مقدار ماه را تعیین نمایید!", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    this.txtMonth.Text = "";
                    return;
                }

//            if (this.Size.Height <= 200)
            {
                this.Height = 600;
            }

            float total = 0;

            var st = Utility.MakeActionStatistic(this.txtMonth.Text, out total, ((Sbn.Controls.FDate.Utils.PersianDate)dt0).Day);
            this.bindingSource1.DataSource = null;
            this.bindingSource1.DataSource = st;

            this.toolStripTextBox1.Text = total.ToString();
            if (total > 0)
            {
                int h = (int)( total / 60);
                int rem = 0;
                Math.DivRem((int)Math.Round(total , 0) , 60, out rem);
                this.tstxtHourTotal.Text = h.ToString() + ":" + rem;

            }


//            else
//                this.Height = 187;

        }

        private void cmdProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitialActions();
        }

        private void txtMonth_TextChanged(object sender, EventArgs e)
        {

        }
        public bool _Stoped = false;
        private void chStopActivity_CheckedChanged(object sender, EventArgs e)
        {
            if(this.chStopActivity.Checked && MessageBox.Show("آیا این فعالیت متوقف شود؟", "سوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    this._Stoped = true;
                    DateTime dt0 = DateTime.Now;
                    string sDate0 = ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + " " + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00"); // changed by ghmhm 921105

					List<string> lines1 = new List<string>();
					lines1.Add("توقف کار;توقف کار;;" + ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + ";" + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00") + ";False;0;" + System.Security.Principal.WindowsIdentity.GetCurrent().Name);
					lines1.Add("توقف کار;توقف کار;;" + ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + ";" + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00") + ";False;0;" + System.Security.Principal.WindowsIdentity.GetCurrent().Name);
					File.AppendAllLines(Utility._DailyActivities, lines1.ToArray());


					return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace + "\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return ;
            }
            else
            {
                this._Stoped = false;
                this.chStopActivity.Checked = false;
                SaveActivity();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

                DateTime dt0 = DateTime.Now;
//                this.txtMonth.Text = ((Sbn.Controls.FDate.Utils.PersianDate)dt0).Month.ToString();

                if (dailyReport)
                {
                    var st = Utility.MakeActivityStatistic(this.txtMonth.Text, this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), ((Sbn.Controls.FDate.Utils.PersianDate)dt0).Day);
                    this.dataGridView2.DataSource = st;
                }
                else
                {
                    var st = Utility.MakeActivityStatistic(this.txtMonth.Text, this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), 0);
                    this.dataGridView2.DataSource = st;
                }
            }
            catch { }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            InitialProjects();
        }
    }
}
