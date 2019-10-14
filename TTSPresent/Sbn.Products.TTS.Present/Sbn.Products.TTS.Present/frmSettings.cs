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
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

				List<string> linesSettings = new List<string>();

                if (Main._callFromExtApp)
                {
                    if (!System.IO.Directory.Exists("C:\\Sayban\\TTSPresent"))
                    {
                        System.IO.Directory.CreateDirectory("C:\\Sayban\\TTSPresent");
                    }
                    Main._AddressAction = "C:\\Sayban\\TTSPresent";
                }

				linesSettings.Add(this.checkBox1.Checked.ToString() + ";" + this.txtFrequency.Text + ";" + this.txtDuration.Text); // alarm sound
				linesSettings.Add(this.txtAddress.Text); // files address
				linesSettings.Add(this.txtAbsent.Text); // absent times
				linesSettings.Add(this.txtName.Text); // user name
				linesSettings.Add(this.chSendActivityToSrv.Checked.ToString() + ";" + this.txtIP.Text); // send to admin
				linesSettings.Add(Main._clockPosition.X.ToString() + ";" + Main._clockPosition.Y.ToString()); // clock position
				linesSettings.Add(this.txtChatPort.Text); // chat port

				var fs = File.Create(Utility._SettingsFilePath);
				fs.Close();
				File.WriteAllLines(Utility._SettingsFilePath, linesSettings.ToArray());

                Main._Name = this.txtName.Text;

                if (this.txtAddress.Text != "") Main._AddressAction = this.txtAddress.Text;
                Main._ActivityServerIPAddress = this.txtIP.Text;
                Main._SendActivityToServer = this.chSendActivityToSrv.Checked;
				Utility._ChatPort = this.txtChatPort.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + "\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Dispose();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Utility._SettingsFilePath)) return;

            if (Main._callFromExtApp)
            {
                if (!System.IO.Directory.Exists("C:\\Sayban\\TTSPresent"))
                {
                    System.IO.Directory.CreateDirectory("C:\\Sayban\\TTSPresent");
                }
                Main._AddressAction = "C:\\Sayban\\TTSPresent";
            }


            try
            {
				var settingLines = File.ReadAllLines(Utility._SettingsFilePath);


				string sl = settingLines[0];

                string[] s = sl.Split(';');

                bool b = false;
                if(s.Length == 3)
                {

                    if ( Boolean.TryParse(s[0] , out b )) this.checkBox1.Checked = b;

                    this.txtFrequency.Text = s[1];
                    this.txtDuration.Text = s[2];
                }
                sl = settingLines[1];
                this.txtAddress.Text = sl;

                sl = settingLines[2];
                this.txtAbsent.Text = sl;

                sl = settingLines[3];
                this.txtName.Text = sl;


                sl = settingLines[4];

                if (sl != null && sl != "")
                {
                    s = sl.Split(';');

                    if (s.Length == 2)
                    {
                        if (Boolean.TryParse(s[0], out b)) this.chSendActivityToSrv.Checked = b;
                        this.txtIP.Text = s[1];
                    }
                }
                // read last clock position
                sl = settingLines[5];
				this.txtChatPort.Text = settingLines[6];

			}
            catch (Exception ex){

                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(this.folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtAddress.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
