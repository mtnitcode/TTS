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
    public partial class frmReceivers : Form
    {
        public frmReceivers()
        {
            InitializeComponent();
        }

        private void frmReceivers_Load(object sender, EventArgs e)
        {
            try
            {
                System.IO.StreamReader sw = new System.IO.StreamReader(Main._AddressAction + "\\Receivers.txt");

                List<string> lines = new List<string>();


                int l = 0;
                /*
                if (lineCount >= 1000)
                {
                    for (int i = 0; i < lineCount - 1000; i++)
                    {
                        sw.ReadLine();
                    }
                }
                */
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
                    if (ss.Length >= 2)
                        email = ss[1];

                    ip = ss[0].Split('/')[0];

                    string name = "";
                    if (ss[0].Split('/').Length >= 2)
                        name = ss[0].Split('/')[1];


                    this.dataGridView1.Rows.Add(ip, name, email);

                    ActionSt.Add(new { IP = ip, Desc = name, Email = email });

                }
            }
            catch { }
            //this.bindingSource1.DataSource = Utility.GetReceivers();
           // this.dataGridView1.DataSource = Utility.GetReceivers();

        }

        void applyAction(bool delele)
        {
            try
            {

               // string selectedAction = "";

               // selectedAction = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                StringBuilder sb = new StringBuilder();

                foreach(DataGridViewRow row in this.dataGridView1.Rows)
                {
//                    if (row.Cells[0].Value != null && row.Cells[1].Value != null && row.Cells[0].Value != null)
                    {
                        string ip = (row.Cells[0].Value == null ) ? "" : row.Cells[0].Value.ToString ();
                        string name = (row.Cells[1].Value == null) ? "" : row.Cells[1].Value.ToString();
                        string email = (row.Cells[2].Value == null) ? "" : row.Cells[2].Value.ToString();

                        sb.Append(ip + "/" + name + ";" + email + "\r\n");
                    }

                }

                File.WriteAllText(Utility._Receivers, sb.ToString());

                MessageBox.Show("فهرست تماسها ذخیر شد.", "پیام", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + "\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            applyAction(false);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
//            this.dataGridView1.Rows.Add();

//            this.dataGridView1.DataSource = null;

            var list = (List<object>)this.dataGridView1.DataSource;

            list.Add(new { IP = "", Desc = "", Email = "" });

            this.dataGridView1.DataSource = list;
            this.dataGridView1.Refresh();

            /*
            this.dataGridView1.DataSource = this.bindingSource1;
            */

        }

        private void button1_Click(object sender, EventArgs e)
        {
            applyAction(false);
            this.Dispose();
        }

    }
}
