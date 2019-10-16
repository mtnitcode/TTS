using Khendys.Controls;
using Sbn.Controls.FDate.Utils;
using Sbn.Libs.TCPListener;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using static Khendys.Controls.ExRichTextBox;

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
        public Image[] emoticons;
        public string[] semoticons = new string[9];

        private void frmChat_Load(object sender, EventArgs e)
        {
            
            string[] sName = this.cmdNames.Text.Split('/');
            string sIP = sName[0];
            _ReceiverIPAddress = sIP;

            // Load Emoticon Images
            emoticons = new Image[9];
            emoticons[0] = new Bitmap( TTS.Present.Properties.Resources.AngelSmile);
            semoticons[0] = "AngelSmile";
            emoticons[1] = new Bitmap(TTS.Present.Properties.Resources.AngrySmile);
            semoticons[1] = "AngrySmile";
            emoticons[2] = new Bitmap(TTS.Present.Properties.Resources.Beer);
            semoticons[2] = "Beer";
            emoticons[3] = new Bitmap(TTS.Present.Properties.Resources.BrokenHeart);
            semoticons[3] = "BrokenHeart";
            emoticons[4] = new Bitmap(TTS.Present.Properties.Resources.ConfusedSmile);
            semoticons[4] = "ConfusedSmile";
            emoticons[5] = new Bitmap(TTS.Present.Properties.Resources.CrySmile);
            semoticons[5] = "CrySmile";
            emoticons[6] = new Bitmap(TTS.Present.Properties.Resources.DevilSmile);
            semoticons[6] = "DevilSmile";
            emoticons[7] = new Bitmap(TTS.Present.Properties.Resources.EmbarassedSmile);
            semoticons[7] = "EmbarassedSmile";
            emoticons[8] = new Bitmap(TTS.Present.Properties.Resources.ThumbsUp);
            semoticons[8] = "ThumbsUp";


            // Create Emoticon DropDownMenu
            EmoticonMenuItem _menuItem;
            int _count = 0;
            foreach (Image _emoticon in emoticons)
            {
                _menuItem = new EmoticonMenuItem(_emoticon);
                _menuItem.Name = semoticons[_count];
                _menuItem.Click += new EventHandler(cmenu_Emoticons_Click);
                if (_count % 3 == 0)
                    _menuItem.BarBreak = true;

                cmenu_Emoticons.MenuItems.Add(_menuItem);
                ++_count;
            }

        }
        // When an emoticon is clicked, insert its image into to RTF
        private void cmenu_Emoticons_Click(object _sender, EventArgs _args)
        {
            EmoticonMenuItem _item = (EmoticonMenuItem)_sender;
            try
            {
                TCPClient.SendMessage(_ReceiverIPAddress, Main._LocalIPAddress + ";#;" + Main._Name + ";#;" + "Emot=" + ((EmoticonMenuItem)_sender).Name, int.Parse(Utility._ChatPort));
                //SendTCP(s, _ReceiverIPAddress, int.Parse(Utility._ChatPort));

                rtBox_Main.InsertImage(_item.Image);

            }
            catch (Exception _e)
            {
                MessageBox.Show("Rtf Image Insert Error\n\n" + _e.ToString()) ;
            }
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

                rtBox_Main.ScrollToCaret();

                rtBox_Main.InsertTextAsRtf("\n");
                rtBox_Main.InsertTextAsRtf( this.txtText.Text , new Font(this.Font, FontStyle.Regular), RtfColor.Black, RtfColor.White);
                rtBox_Main.InsertTextAsRtf("\n");


                this.txtText.Text = "";

                rtBox_Main.ScrollToCaret();
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

                string[] sss = this.rtBox_Main.Text.Split('\n');
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
            this.rtBox_Main.Text = "";
            this.Hide();
        }
        public bool ThumbnailCallback()
        {
            return false;
        }
        private void rtBox_Main_OnDroped(object sender, EventArgs e)
        {
            var ls = ((DropEventArgs)e).Lines;

            foreach (string s in ls)
            {

                List<string> ex =new List<string>  { ".jpg", ".png"  , ".bmp"};
                var exte = Path.GetExtension(s);

                if (ex.Contains(exte))
                {

                    using (var bmp = Bitmap.FromFile(s))
                    {
                        if (bmp.Size.Width > this.rtBox_Main.Width - 50)
                        {

                            float wscale = ((this.rtBox_Main.Width - 50) / (float)bmp.Size.Width) * bmp.Size.Width;

                            float hscale = ((this.rtBox_Main.Width - 50) / (float)bmp.Size.Width) * bmp.Size.Height;
                            Image thumb = bmp.GetThumbnailImage((int)wscale, (int)hscale, ThumbnailCallback, IntPtr.Zero);

                            rtBox_Main.InsertImage(thumb);
                            //

                            TCPClient.SendMessage(_ReceiverIPAddress, Main._LocalIPAddress + ";#;" + Main._Name + ";#;" + "Attach=" + s, int.Parse(Utility._ChatPort));
                            SendTCP(s, _ReceiverIPAddress, int.Parse(Utility._ChatPort));
                            //
                        }
                        else
                            rtBox_Main.InsertImage(bmp);
                    }


                    //rtBox_Main.Text+= "\n";
                    rtBox_Main.InsertLink(s);
                    //rtBox_Main.Text += "\n";

                    //  rtBox_Main.InsertTextAsRtf("\n");

                }
                else
                {
                    TCPClient.SendMessage(_ReceiverIPAddress, Main._LocalIPAddress + ";#;" + Main._Name + ";#;" + "Attach=" + s, int.Parse(Utility._ChatPort));
                    SendTCP(s, _ReceiverIPAddress, int.Parse(Utility._ChatPort));

                    rtBox_Main.InsertLink(s);

                    //rtBox_Main.Text += "\n";

                }
            }
        }
        public void SendTCP(string M, string IPA, Int32 PortN)
        {
            byte[] SendingBuffer = null;
            TcpClient client = null;
            
            NetworkStream netstream = null;
            try
            {
                int BufferSize = 1024;
                client = new TcpClient(IPA, PortN);
                netstream = client.GetStream();
                FileStream Fs = new FileStream(M, FileMode.Open, FileAccess.Read);
                int NoOfPackets = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Fs.Length) / Convert.ToDouble(BufferSize)));
                //progressBar1.Maximum = NoOfPackets;
                int TotalLength = (int)Fs.Length, CurrentPacketLength, counter = 0;
                for (int i = 0; i < NoOfPackets; i++)
                {
                    if (TotalLength > BufferSize)
                    {
                        CurrentPacketLength = BufferSize;
                        TotalLength = TotalLength - CurrentPacketLength;
                    }
                    else
                        CurrentPacketLength = TotalLength;
                    SendingBuffer = new byte[CurrentPacketLength];
                    Fs.Read(SendingBuffer, 0, CurrentPacketLength);
                    netstream.Write(SendingBuffer, 0, (int)SendingBuffer.Length);

                    //if (progressBar1.Value >= progressBar1.Maximum)
                    //    progressBar1.Value = progressBar1.Minimum;
                    //progressBar1.PerformStep();
                }

                Fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                netstream.Close();
                client.Close();

            }
        }

        private void rtBox_Main_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                Process.Start(e.LinkText.Replace("\\\\", "\\").Replace("\\\\", "\\").Replace("\\\\", "\\"));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    public class EmoticonMenuItem : MenuItem
    {

        private const int ICON_WIDTH = 19;
        private const int ICON_HEIGHT = 19;
        private const int ICON_MARGIN = 4;
        private Color backgroundColor, selectionColor, selectionBorderColor;
        private Image image;
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        public EmoticonMenuItem()
        {
            this.OwnerDraw = true;
            backgroundColor = SystemColors.ControlLightLight;
            selectionColor = Color.FromArgb(50, 0, 0, 150);
            selectionBorderColor = SystemColors.Highlight;
        }

        public EmoticonMenuItem(Image _image) : this()
        {
            image = _image;
        }

        protected override void OnMeasureItem(MeasureItemEventArgs _args)
        {
            _args.ItemWidth = ICON_WIDTH + ICON_MARGIN;
            _args.ItemHeight = ICON_HEIGHT + 2 * ICON_MARGIN;
        }

        protected override void OnDrawItem(DrawItemEventArgs _args)
        {
            Graphics _graphics = _args.Graphics;
            Rectangle _bounds = _args.Bounds;

            DrawBackground(_graphics, _bounds, ((_args.State & DrawItemState.Selected) != 0));
            _graphics.DrawImage(image, _bounds.X + ((_bounds.Width - ICON_WIDTH) / 2), _bounds.Y + ((_bounds.Height - ICON_HEIGHT) / 2));
        }

        private void DrawBackground(Graphics _graphics, Rectangle _bounds, bool _selected)
        {
            if (_selected)
            {
                _graphics.FillRectangle(new SolidBrush(selectionColor), _bounds);
                _graphics.DrawRectangle(new Pen(selectionBorderColor), _bounds.X, _bounds.Y,
                    _bounds.Width - 1, _bounds.Height - 1);
            }
            else
            {
                _graphics.FillRectangle(new SolidBrush(backgroundColor), _bounds);
            }
        }
    }

}
