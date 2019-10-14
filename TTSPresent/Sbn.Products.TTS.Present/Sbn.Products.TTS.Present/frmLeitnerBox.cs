using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Sbn.Products.TTS.Present
{

    public partial class frmLeitnerBox : Form
    {
        public frmLeitnerBox()
        {
            InitializeComponent();
        }

        //
/*
        void addNodesToBox1()
        {
            
        //    treeView1.Nodes[0].Nodes.Clear();
            flpSection1_1.Controls.Clear();
            flpSection1_1.Padding = new System.Windows.Forms.Padding(0);
            flpSection1_1.Margin = new System.Windows.Forms.Padding(0);

            var questions = from q in Variables.xDocument.Descendants("Box")
                            where q.Attribute("ID").Value == "1"
                            from p in q.Descendants("Part")
                            where p.Attribute("ID").Value == "1"
                            from c in q.Descendants("Word")
                            select c;
            int i = 1;
            foreach (var question in questions)
            {
                Button l = new  Button ();
                l.Text = "";
                l.AutoSize = true;
                l.FlatStyle = FlatStyle.Popup;
                l.Width = 24;
                l.Image = pictureBox1.Image;
                l.Padding = new System.Windows.Forms.Padding(2);
                l.Margin = new System.Windows.Forms.Padding(0);
                l.Name = "1_1_" + question.FirstAttribute.Value;
                
                l.Click += btnCardClick; 
//                PictureBox pic = new PictureBox();
//                pic.Image = pictureBox1.Image;
                flpSection1_1.Controls.Add(l);

                //treeView1.Nodes[0].Nodes.Add("Word" + question.Attribute("ID").Value, "Question " + i.ToString(), 3, 3);
                i++;
            }
        }
        */
        void btnCardClick(object sender, EventArgs e)
        {
            try
            {
                string[] cardName = ((Button)sender).Name.Split('#');

                var questions = from q in Variables.xDocument.Descendants("Box")
                                where q.Attribute("ID").Value == cardName[0]
                                from p in q.Descendants("Part")
                                where p.Attribute("ID").Value == cardName[1]
                                from c in q.Descendants("Word")
                                where c.Attribute("ID").Value == cardName[2]
                                select c;

                foreach (var question in questions)
                {

                    frmLeitnerCard c = new frmLeitnerCard();
                    c._BoxID = int.Parse(question.Parent.Parent.FirstAttribute.Value);
                    c._PartID = question.Parent.FirstAttribute.Value;
                    c._QuestionID = int.Parse(question.FirstAttribute.Value);
                    c.lblHeader.Text = question.FirstAttribute.NextAttribute.NextAttribute.NextAttribute.Value + " " + question.FirstAttribute.Value;
                    c.txtQ.Text = question.FirstAttribute.NextAttribute.Value;
                    c.txtR.Text = question.FirstAttribute.NextAttribute.NextAttribute.Value;
                    c.label2.Visible = true;
                    c.txtR.Visible = false;
                    c.Show();

                    break;
                }
            }
            catch
            {


            }
        }


        
        void addNodesToBox2_3_4_5(int box)
        {
            try
            {
                List<string> EmptyParts = new List<string>();
                int j = 0;
                for (int i = 1; i <= 5; i++)
                {
                    if (i != box) continue;

                    //i+1 ==> box id
                    //j ==> part numbers
                    if (i == 1) j = 1;
                    else if (i == 2) j = 2;
                    else if (i == 3) j = 4;
                    else if (i == 4) j = 8;
                    else if (i == 5) j = 16;

                    int count = 0;
                    for (int k = 1; k <= j; k++)
                    {

                        var control = null as Control;
                        if (i == 1) control = this.flpSection1_1;
                        if (i == 2 && k == 1) control = this.flpSection2_1;
                        if (i == 2 && k == 2) control = this.flpSection2_2;
                        if (i == 3 && k == 1) control = this.flpSection3_1;
                        if (i == 3 && k == 2) control = this.flpSection3_2;
                        if (i == 3 && k == 3) control = this.flpSection3_3;
                        if (i == 3 && k == 4) control = this.flpSection3_4;

                        if (i == 4 && k == 1) control = this.flpSection4_1;
                        if (i == 4 && k == 2) control = this.flpSection4_2;
                        if (i == 4 && k == 3) control = this.flpSection4_3;
                        if (i == 4 && k == 4) control = this.flpSection4_4;
                        if (i == 4 && k == 5) control = this.flpSection4_5;
                        if (i == 4 && k == 6) control = this.flpSection4_6;
                        if (i == 4 && k == 7) control = this.flpSection4_7;
                        if (i == 4 && k == 8) control = this.flpSection4_8;

                        if (i == 5 && k == 1) control = this.flpSection5_1;
                        if (i == 5 && k == 2) control = this.flpSection5_2;
                        if (i == 5 && k == 3) control = this.flpSection5_3;
                        if (i == 5 && k == 4) control = this.flpSection5_4;
                        if (i == 5 && k == 5) control = this.flpSection5_5;
                        if (i == 5 && k == 6) control = this.flpSection5_6;
                        if (i == 5 && k == 7) control = this.flpSection5_7;
                        if (i == 5 && k == 8) control = this.flpSection5_8;
                        if (i == 5 && k == 9) control = this.flpSection5_9;
                        if (i == 5 && k == 10) control = this.flpSection5_10;
                        if (i == 5 && k == 11) control = this.flpSection5_11;
                        if (i == 5 && k == 12) control = this.flpSection5_12;
                        if (i == 5 && k == 13) control = this.flpSection5_13;
                        if (i == 5 && k == 14) control = this.flpSection5_14;
                        if (i == 5 && k == 15) control = this.flpSection5_15;
                        if (i == 5 && k == 16) control = this.flpSection5_16;


                        control.Controls.Clear();
                        ((FlowLayoutPanel)control).FlowDirection = FlowDirection.TopDown;
                        ((FlowLayoutPanel)control).AutoScroll = true;
                        control.Padding = new System.Windows.Forms.Padding(0);
                        control.Margin = new System.Windows.Forms.Padding(0);

                        var parts = from q in Variables.xDocument.Descendants("Box")
                                    where q.Attribute("ID").Value == i.ToString()
                                    from p in q.Descendants("Part")
                                    select p;
                        int ii = 1;
                        foreach (var part in parts)
                        {
                            if (part.Nodes().Count() == 0)
                            {
                                EmptyParts.Add(part.FirstAttribute.Value.ToString());

                                continue;
                            }

                            if (ii == k)
                            {

                                //treeView1.Nodes[i].Nodes[k - 1].Nodes.Clear();
                                var partQuestions = from q in Variables.xDocument.Descendants("Box")
                                                    where q.Attribute("ID").Value == i.ToString()
                                                    from c in q.Descendants("Part")
                                                    where c.Attribute("ID").Value == part.FirstAttribute.Value.ToString()
                                                    from l in c.Descendants("Word")
                                                    select l;

                                if (part.FirstAttribute.Value.ToString() != "1")
                                {
                                    Label lbl = new Label();
                                    lbl.Text = part.FirstAttribute.Value.ToString().Substring(3);
                                    control.Controls.Add(lbl);
                                }


                                foreach (var question in partQuestions)
                                {
                                    //  treeView1.Nodes[i].Nodes[k - 1].Nodes.Add("Word" + question.Attribute("ID").Value, "Question " + g.ToString(), 3, 3);
                                    Button l = new Button();
                                    l.Text = "";
                                    l.AutoSize = true;
                                    l.FlatStyle = FlatStyle.Popup;
                                    l.Width = 24;
                                    l.Image = pictureBox1.Image;
                                    l.Padding = new System.Windows.Forms.Padding(2);
                                    l.Margin = new System.Windows.Forms.Padding(0);
                                    l.Name = (i).ToString() + "#" + part.FirstAttribute.Value.ToString() + "#" + question.FirstAttribute.Value;

                                    l.Click += btnCardClick;
                                    //                PictureBox pic = new PictureBox();
                                    //                pic.Image = pictureBox1.Image;
                                    control.Controls.Add(l);
                                    count++;
                                }

                                break;
                            }
                            ii++;
                        }
                    }
                    if (i == 1) lblCountP1.Text = count.ToString();
                    else if (i == 2) lblCountP2.Text = "تعداد سوالات : " + count.ToString();
                    else if (i == 3) lblCountP3.Text = "تعداد سوالات : " + count.ToString();
                    else if (i == 4) lblCountP4.Text = "تعداد سوالات : " + count.ToString();
                    else if (i == 5) lblCountP5.Text = "تعداد سوالات : " + count.ToString();

                }


                foreach (string s in EmptyParts)
                {
                    if (box == 1) continue;
                    var destinationElement = (from q in Variables.xDocument.Descendants("Box")
                                              where q.Attribute("ID").Value == box.ToString()
                                              from c in q.Descendants("Part")
                                              where c.Attribute("ID").Value == s
                                              select c).First();
                        
                    destinationElement.Remove();
                    Variables.xDocument.Save(Variables.xmlFileName);
                }
            }
            catch
            {


            }
        }
        
        void loadXML()
        {
            try
            {
                Variables.xDocument = XDocument.Load(Variables.usersFolder + "\\" +  Variables.xmlFileName);

                //string userName = Variables.xmlFileName.Remove(Variables.xmlFileName.LastIndexOf('.'));
                //userName = userName.Replace(Variables.usersFolder, "");
                //userName = userName.Replace("\\", "");
                //this.Text = Variables.title + userName;

               // addNodesToBox1();
               // addNodesToBox2_3_4_5();
             //   ApplySetting();

             //   treeView1.Enabled = tabControl1.Enabled = true;

            //    timer1.Start();
            }
            catch (Exception ex)
            {
           //     StackFrame file_info = new StackFrame(true);
           //     error(ref file_info, ex.Message);
           //     treeView1.Enabled = tabControl1.Enabled = false;
            //    timer1.Stop();
            }
        }

        public static bool deleteFromXMLAndTreeView(string wordID)
        {
            try
            {
                var destinationElement = (from q in Variables.xDocument.Descendants("Word")
                                          where q.Attribute("ID").Value == wordID
                                          select q).First();
                destinationElement.Remove();
                Variables.xDocument.Save(Variables.xmlFileName);
                return true;
            }
            catch (Exception ex)
            {
                StackFrame file_info = new StackFrame(true);
//                error(ref file_info, ex.Message);
                return false;
            }
        }

        public static bool addToXMLAndTreeView(string boxID, string partID, string newQuestion, string newAnswer, string date, bool selectDestinationTreeNode)
        {
            try
            {
                //destinationBox = (from q in Variables.xDocument.Descendants("Box")
                //                  where q.Attribute("ID").Value == "1"
                //                  select q).First();
                //break;


                XElement destinationBox;
                switch (boxID)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                        destinationBox = (from q in Variables.xDocument.Descendants("Box")
                                          where q.Attribute("ID").Value == boxID
                                          from c in q.Descendants("Part")
                                          where c.Attribute("ID").Value == partID
                                          select c).First();
                        break;

                    case "DataBase":
                        destinationBox = (from q in Variables.xDocument.Descendants("DataBase")
                                          select q).First();
                        break;

                    default:
                        throw new Exception("Wrong box id");
                }

                int maxID = 0;
                try
                {
                    maxID = (from q in Variables.xDocument.Descendants("Word")
                             select (int)q.Attribute("ID")).Max();
                }
                catch { }
                maxID++;

                destinationBox.Add(
                        new XElement("Word", new XAttribute("ID", maxID),
                            new XAttribute("Question", newQuestion),
                            new XAttribute("Answer", newAnswer),
                            new XAttribute("Date", date))
                        );

                //Adds a new TreeNode to treeView
                TreeNode destinationTreeNode = new TreeNode();
                if (boxID == "1")
                {
                   // destinationTreeNode = treeView1.Nodes.Find("Box1", false).First();
                    destinationTreeNode.Nodes.Add("Word" + maxID, "Question " + (destinationTreeNode.Nodes.Count + 1).ToString(), 3, 3);
                }
                else if (boxID != "DataBase")
                {
                   // destinationTreeNode = treeView1.Nodes.Find("Box" + boxID + "Part" + partID, true).First();
                    destinationTreeNode.Nodes.Add("Word" + maxID, "Question " + (destinationTreeNode.Nodes.Count + 1).ToString(), 3, 3);
                }
                //\\
                try
                {
                    if (selectDestinationTreeNode && destinationTreeNode != null && boxID != "DataBase")
                    {
                  //      treeView1.CollapseAll();
                  //      treeView1.SelectedNode = treeView1.Nodes.Find("Word" + maxID, true).First();
                    }
                }
                catch { }

                Variables.xDocument.Save(Variables.xmlFileName);
                return true;
            }
            catch (Exception ex)
            {
                StackFrame file_info = new StackFrame(true);
              //  error(ref file_info, ex.Message);
                return false;
            }
        }

        public void RefereshBox(int boxid)
        {
                addNodesToBox2_3_4_5(boxid);
        }
        //

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void frmLeitnerBox_Load(object sender, EventArgs e)
        {
            loadXML();
            RefereshBox(1);
            RefereshBox(2);
            RefereshBox(3);
            RefereshBox(4);
            RefereshBox(5);
            this.flpSection1_1.Refresh();
        }

        private void frmLeitnerBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void lblAdd_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmLeitnerCard frm = new frmLeitnerCard();
            frm.Show();
            frm.lblSave.Visible = true;
            frm.lblOK.Enabled = false;
            frm.lblRemove.Enabled = false;
            frm.label2.Visible = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

                frmLeitnerCard frm = new frmLeitnerCard();
                frm.Show();
                frm.lblSave.Visible = true;
                frm.lblOK.Enabled = false;
                frm.lblRemove.Enabled = false;
                frm.label2.Visible = false;
                frm.from1100Words();

        }
    }
    public static class Variables
    {
        public static XDocument xDocument;
        public static string xmlFileName = "LeitnerBox.xml";
        public static string usersFolder = Main._AddressAction;
        public readonly static string title = "Leitner Box --> ";
    }
}
