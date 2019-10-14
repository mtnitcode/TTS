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
    public partial class frmToDoActions : Form
    {
        public bool _ChangeAction = true;

//        public int _IntervalToNextAction = 0;
        public frmToDoActions()
        {
            InitializeComponent();
            InitialProjects();
        }
        public void InitialAddresses()
        {
            try
            {
                // if (_Projects.Count == 0)
                {

                    var lineCount = 0;
                    System.IO.StreamReader sw = null;
                    sw = new System.IO.StreamReader(Main._AddressAction + "\\Receivers.txt");

                    List<string> lines = File.ReadAllLines(Utility._Receivers).ToList();



                    foreach( string sl in lines)
                    {
                        string address = "";
                        address = sl;
                        if (sl.Split(';').Length >= 2)
                            address = sl.Split(';')[0];

                        this.cmdNames.Items.Add(address);

                    }

                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitialAddresses();
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
                //MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        void SaveToDo()
        {
            try
            {

                if (this.cmdLatestActions.Text == "")
				{
					MessageBox.Show("عنوان فعالیت را تعیین نمایید!" , "هشدار" , MessageBoxButtons.OK , MessageBoxIcon.Warning);
					return;
				}

                DateTime dt0 = DateTime.Now;
                string sDate0 = ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + " " + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00"); // changed by ghmhm 921105

				var action = this.cmdProjects.Text.Replace(";", "") + ";" + this.txtCpmpleteDesc.Text.Replace("\n", "").Replace(";", "") + ";" + this.cmdNames.Text.Replace(";", "") + " " + this.cmdLatestActions.Text.Replace("\n", "").Replace(";", "") + ";"
											+ ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + ";" + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00") + ";;;" + System.Security.Principal.WindowsIdentity.GetCurrent().Name;

				List<string> lines = new List<string>();
				lines.Add(action);
				File.AppendAllLines(Utility._ToDoListFilePath, lines.ToArray());


                if (!_Projects.Contains(this.cmdProjects.Text))
                    _Projects.Insert(0, this.cmdProjects.Text);

                frmSticker frms = new frmSticker();
                frms.lblProject.Text = this.cmdProjects.Text.Replace(";", "");
				frms.lblTitle.Text = this.cmdLatestActions.Text.Replace(";", "");
				frms.txtCompleteDesc.Text = this.txtCpmpleteDesc.Text.Replace("\n", "").Replace(";", "");
                frms.Show();
				Main._Stickers.Add(frms);

                //Main._ToDoChange = true;

                if (this.cmdNames.Text != "")
                {
                    string[] sName = this.cmdNames.Text.Split('/');
                    string sIP = sName[0];

                    TCPClient.SendMessage(sIP, "DefineActivity;#;" + action, int.Parse(Utility._ChatPort));

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + "\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                if (checkBox1.Checked)
                {
                    SendEmail();
                }

            }
            catch
            {

            }

            this.cmdLatestActions.Text = "";
			this.txtCpmpleteDesc.Text = "";


        }

        private void button1_Click(object sender, EventArgs e)
        {

            SaveToDo();
            button3_Click(null, null);

        }

        void SendEmail()
        {
            try
            {

                Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                // Create a new mail item.
                Microsoft.Office.Interop.Outlook.MailItem mailItem = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                mailItem.Subject = this.cmdLatestActions.Text;
                string email = "";

                try
                {
                    System.IO.StreamReader sw = new System.IO.StreamReader(Main._AddressAction + "\\Receivers.txt");

					List<string> lines = File.ReadAllLines(Utility._Receivers).ToList();

                    foreach (string s in lines)
                    {
                        string[] ss = s.Split(';');
                        if (ss.Length >= 2 && ss[0] == this.cmdNames.Text)
                        {

                            email = ss[1];
                            break;
                        }
                    }
                }
                catch
                {

                }

                mailItem.To = email;// "someone@example.com";
                mailItem.Body = this.cmdLatestActions.Text;
//                mailItem.Attachment.Add(logPath);//logPath is a string holding path to the log.txt file
//                mailItem.Importance = Microsoft.Office.Tools.Outlook.OlImportance.olImportanceHigh;
                mailItem.Display(true);
                // Send.
                //mailItem.Send();
                // Clean up.
                mailItem = null;
                oApp = null;
            }
            catch
            {

            }

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

            if (this.Size.Height <= 187)
            {
                this.Height = 590;
            }

            int total = 0;

            var st = Utility.GetToDoActions(out total, 0, this.cmdLatestActions.Text);
            this.bindingSource1.DataSource = null;
            this.bindingSource1.DataSource = st;

        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            form.RightToLeft = RightToLeft.Yes;


            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        public void applyAction(bool delele)
        {
            try
            {
                string sdesc = "";

                if (delele)
                {
                    if (MessageBox.Show("آیا این مورد حذف شود ؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes) return;
                }
                else
                {
                    if (frmToDoActions.InputBox("سوال", "توضیح :", ref sdesc) != System.Windows.Forms.DialogResult.OK) return;

                    //if (MessageBox.Show("آیا این مورد انجام شده است ؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes) return;
                }
                string selectedAction = "";

                selectedAction = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();


                if (!delele)
                {

                    DateTime dt0 = DateTime.Now;
                    string sDate0 = ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + " " + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00"); // changed by ghmhm 921105


					List<string> lines = new List<string>();
					lines.Add(this.cmdProjects.Text + ";" + sdesc.Replace(";", "") + ";" + selectedAction.Replace(";", "") + ";"
								+ ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + ";" + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00") + ";;;" + System.Security.Principal.WindowsIdentity.GetCurrent().Name);

					File.AppendAllLines(Utility._Actions, lines.ToArray());

					if (Main._SendActivityToServer)
                    {
                        TCPClient.SendMessage(Main._ActivityServerIPAddress, "UserActivity;#;" + this.cmdProjects.Text + ";" + sdesc + ";" + selectedAction.Replace(";", "") + ";"
                                + ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + ";" + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00") + ";;;" + System.Security.Principal.WindowsIdentity.GetCurrent().Name, int.Parse(Utility._ChatPort));
                    }

                }



                string[] allLines = File.ReadAllLines(Utility._ToDoListFilePath );
                StringBuilder sb = new StringBuilder();


                foreach (string s in allLines)
                {

                    if (s.Split(';')[2] != selectedAction)
                    {
                        sb.Append(s);

                    }
                }

                File.WriteAllText(Utility._ToDoListFilePath, sb.ToString());

                button3_Click(null, null);


                //

                //
                //Main._ToDoChange = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + "\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void انجامشدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyAction(false);
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyAction(true);

        }

        private void ثبتیادآوریToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmReminder frm = new frmReminder();
                frm.txtReminder.Text = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                frm.Show();
            }
            catch
            {

            }
        }

        private void ثبتفعالیتروزانهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                
                Main.frm.cmdProjects.Text = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString(); ;
                Main.frm.cmdLatestActions.Text = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                Main.frm.txtDescription.Text = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
				Main.frm.Show();
                Main._SecondsPass = 0;
            }
            catch
            {

            }
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

		private void cmdLatestActions_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
