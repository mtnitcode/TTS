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
    public partial class FrmProcessStatistics : Form
    {
        public FrmProcessStatistics()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FrmProcessStatistics_Load(object sender, EventArgs e)
        {
            int total = 0;

            var st = Utility.MakeProcessStatistic(this.txtMonth.Text , out total , null);

            this.toolStripTextBox1.Text = total.ToString();

            DateTime dt0 = DateTime.Now;

            string sDate0 = ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + " " + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00"); // changed by ghmhm 921105

            this.txtMonth.Text = ((Sbn.Controls.FDate.Utils.PersianDate)dt0).Month.ToString();

            InitialProjects();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

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
                if (this.Size.Height <= 187)
                {
                    this.Height = 590;
                }
                List<string> lines = new List<string>();

                //
                try
                {
                    System.IO.StreamReader sw = new System.IO.StreamReader(Main._AddressAction + "\\Relations.txt");

                    while (!sw.EndOfStream)
                    {
                        string sl = sw.ReadLine();
                        lines.Add(sl);
                    }

                    sw.Close();
                }
                catch (Exception ex) {
                   // MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                List<string> Processes = new List<string>();

                lines.Reverse();
                foreach (string s in lines)
                {
                    string[] ss = s.Split(';');

                    if (ss[1] == this.cmdProjects.Text)
                    {
                        Processes.Add(ss[0]);
                    }
                }
                //
                int total = 0;
                var st = Utility.MakeProcessStatistic(this.txtMonth.Text, out total, Processes, ((Sbn.Controls.FDate.Utils.PersianDate)dt0).Day);

                this.dataGridView2.DataSource = st;

                this.toolStripTextBox1.Text = (total/60).ToString();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
//
            try
            {
                System.IO.StreamReader sw = new System.IO.StreamReader(Main._AddressAction + "\\Relations.txt");

                List<string> lines = new List<string>();

                while (!sw.EndOfStream)
                {
                    string sl = sw.ReadLine();
                    lines.Add(sl);
                }

                sw.Close();

                List<string> Processes = new List<string>();
                foreach (string s in lines)
                {
                    string[] ss = s.Split(';');

                    if (ss[1] == this.cmdProjects.Text)
                    {
                        Processes.Add(ss[0]);
                    }
                }
                //


                int total = 0;
                var st = Utility.MakeProcessStatistic(this.txtMonth.Text, out total, Processes);
                this.dataGridView2.DataSource = st;
                //this.bindingSource1.DataSource = st;

                this.toolStripTextBox1.Text = (total / 60).ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void InitialProjects()
        {
            try
            {
                List<string> _Projects = new List<string>();
                //                if (_Projects.Count == 0)
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


        bool SaveActivity()
        {
            try
            {
                if (this.dataGridView2.SelectedRows.Count != 1) return false;

                System.IO.StreamWriter sw = System.IO.File.AppendText(Main._AddressAction + "\\Relations.txt");
                //                System.IO.StreamWriter sw = new System.IO.StreamWriter();
                sw.WriteLine(this.dataGridView2.SelectedRows[0].Cells[1].Value + ";" + this.cmdProjects.Text.Replace(";", ""));

                sw.Close();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + "\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void انتخابپروژهمرتبطToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveActivity();
            }
            catch { }
        }

    }
}
