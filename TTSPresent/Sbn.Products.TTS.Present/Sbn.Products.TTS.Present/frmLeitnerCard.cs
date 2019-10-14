using Sbn.Libs.TCPListener;
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
    public partial class frmLeitnerCard : Form
    {
        public frmLeitnerCard()
        {
            InitializeComponent();
        }


        Point firstPoint = new Point();

        public int _BoxID = 0;
        public string _PartID = "";
        public int _QuestionID = 0;

        private void frmSticker_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void frmSticker_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void frmSticker_MouseLeave(object sender, EventArgs e)
        {

        }

        private void frmSticker_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        void nextCard()
        {
            try
            {
                var questions = from q in Variables.xDocument.Descendants("Box")
                                where q.Attribute("ID").Value == _BoxID.ToString()
                                from p in q.Descendants("Part")
                                where p.Attribute("ID").Value == _PartID.ToString()
                                from c in p.Descendants("Word")
                                select c;

                //if (questions == null) return;

                foreach (var question in questions)
                {
                    frmLeitnerCard c = new frmLeitnerCard();
                    c._BoxID = _BoxID;
                    c._PartID = _PartID.ToString();
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
            catch { }

        }
        private void lblOK_Click(object sender, EventArgs e)
        {
            DateTime dt0 = DateTime.Now;
            string curday = ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d").Replace("/", "-").Substring(2);

            if (_BoxID == 5)
            {

                var destinationBox = (from q in Variables.xDocument.Descendants("DataBase")
                                  select q).First();

                frmLeitnerBox.deleteFromXMLAndTreeView(_QuestionID.ToString());

                destinationBox.Add(
                        new XElement("Word", new XAttribute("ID", _QuestionID),
                            new XAttribute("Question", this.txtQ.Text),
                            new XAttribute("Answer", this.txtR.Text),
                            new XAttribute("Date", curday))
                        );
                Variables.xDocument.Save(Variables.xmlFileName);
                Main.frmL.RefereshBox(_BoxID);

                nextCard();

                this.Dispose();
                return;
            }

            var parts = from q in Variables.xDocument.Descendants("Box")
                        where q.Attribute("ID").Value == (_BoxID + 1).ToString()
                        from p in q.Descendants("Part")
                        select p;
            int i = 0;
            bool fullBox = true;

            foreach (var part in parts)
            {
                if (part.FirstAttribute.Value == curday)
                {
                    fullBox = false;

                    break;
                }
                i++;
            }
            int maxPartCount = 2;

            switch (_BoxID)
            {
                case 1:
                    {
                        maxPartCount = 2;
                    }
                    break;
                case 2:
                    {
                        maxPartCount = 4;
                    }
                    break;
                case 3:
                    {
                        maxPartCount = 8;
                    }
                    break;
                case 4:
                    {
                        maxPartCount = 16;
                    }
                    break;
                case 5:
                    {
                    }
                    break;

            }
            if (!fullBox)
            {
                frmLeitnerBox.addToXMLAndTreeView((_BoxID + 1).ToString(), curday, this.txtQ.Text, this.txtR.Text, curday, false);
                frmLeitnerBox.deleteFromXMLAndTreeView(_QuestionID.ToString());
            }
            else if (fullBox && i > maxPartCount-1)
            {
                MessageBox.Show("ابتدا قدیمی ترین قسمت از خانه بعدی جعبه را خالی نمایید!");
            }
            else if (i < maxPartCount)
            {
                var destinationBox = (from q in Variables.xDocument.Descendants("Box")
                                      where q.Attribute("ID").Value == (_BoxID + 1).ToString()
                                      select q).First();

                destinationBox.Add(new XElement("Part", new XAttribute("ID", curday)));

                frmLeitnerBox.addToXMLAndTreeView((_BoxID + 1).ToString(), curday, this.txtQ.Text, this.txtR.Text, curday, false);
                frmLeitnerBox.deleteFromXMLAndTreeView(_QuestionID.ToString());

            }
            else
            {
                MessageBox.Show("اشکال در جاگذاری کارت!");

            }
            Main.frmL.RefereshBox(_BoxID);
            Main.frmL.RefereshBox(_BoxID + 1);
            //Main.frmL.RefereshBox(2);
            nextCard();
            this.Dispose();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            DateTime dt0 = DateTime.Now;
            string curday = ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d").Replace("/", "-").Substring(2);

            frmLeitnerBox.addToXMLAndTreeView("1", "1", this.txtQ.Text, this.txtR.Text, curday, false);
            frmLeitnerBox.deleteFromXMLAndTreeView(_QuestionID.ToString());

            Main.frmL.RefereshBox(1);
            Main.frmL.RefereshBox(_BoxID );

            nextCard();

            this.Dispose();

        }

        private void lblActivity_Click(object sender, EventArgs e)
        {
            try
            {

                this.Dispose();
            }
            catch
            {

            }
        }

        private void lblDesc_MouseUp(object sender, MouseEventArgs e)
        {
            
            Main._clockPosition.Y = this.Top;
            Main._clockPosition.X = this.Left;
        }

        private void lblDesc_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // Get the difference between the two points
                int xDiff = firstPoint.X - e.Location.X;
                int yDiff = firstPoint.Y - e.Location.Y;

                // Set the new point
                int x = this.Location.X - xDiff;
                int y = this.Location.Y - yDiff;
                this.Location = new Point(x, y);
            }
        }

        private void lblDesc_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;

        }

        private void lblProject_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // Get the difference between the two points
                int xDiff = firstPoint.X - e.Location.X;
                int yDiff = firstPoint.Y - e.Location.Y;

                // Set the new point
                int x = this.Location.X - xDiff;
                int y = this.Location.Y - yDiff;
                this.Location = new Point(x, y);
            }
        }

        private void lblProject_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;

        }

        private void lblProject_MouseUp(object sender, MouseEventArgs e)
        {
            Main._clockPosition.Y = this.Top;
            Main._clockPosition.X = this.Left;

        }

        private void lblAdd_Click(object sender, EventArgs e)
        {
            frmLeitnerCard frmc = new frmLeitnerCard();
            frmc.lblSave.Visible = true;
            frmc.lblOK.Enabled = false;
            frmc.lblRemove.Enabled = false;

            frmc.Show();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            this.txtR.Visible = true;
        }
        private void lblSave_Click(object sender, EventArgs e)
        {



            DateTime dt0 = DateTime.Now;
            string curday = ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d").Replace("/", "-").Substring(2);

            if (frmLeitnerBox.addToXMLAndTreeView("1", "1", txtQ.Text, txtR.Text, curday, false))
            {
                if (question != null && MessageBox.Show("این سوال از مبداء حذف گردد ؟", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    question.Remove();
                    Variables.xDocument.Save(Variables.xmlFileName);
                }

                Main.frmL.RefereshBox(1);
                this.Dispose();
            }
        }


        private void label1_MouseUp(object sender, MouseEventArgs e)
        {

            Main._clockPosition.Y = this.Top;
            Main._clockPosition.X = this.Left;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // Get the difference between the two points
                int xDiff = firstPoint.X - e.Location.X;
                int yDiff = firstPoint.Y - e.Location.Y;

                // Set the new point
                int x = this.Location.X - xDiff;
                int y = this.Location.Y - yDiff;
                this.Location = new Point(x, y);
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;

        }


        private void frmLeitnerCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Dispose();
        }


        XElement question = null;

        public void from1100Words()
        {
            question = (from q in Variables.xDocument.Descendants("Words1100")
                            from c in q.Descendants("Word1100")
                            select c).First();


            txtQ.Text = question.FirstAttribute.Value;
            txtR.Text = question.FirstAttribute.NextAttribute.Value;


        }

    }
}
