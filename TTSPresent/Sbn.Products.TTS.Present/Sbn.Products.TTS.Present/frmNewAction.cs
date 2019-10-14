using Sbn.Libs.TCPListener;
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
    public partial class frmNewAction : Form
    {
        public bool _ChangeAction = true;

//        public int _IntervalToNextAction = 0;
        public frmNewAction()
        {
            InitializeComponent();

            InitialProjects();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime dt0 = DateTime.Now;

            string sDate0 = ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + " " + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00"); // changed by ghmhm 921105

            this.txtMonth.Text = ((Sbn.Controls.FDate.Utils.PersianDate)dt0).Month.ToString();
			this.txtDate.Text = ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d");


		}



		List<string> _Projects = new List<string>();

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
            catch (Exception ex){
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        void SaveAction()
        {
            try
            {
                if (this.cmdLatestActions.Text == "") return;

                DateTime dt0 = DateTime.Now;
                string sDate0 = ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + " " + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00"); // changed by ghmhm 921105

				List<string> lines = new List<string>();
				var sl = this.cmdProjects.Text.Replace(";", "") + ";" + this.txtCpmpleteDesc.Text.Replace("\n", "").Replace(";", "") + ";" + this.cmdLatestActions.Text.Replace(";", "") + ";"
							+ this.txtDate.Text + ";" + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00") + ";" + this.txtDuration.Text + ";;" + System.Security.Principal.WindowsIdentity.GetCurrent().Name;
				lines.Add(sl);

				File.AppendAllLines(Utility._Actions, lines.ToArray());

				if (Main._SendActivityToServer)
                {
                    TCPClient.SendMessage(Main._ActivityServerIPAddress, "UserActivity;#;" + sl, int.Parse(Utility._ChatPort));
                }


                if (!_Projects.Contains(this.cmdProjects.Text))
                    _Projects.Insert(0, this.cmdProjects.Text);

                this.cmdLatestActions.Text = "";
                this.txtCpmpleteDesc.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + "\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SaveAction();
            button3_Click(null, null);
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Dispose();
        }

        public int _IntervalToNextAction = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int m = 0;
            if (this.txtMonth.Text != "" && int.TryParse(this.txtMonth.Text, out m))
                if (m > 12 || m <= 0)
                {
                    MessageBox.Show("مقدار ماه را تعیین نمایید!", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    this.txtMonth.Text = "";
                    return;
                }


            if (this.Size.Height <= 195)
            {
                this.Height = 645;
            }

            int total = 0;

            var st = Utility.GetActions(this.txtMonth.Text, out total, 0, this.cmdLatestActions.Text);
            this.bindingSource1.DataSource = null;
            this.bindingSource1.DataSource = st;
			this.txtTotalDuration.Text = total.ToString();

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
        }

        private void cmdProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitialActions();

        }
        public void InitialActions()
        {
            try
            {

				List<string> _Actions = new List<string>();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

		private void txtMonth_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
