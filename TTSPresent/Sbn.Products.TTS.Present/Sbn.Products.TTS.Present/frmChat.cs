using Sbn.Controls.FDate.Utils;
using Sbn.Libs.TCPListener;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace Sbn.Products.TTS.Present
{
    public partial class frmChat : Form
    {
        public frmChat()
        {
            InitializeComponent();

            InitialProjects();

        }

        public string _ReceiverIPAddress = "";
        private string sChats = "";
        public void addText(string s)
        {
            sChats += s;


        }
        private void frmChat_Load(object sender, EventArgs e)
        {
            
            string[] sName = this.cmdNames.Text.Split('/');
            string sIP = sName[0];
            _ReceiverIPAddress = sIP;

            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.cmdNames.Enabled = false;

                string[] sName = this.cmdNames.Text.Split('/');
                string sIP = sName[0];
                _ReceiverIPAddress = sIP;

                TCPClient.SendMessage(_ReceiverIPAddress, Main._LocalIPAddress + ";#;" + Main._Name + ";#;" + this.txtText.Text , int.Parse(Utility._ChatPort));

                this.txtDialogues.Text += "\n" + " شما : " + this.txtText.Text + "\n";

                this.txtText.Text = "";

                this.txtDialogues.SelectionStart = this.txtDialogues.Text.Length;

                this.txtDialogues.ScrollToCaret();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void frmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public void InitialProjects()
        {
            try
            {
               // if (_Projects.Count == 0)
                {


					List<string> lines = File.ReadAllLines(Utility._Receivers).ToList();

                    foreach(string sl in lines)
                    {
                        string address = "";
                        address = sl;
                        if (sl.Split(';').Length >= 2)
                            address = sl.Split(';')[0];

                        this.cmdNames.Items.Add(address);

                    }

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        void SaveReciever()
        {
            try
            {

				List<string> lines = new List<string>();
				lines.Add(this.cmdNames.Text.Replace(";", ""));
				File.AppendAllLines(Utility._Receivers, lines.ToArray());

                this.cmdNames.Items.Add(this.cmdNames.Text.Replace(";", ""));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + "\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void SaveDialog()
        {
            try
            {


                System.IO.StreamWriter sw = null;
                sw = System.IO.File.AppendText(Main._AddressAction + "\\" + this.cmdNames.Text.Replace("/", "").Replace(".", "") + ".txt");

                string[] sss = this.txtDialogues.Text.Split('\n');
                foreach (string s in sss)
                {
                    sw.WriteLine(s + "\n");
                }

                //                sw.WriteLine(this.cmdProjects.Text + ";" + this.cmdLatestActions.Text + ";" + sDate0);

                sw.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + "\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (this.cmdNames.Text != "" && !this.cmdNames.Items.Contains(this.cmdNames.Text))
            {
                SaveReciever();

                MessageBox.Show("آدرس این فرد به فهرست اضافه شد.", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDialog();
            this.txtDialogues.Text = "";
            this.Hide();
        }


    }
}
