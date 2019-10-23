using Gma.UserActivityMonitor;
using Khendys.Controls;
using Sbn.Controls.FDate.Utils;
using Sbn.Libs.TCPListener;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Sbn.Controls.EventCalendar;

namespace Sbn.Products.TTS.Present
{

    /*
    public sealed class KeyboardHook : IDisposable
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        // Unregisters the hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        // Registers a hot key with Windows.

        /// <summary>
        /// Represents the window that is used internally to get the messages.
        /// </summary>
        private class Window : NativeWindow, IDisposable
        {
            private static int WM_HOTKEY = 0x0312;

            public Window()
            {
                // create the handle for the window.
                this.CreateHandle(new CreateParams());
            }

            /// <summary>
            /// Overridden to get the notifications.
            /// </summary>
            /// <param name="m"></param>
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                // check if we got a hot key pressed.
                if (m.Msg == WM_HOTKEY)
                {
                    // get the keys.
                    Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                    ModifierKeys modifier = (ModifierKeys)((int)m.LParam & 0xFFFF);

                    // invoke the event to notify the parent.
                    if (KeyPressed != null)
                        KeyPressed(this, new KeyPressedEventArgs(modifier, key));
                }
            }

            public event EventHandler<KeyPressedEventArgs> KeyPressed;

            #region IDisposable Members

            public void Dispose()
            {
                this.DestroyHandle();
            }

            #endregion
        }

        private Window _window = new Window();
        private int _currentId;

        public KeyboardHook()
        {
            // register the event of the inner native window.
            _window.KeyPressed += delegate(object sender, KeyPressedEventArgs args)
            {
                if (KeyPressed != null)
                    KeyPressed(this, args);
            };
        }

        /// <summary>
        /// Registers a hot key in the system.
        /// </summary>
        /// <param name="modifier">The modifiers that are associated with the hot key.</param>
        /// <param name="key">The key itself that is associated with the hot key.</param>
        public void RegisterHotKey(ModifierKeys modifier, Keys key)
        {
            // increment the counter.
            _currentId = _currentId + 1;

            // register the hot key.
            if (!RegisterHotKey(_window.Handle, _currentId, (uint)modifier, (uint)key))
                throw new InvalidOperationException("Couldn’t register the hot key.");
        }

        /// <summary>
        /// A hot key has been pressed.
        /// </summary>
        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        #region IDisposable Members

        public void Dispose()
        {
            // unregister all the registered hot keys.
            for (int i = _currentId; i > 0; i--)
            {
                UnregisterHotKey(_window.Handle, i);
            }

            // dispose the inner native window.
            _window.Dispose();
        }

        #endregion
    }
    
    
    /// <summary>
    /// Event Args for the event that is fired after the hot key has been pressed.
    /// </summary>
  
    
    public class KeyPressedEventArgs : EventArgs
    {
        private ModifierKeys _modifier;
        private Keys _key;

        internal KeyPressedEventArgs(ModifierKeys modifier, Keys key)
        {
            _modifier = modifier;
            _key = key;
        }

        public ModifierKeys Modifier
        {
            get { return _modifier; }
        }

        public Keys Key
        {
            get { return _key; }
        }
    }
    
    /// <summary>
    /// The enumeration of possible modifiers.
    /// </summary>
    //[Flags]

    
    void hook_KeyPressed(object sender, KeyPressedEventArgs e)
    {
        // show the keys pressed in a label.
        //label1.Text = e.Modifier.ToString() + " + " + e.Key.ToString();
    }*/

    public delegate void FireAliveClient(List<string> ips);

    public partial class Main : Form
    {
        //public event EventHandler<KeyPressedEventArgs> KeyPressed;

        public static event FireAliveClient AliveClient;


        //
        public const int MOD_ALT = 0x0001;
        public const int MOD_CONTROL = 0x0002;
        public const int MOD_SHIFT = 0x004;
        public const int MOD_NOREPEAT = 0x400;
        public const int WM_HOTKEY = 0x312;
        public const int DSIX = 0x36;

        //

        public static string _LocalIPAddress = "";

        bool _Beep = false;
        int _Fre = 2000;
        int _Due = 500;
        string _AbsentTime = "";
        public static string _Name = "";
        public static bool _SendActivityToServer = false;

        public static string _ActivityServerIPAddress = "";

        public static Point _clockPosition = new Point();

        public static bool _ToDoChange = false;

        public static string _AddressAction = "";

        

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        //[DllImport("user32.dll")]
        //public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        bool isProcessLoged = true;
        public static Thread _thread = null;
        public static bool _callFromExtApp = false;

        public Main()
        {
           // KeyboardHook hook = new KeyboardHook();

           Application.AddMessageFilter(new MyFilter());
           if (!Main.RegisterHotKey(IntPtr.Zero, 1, MOD_CONTROL, (int)ConsoleKey.F1))
           {

           }
           if (!Main.RegisterHotKey(IntPtr.Zero, 1, MOD_CONTROL, (int)ConsoleKey.F2))
           {

           }
           if (!Main.RegisterHotKey(IntPtr.Zero, 1, MOD_CONTROL, (int)ConsoleKey.F3))
           {

           }
//           if (!Main.RegisterHotKey(IntPtr.Zero, 1, MOD_CONTROL, (int)ConsoleKey.F4))
           {

           }

            InitializeComponent();

			try
            {

                //System.IO.StreamReader sw = null;

                if (Main._callFromExtApp)
                {
                    if (!System.IO.Directory.Exists("C:\\Sayban\\TTSPresent"))
                    {
                        System.IO.Directory.CreateDirectory("C:\\Sayban\\TTSPresent");
                    }
                    Main._AddressAction = "C:\\Sayban\\TTSPresent";
					Utility._SettingsFilePath = "C:\\Sayban\\TTSPresent\\Settings.txt";
                }
                else
                {
                    Main._AddressAction = Application.StartupPath;
					Utility._SettingsFilePath = Application.StartupPath + "\\Settings.txt";
                }

				var settingLines = File.ReadAllLines(Utility._SettingsFilePath);

                string sl = "";

                string[] s = settingLines[0].Split(';');

                _Beep = Boolean.Parse(s[0]);
                _Fre = int.Parse(s[1]);
                _Due = int.Parse(s[2]);

                sl = settingLines[1];

                if (sl != "")
                    Main._AddressAction = sl;
                else if (!Main._callFromExtApp)
                    Main._AddressAction = Application.StartupPath;

                sl = settingLines[2];

                sl = settingLines[3];
                if (sl != "")
                    Main._Name = sl;

                sl = settingLines[4];
                s = sl.Split(';');

                _SendActivityToServer = Boolean.Parse(s[0]);
                _ActivityServerIPAddress = s[1];

                // get last clock position
                sl = settingLines[5];
                try
                {
                    s = sl.Split(';');
                    Main._clockPosition.X = int.Parse(s[0]);
                    Main._clockPosition.Y = int.Parse(s[1]);
                }
                catch { }

				Utility._ChatPort = settingLines[6];


            }
            catch (Exception ex)
            {
                 MessageBox.Show("بروز خطا در فراخوانی فایل تنظیمات", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
				//Application.ExitThread();
				//Application.Exit();
				//throw;
            }

			Utility._ToDoListFilePath = Main._AddressAction + "\\ToDoActions.txt";
			Utility._ProjectFilePath = Main._AddressAction + "\\Projects.txt";
			Utility._DailyActivities = Main._AddressAction + "\\DailyActivities.txt";
			Utility._Actions = Main._AddressAction + "\\Actions.txt";
			Utility._Receivers = Main._AddressAction + "\\Receivers.txt";

			Main.frmClck.analogClock3.ContextMenuStrip = this.contextMenuStrip1;

            try
            {
                System.Net.IPAddress[] ips = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName());
                foreach(System.Net.IPAddress ipa in ips)
                {
                    int dots = ipa.ToString().Split('.').Length;
                    if(dots == 4)
                    {
                        _LocalIPAddress = ipa.ToString();

                    }
                    //string sip = "";
                    //if (ips.Length > 1)
                    //{
                    //    sip = ips[1].ToString();
                    //}
                    //else
                    //{
                    //    sip = ips[0].ToString();
                    //}
                }

                //_LocalIPAddress = sip;

                TCPListener.ReceivedData += TCPListener_ReceivedData;

                TCPListener._ClientName = _Name;

                TCPListener.StartListener(_LocalIPAddress, int.Parse(Utility._ChatPort), global::Sbn.Products.TTS.Present.Properties.Settings.Default.IsVisibleForAll);
                if (!global::Sbn.Products.TTS.Present.Properties.Settings.Default.EnableNewChat)
                    this.درحالبازیابیToolStripMenuItem.Visible= false;

                //
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            try
            {
                this.بهروزرسانیToolStripMenuItem.Enabled = false;
                _thread = new Thread(new ThreadStart(CheckOtherClients));
                _thread.Start();
            }
            catch
            {
                MessageBox.Show("اشکال در بازیابی  فهرست مخاطبان!");
                _thread.Abort();
                _thread = null;

            }


            frm = new Form1();

            try
            {
                HookManager.KeyDown += HookManager_KeyDown;
                HookManager.MouseMove += HookManager_MouseMove;
            }
            catch(Exception ex)
            {
                isProcessLoged = false;
              //  MessageBox.Show("امکان رویدانگاری صحیح کارکرد نرم افزارهای شما  در این سیستم وجود ندارد !");
            }

            InitialToDoActions();

        // register the event that is fired after the key press.
    //    hook.KeyPressed +=
    //        new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
        // register the control + alt + F12 combination as hot key.
     //   hook.RegisterHotKey( Present.ModifierKeys.Control| Present.ModifierKeys.Shift,Keys.F12);
        }

        void item_Click(object sender, EventArgs e)
        {
            string name = ((ToolStripItem)sender).Text.Split('/')[1];
            string ip = ((ToolStripItem)sender).Text.Split('/')[0];

            bool fFind = false;
            foreach (frmChat f in _ChatForms)
            {
                if (f._ReceiverIPAddress == ip)
                {
                    if (!f.Visible) f.Show();

                    f.rtBox_Main.SelectionStart = f.rtBox_Main.Text.Length;
                    f.rtBox_Main.ScrollToCaret();

                    fFind = true;
                    f.Show();
                    f.Activate();

                }
            }

            if (!fFind)
            {
                frmChat frmCH = new frmChat();

                frmCH._ReceiverIPAddress = ip;
                frmCH.cmdNames.Text = ip + "/" + name;
                frmCH.Text = ip + "/" + name;
                frmCH.cmdNames.Enabled = false;
                frmCH.Show();

                _ChatForms.Add(frmCH);
            }

            //frmChat f = new frmChat();
            //_ChatForms.Add(f);
            //f.cmdNames.Text = ((ToolStripItem)sender).Text;
            //f._ReceiverIPAddress = ((ToolStripItem)sender).Text.Split('/')[0];
            //f.cmdNames.Enabled = false;

            //f.Show();
        }

        List<string> _ReceivedDatas = new List<string>();

        void TCPListener_ReceivedData(object data)
        {

            _ReceivedDatas.Add((string)data);

        }

        void HookManager_KeyDown(object sender, KeyEventArgs e)
        {
            Utility._LastMovetime = 0;
        }

        void HookManager_MouseMove(object sender, MouseEventArgs e)
        {
             Utility._LastMovetime = 0;
            //throw new NotImplementedException();
        }
		public static List<frmSticker> _Stickers = new List<frmSticker>();

		public void InitialToDoActions()
        {
            try
            {
//                if (_Projects.Count == 0)
                {

                    List<string> names = new List<string>();
                    foreach (object item in this.tsmnuToDoList.DropDownItems)
                    {
                        if (item is ToolStripDropDownItem)
                        {
                            if (((ToolStripDropDownItem)item).Name.StartsWith("ToDo") )
                            {
                                names.Add(((ToolStripDropDownItem)item).Name);
                            }
                        }

                    }
                    
                    foreach(string s in names)
                        this.tsmnuToDoList.DropDownItems.RemoveByKey(s);

                    var lines = File.ReadAllLines(Utility._ToDoListFilePath);
					/*
                    List<string> Projects = new List<string>();
                    lines.Reverse();
                    foreach (string s in lines)
                    {
                        string[] ss = s.Split(';');


                        if (ss[2] != "" && !Projects.Contains(ss[0] + ";" + ss[2]))
                        {
                            //if(ss[2].Length > 50)
                            //    Projects.Add(ss[0] + ";" + ss[2].Substring(0,50));
                            //else
                                Projects.Add(ss[0] + ";" + ss[2]);

                        }
                    }
					*/
                    Rectangle r = Screen.PrimaryScreen.WorkingArea;
                    int fCount = 0;
                    int h = 0;
                    //int it = 0;
                    int indent = 0;
                    foreach (string s in lines)
                    {
                        string[] ss = s.Split(';');

                        //var tiToDo = new ToolStripMenuItem();
                        //tiToDo.Text = s;
                        //tiToDo.Name = "ToDo" + s;

                        //tiToDo.Click += tiToDo_Click;
                        //this.tsmnuToDoList.DropDownItems.Add(tiToDo);
                        frmSticker frms = new frmSticker();
                        frms.Text = ss[0];
                        frms.lblProject.Text = ss[0];
                        frms.lblTitle.Text = ss[2];
						frms.txtCompleteDesc.Text = ss[1];

                        if(fCount* frms.Width + frms.Width + indent > r.Width)
                        {
                            fCount = 0;
                            h++;
                            if (indent == 0) indent = 100;
                            else indent = 0;

                        }

                        frms.Show();
						_Stickers.Add(frms);

						frms.Left = indent+ fCount * frms.Width + fCount*2;
                        frms.Top = h * frms.Height;

                        fCount++;
                        
                    }
                }

                Main._ToDoChange = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        void tiToDo_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("آیا مایل به ثبت این مورد در فعالیتهای روزانه می باشید؟", "سوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string pn = ((ToolStripItem)sender).Text.Split(';')[0];
                    string sa = ((ToolStripItem)sender).Text.Split(';')[1];

                    Main.frm.cmdProjects.Text = pn;
                    Main.frm.cmdLatestActions.Text = sa;
                    Main.frm.Show();
                }

            }
            catch
            {

            }

            
        }

        public static int _SecondsPass = 0;
        int _CheckActiveProcess = 0;
        public int _IntervalToNextAction = 0;

        public static Form1 frm ;//= new Form1();

        bool SaveUsersActivity(string data)
        {
            try
            {
                System.IO.StreamWriter sw = System.IO.File.AppendText(Main._AddressAction + "\\UsersActivity.txt");

                sw.WriteLine(data);

                sw.Close();

                return true;
            }
            catch (Exception ex)
            {
//                MessageBox.Show(ex.StackTrace + "\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public static List<string> _TempAliveClient = new List<string>();
        public static List<string> _AliveClient = new List<string>();
        public static bool _EndOfProcessNetwork = false;
        void CheckOtherClients()
        {
            try
            {
                Main._EndOfProcessNetwork = false;

                //List<string> Clients = new List<string>();
                string[] ips = Main._LocalIPAddress.Split('.');
                for (int i = 1; i <= 255; i++)
                {
                    if (ips[3] == i.ToString()) continue;
                    string ip = ips[0] + "." + ips[1] + "." + ips[2] + "." + i.ToString();
                    System.Net.Sockets.Socket sock = null;
                    try
                    {
                        sock = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);

                        IAsyncResult result = sock.BeginConnect(ip,int.Parse( Utility._ChatPort), null, null);

                        bool success = result.AsyncWaitHandle.WaitOne(300, true);
                        //sock.Connect(System.Net.IPAddress.Parse(ip), 13000);
                        //if (sock.Connected)
                        //{
                        //    // Port is in use and connection is successful
                        //    MessageBox.Show("Port is Closed");
                        //}
                        //System.Net.Sockets.TcpClient cl = new System.Net.Sockets.TcpClient();
                        //cl.Connect(System.Net.IPAddress.Parse(ip), 13000);
                        if (success)
                        {
                            sock.Disconnect(false);
                            sock.Close();

                            //sock.SendTimeout = 500;
                            //sock.Send(Encoding.Default.GetBytes("Alive?"), System.Net.Sockets.SocketFlags.None);
                            //byte[] b = new byte[1024];
                            //string s = Encoding.Default.GetString(b);
                            //sock.Receive(b);

                            string ss = TCPClient.SendMessage(ip, "Alive?" , int.Parse(Utility._ChatPort));
                            if (ss.Contains("Alive"))
                            {
                                string[] sp = new string[1];

                                sp[0] = ";#;";

                                string[] sData = ss.Split(sp, StringSplitOptions.None);
                                Main._TempAliveClient.Add(ip + "/" + sData[1]);
                                //this.tspmChat.DropDownItems.Add(ip + "/" + sData[1]);
                                sock.Close();

                            }
                        }
                        else
                            sock.Close();

                        /*
                        System.Net.Sockets.Socket sock = new System.Net.Sockets.Socket(addressFamily: System.Net.Sockets.AddressFamily.InterNetwork, socketType: System.Net.Sockets.SocketType.Dgram, protocolType: System.Net.Sockets.ProtocolType.Udp);
                        System.Net.IPEndPoint rep = new System.Net.IPEndPoint(System.Net.IPAddress.Parse(ip), 13000);

                        sock.Bind(rep);
                        System.Net.EndPoint ep = (System.Net.EndPoint)rep;
                        byte[] data = new byte[1024];
                        int recv = sock.ReceiveFrom(data, ref ep);

                        string s = TCPClient.SendMessage(ip, "Alive?");
                        if (s.Contains("?Alive"))
                        {
                            string[] sp = new string[1];

                            sp[0] = ";#;";

                            string[] sData = s.Split(sp, StringSplitOptions.None);
                            this.cmdNames.Items.Add(ip + "/" + sData[1]);
                        }*/
                    }
                    catch
                    {
                        sock.Close();

                    }

                }

                //Main._TempAliveClient = Clients;
                Main._EndOfProcessNetwork = true;

            }
            catch (Exception ex)
            {
                Main._EndOfProcessNetwork = true;

            }
            finally
            {
                _thread.Abort();
                _thread = null;
            }

        }
        int _autoSavePassed = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
            try
            {

                if(Main._ToDoChange)
                {

                 //   InitialToDoActions();

                }

                if (Main._TempAliveClient.Count > 0)
                {
                    //this.tspmChat.DropDownItems.Clear();
                    _thread.Abort();

                    List<string> names = new List<string>();
                    foreach (object item in this.tspmChat.DropDownItems)
                    {
                        if (item is ToolStripDropDownItem)
                        {
                            if (((ToolStripDropDownItem)item).Name.StartsWith("Rec"))
                            {
                                names.Add(((ToolStripDropDownItem)item).Name);
                            }
                        }
                    }

                    foreach (string sn in names)
                        this.tspmChat.DropDownItems.RemoveByKey(sn);

                    foreach (string s in Main._TempAliveClient)
                    {
                        try
                        {


                            if (s != Main._LocalIPAddress + "/" + Main._Name)
                            {

                                var item = new ToolStripMenuItem();
                                item.Name = "Rec" + s;
                                item.Text = s;

                                this.tspmChat.DropDownItems.Add(item);

                                //item.Name = "Rec" + s;

                                Main._AliveClient.Add(s);
                                item.Click += item_Click;

                                TCPClient.SendMessage(s.Split('/')[0], "AliveStatus;#;On;#;" + Main._LocalIPAddress + "/" + Main._Name, int.Parse(Utility._ChatPort));
                            }
                        }
                        catch
                        {

                        }
                    }

                    Main._TempAliveClient.Clear();
                }
                else
                {
                    if (Main._EndOfProcessNetwork) this.بهروزرسانیToolStripMenuItem.Enabled = true;

                }
            }
            catch
            {
                MessageBox.Show("اشکال در بازیابی  فهرست مخاطبان!");
            }
            
            try
            {
                if (isProcessLoged)
                    Utility._LastMovetime++;

                CheckReminder();

                if (_CheckActiveProcess++ >= 10)
                {
                    Utility.LogActiveProcess();
                    _CheckActiveProcess = 0;
                }

                if (!frm._Stoped && _SecondsPass <= frm._IntervalToNextAction && global::Sbn.Products.TTS.Present.Properties.Settings.Default.AutoTrace)
                {
                    Main.frmClck.progressBar1.Maximum = frm._IntervalToNextAction + 1;
                    Main.frmClck.progressBar1.Value = _SecondsPass;
                    _SecondsPass++;

                }


                
                {
                    if (!frm._Stoped && global::Sbn.Products.TTS.Present.Properties.Settings.Default.AutoTrace)
                    {
                        if (_SecondsPass >= frm._IntervalToNextAction)
                        {

                            try
                            {
                                if (!frm.Visible)
                                {
                                    this.notifyIcon1.ShowBalloonTip(1000, "تعیین فعالیت", "فعالیت کنونی خود را تعیین نمایید.", ToolTipIcon.Info);
                                    if (_Beep) Console.Beep(_Fre, _Due);
                                    //Main.frm.cmdLatestActions.Enabled = true;
                                    frm.Height = 202;
                                    frm.Show();

                                    Main.frm.WindowState = FormWindowState.Normal;
                                    frm.Activate();
                                    //frm.InitialProjects();
                                    frm.timer1.Start();
                                }
                                _SecondsPass = 0;
                            }
                            catch
                            {
                                _SecondsPass = 0;
                            }
                        }

                        if (_autoSavePassed++ >= 600)
                        {
                            _autoSavePassed = 0;
                            Main.frm.SaveActivity();
                        }
                    }

                }

                //
                while (_ReceivedDatas.Count > 0)
                {

                    try
                    {
                        string[] sp = new string[1];
                        sp[0] = ";#;";
                        string[] sData = _ReceivedDatas[0].Split(sp, StringSplitOptions.None);

                        if (sData[0] == "UserActivity")
                        {
                            if (sData.Length > 1) SaveUsersActivity(sData[1]);
                        }
                        else if (sData[0] == "AliveStatus")
                        {

                            this.notifyIcon1.ShowBalloonTip(1000, "پیام", "یک مخاطب جدید !.\n" + sData[2], ToolTipIcon.Info);

                            if (sData[1] == "On")
                            {
                                if (!Main._AliveClient.Contains(sData[2]))
                                {

                                    var item = new ToolStripMenuItem();
                                    item.Name = "Rec" + sData[2];
                                    item.Text = sData[2];
                                    this.tspmChat.DropDownItems.Add(item);
                                    Main._AliveClient.Add(sData[2]);
                                    item.Click += item_Click;
                                }

                            }
                        }
                        else if (sData[0] == "DefineActivity")
                        {
                            this.notifyIcon1.ShowBalloonTip(1000, "پیام", "یک فعالیت جدید برای شما !.\n" + sData[1], ToolTipIcon.Info);

                            DateTime dt0 = DateTime.Now;
                            string sDate0 = ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + " " + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00"); // changed by ghmhm 921105

                            System.IO.StreamWriter sw = System.IO.File.AppendText(Utility._ToDoListFilePath);
                            //                System.IO.StreamWriter sw = new System.IO.StreamWriter();
                            if (sData.Length > 1)
                                sw.WriteLine(sData[1]);

                            sw.Close();

                        }
                        else
                        {
                            this.notifyIcon1.ShowBalloonTip(1000, "پیام", "شما پیامهای جدیدی دارید!.", ToolTipIcon.Info);

                            bool fFind = false;
                            foreach (frmChat f in _ChatForms)
                            {
                                if (f._ReceiverIPAddress == sData[0])
                                {
                                    f.rtBox_Main.SelectionStart = f.rtBox_Main.Text.Length;
                                    f.rtBox_Main.ScrollToCaret();

                                    if (sData[2].StartsWith("Attach"))
                                    {
                                        ShowImageInChat(sData, f);

                                    }
                                    else if (sData[2].StartsWith("Emot"))
                                    {

                                        var sem = sData[2].Split('=')[1];
                                        int c = 0;
                                        foreach (string s in f.semoticons)
                                        {
                                            if (s == sem)
                                                f.rtBox_Main.InsertImage(f.emoticons[c]);
                                            c++;
                                        }

                                    }
                                    else
                                    {
                                        f.rtBox_Main.InsertTextAsRtf("\n" );
                                        f.rtBox_Main.InsertTextAsRtf(sData[2] , new Font(this.Font, FontStyle.Bold | FontStyle.Underline), RtfColor.Blue, RtfColor.White);
                                        f.rtBox_Main.InsertTextAsRtf("\n");
                                        //f.rtBox_Main.Text += "\n" + sData[2] + "\n";
                                        //f.rtBox_Main.SelectionStart = f.txtDialogues.Text.Length;
                                    }

                                    f.TopMost = true;
                                    if (!f.Visible) f.Show();

                                    fFind = true;
                                    f.WindowState = FormWindowState.Normal;
                                    
                                    //f.Show();
                                    f.TopMost = false;
                                    //f.Activate();

                                }
                            }

                            if (!fFind)
                            {
                                frmChat frmCH = new frmChat();

                                frmCH._ReceiverIPAddress = sData[0];
                                frmCH.cmdNames.Text = sData[0] + "/" + sData[1];
                                frmCH.Text = sData[0] + "/" + sData[1];

                                frmCH.cmdNames.Enabled = false;
                                frmCH.TopMost = true;
                                frmCH.Show();
                                frmCH.rtBox_Main.SelectionStart = frmCH.rtBox_Main.Text.Length;
                                frmCH.rtBox_Main.ScrollToCaret();

                                if (sData[2].StartsWith("Attach"))
                                {
                                    ShowImageInChat(sData, frmCH);

                                }
                                else if (sData[2].StartsWith("Emot"))
                                {
                                    var sem = sData[2].Split('=')[1];
                                    int c = 0;
                                    foreach (string s in frmCH.semoticons)
                                    {
                                        if (s == sem)
                                            frmCH.rtBox_Main.InsertImage(frmCH.emoticons[c]);
                                        c++;
                                    }
                                }
                                else
                                {
                                    frmCH.rtBox_Main.InsertTextAsRtf("\n" + sData[2] + "\n", new Font(this.Font, FontStyle.Bold | FontStyle.Underline), RtfColor.Blue, RtfColor.Yellow);
                                }

                                _ChatForms.Add(frmCH);
                                frmCH.TopMost = false;

                            }   
                        }
                    }
                    catch
                    {

                    }
                    _ReceivedDatas.RemoveAt(0);
                }
            }
            catch(Exception ex)
            {
				MessageBox.Show(ex.StackTrace + "\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			//
			this.timer1.Start();
        }

        private void ShowImageInChat(string[] sData, frmChat f)
        {
            string s = sData[2].Split('=')[1];
            f.rtBox_Main.SelectionStart = f.rtBox_Main.Text.Length;
            f.rtBox_Main.ScrollToCaret();
            f.rtBox_Main.InsertTextAsRtf("\n");

            List<string> ex = new List<string> { ".jpg", ".png", ".bmp" };
            if (ex.Contains(Path.GetExtension(s).ToLower()))
            {

                using (var bmp = Bitmap.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\Attachments\\" + Path.GetFileName(s)))
                {
                    if (bmp.Size.Width > f.rtBox_Main.Width - 50)
                    {
                        float wscale = ((f.rtBox_Main.Width - 50) / (float)bmp.Size.Width) * bmp.Size.Width;

                        float hscale = ((f.rtBox_Main.Width - 50) / (float)bmp.Size.Width) * bmp.Size.Height;
                        Image thumb = bmp.GetThumbnailImage((int)wscale, (int)hscale, ThumbnailCallback, IntPtr.Zero);

                        f.rtBox_Main.InsertImage(thumb);
                    }
                    else
                        f.rtBox_Main.InsertImage(bmp);

                }
            }

            //f.rtBox_Main.InsertTextAsRtf("\n");
            f.rtBox_Main.InsertTextAsRtf("\n");

            f.rtBox_Main.InsertLink(AppDomain.CurrentDomain.BaseDirectory + "\\Attachments\\" + Path.GetFileName(s));
            f.rtBox_Main.InsertTextAsRtf("\n");

            //f.rtBox_Main.InsertTextAsRtf("\n");

        }

        public bool ThumbnailCallback()
        {
            return false;
        }
        static List<string> _Displayed = new List<string>();
        private void CheckReminder()
        {

            try
            {

				if (ReminderVars.xDocument == null)
					ReminderVars.xDocument = XDocument.Load(Main._AddressAction + "\\" + ReminderVars.xmlFileName);

				//this.cmdProjects.Text, this.txtReminder.Text, this.txtDescription.Text, this.chRepeate.Checked, this.chCalculateTime.Checked, sDate0, sEDate0


				var Appointments = new List<Appointment>();

				System.DateTime dt0 = System.DateTime.Now;
				string sDate0 = ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + " " + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00"); // changed by ghmhm 921105

				var appointments = from q in ReminderVars.xDocument.Descendants("Appointment")
								   where q.Attribute("startDate").Value.Contains(((Sbn.Controls.FDate.Utils.PersianDate)dt0).Year.ToString("####0000") + "/" + ((Sbn.Controls.FDate.Utils.PersianDate)dt0).Month.ToString("##00"))
								   //from c in q.Descendants("Appointment")
								   select q;

				foreach (var appoint in appointments)
				{
					var app = new Appointment();

					var d = PersianDateConverter.ToGregorianDate(PersianDate.Parse(appoint.Attribute("startDate").Value, true));

					app.StartDate = new MyDateTime(System.DateTime.Parse(d));

					//    if (((Sbn.Controls.FDate.Utils.PersianDate)dt0).Month != app.StartDate.Month)
					//        OldReminders.Add(s);

					if (appoint.Attribute("title").Value == "جلسه")
						app.BorderColor = Color.Red;
					if (appoint.Attribute("title").Value == "فعالیت روزانه")
						app.BorderColor = Color.Violet;
					if (appoint.Attribute("title").Value == "یادآوری")
						app.BorderColor = Color.Yellow;
					if (appoint.Attribute("title").Value == "قرارملاقات")
						app.BorderColor = Color.Orange;

					if (appoint.Attribute("endDate").Value != "")
					{
						d = PersianDateConverter.ToGregorianDate(PersianDate.Parse(appoint.Attribute("endDate").Value, true));
						app.EndDate = new MyDateTime(System.DateTime.Parse(d));
					}
					else
						app.EndDate = app.StartDate.AddMinutes(15);

					app.Title = appoint.Attribute("title").Value;


					app.ID = long.Parse(appoint.Attribute("ID").Value);
					app.Subject = appoint.Attribute("project").Value;
					app.AutoStart = bool.Parse(appoint.Attribute("isautostart").Value); 
					app.Description = appoint.Attribute("description").Value;
					//app.d = appoint.Attribute("project").Value

					Appointments.Add(app);
				}
			    foreach(Appointment a in Appointments)
				{
					if (((Sbn.Controls.FDate.Utils.PersianDate)dt0).Day == a.StartDate.Day &&
												dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":00" == a.StartDate.Hour.ToString("##00") + ":" + a.StartDate.Minute.ToString("##00") + ":00")
					{
						if (!_Displayed.Contains(a.StartDate.Minute.ToString("##00") + ":" + a.StartDate.Minute.ToString("##00") + ":00"))
						{
							frmReminderMessage frms = new frmReminderMessage();
							//frms.Text = a.Title;

							frms.lblProject.Text = a.Subject.ToString();
							frms.lblDesc.Text = a.Title;
							frms.txtCompleteDesc.Text = a.Description; 
							frms.Show();

							_Displayed.Add(a.StartDate.Minute.ToString("##00") + ":" + a.StartDate.Minute.ToString("##00") + ":00");

							if (a.AutoStart)
							{
								Main.frm.cmdProjects.Text = a.Subject;
								Main.frm.cmdLatestActions.Text = a.Title;
								Main.frm.currentActivity = a.Title;
								Main.frm.currentProject = a.Subject;
								Main.frm.txtDescription.Text = a.Description;
								Main.frm.Show();
								Main.frm.SaveActivity();
								this.notifyIcon1.ShowBalloonTip(1000, "تغییر فعالیت", "فعالیت شما تغییر پیدا کرد.", ToolTipIcon.Info);
								_SecondsPass = 0;
							}

							this.notifyIcon1.ShowBalloonTip(2000, "یادآوری",a.Title, ToolTipIcon.Info);
						}
					}
				}
			
                //
                if (File.Exists(Main._AddressAction + "\\RepeatReminder.txt"))
                {
                    int lineCount = File.ReadAllLines(Main._AddressAction + "\\RepeatReminder.txt").Length;

                    var sw = new System.IO.StreamReader(Main._AddressAction + "\\RepeatReminder.txt");

                    List<string> lines = new List<string>();

                    int l = 0;
                    if (lineCount >= 1000)
                    {
                        for (int i = 0; i < lineCount - 1000; i++)
                        {
                            sw.ReadLine();
                        }
                    }

                    while (!sw.EndOfStream)
                    {
                        string sl = sw.ReadLine();

                        lines.Add(sl);
                    }

                    sw.Close();

                    lines.Reverse();
                    foreach (string s in lines)
                    {
                        string[] ss = s.Split(';');
                        string sdate = ss[1];
                        string stime = ss[2];

                        if (dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":00" == stime)
                        {
                            if (!_Displayed.Contains(stime))
                            {
                                frmReminderMessage frms = new  frmReminderMessage ();
                                frms.Text = ss[4];

                                frms.lblProject.Text = ss[4];
                                frms.lblDesc.Text = ss[0]; 
                                
                                frms.Show();

                                _Displayed.Add(stime);
                                if (ss.Length >= 5)
                                {
                                    if (ss[3] == "True")
                                    {
                                        Main.frm.cmdProjects.Text = ss[4];
                                        Main.frm.cmdLatestActions.Text = ss[0];
                                        Main.frm.currentActivity = ss[0];
                                        Main.frm.currentProject = ss[4];
                                        Main.frm.Show();
                                        Main.frm.SaveActivity();
                                        this.notifyIcon1.ShowBalloonTip(1000, "تغییر فعالیت", "فعالیت شما تغییر پیدا کرد.", ToolTipIcon.Info);
                                        _SecondsPass = 0;

                                    }
                                }

                                this.notifyIcon1.ShowBalloonTip(2000, "یادآوری", ss[0], ToolTipIcon.Info);

                            }
                        }
                    }
                    //
                }
				
            }
            catch
			{

			}
            
        }

        public void StopThreads()
        {
            this.timer1.Stop();
            Main.frm.SaveActivity();

            TCPListener.StopListener(_LocalIPAddress);
            if (_thread.ThreadState != ThreadState.Aborted)
            {
                _thread.Abort();
            }
            if (_thread != null)
                _thread.Abort();

            _thread = null;

        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("آیا خارج می شوید؟", "سوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
				try
				{
					this.timer1.Stop();
					Main.frm.SaveActivity();
					StopThreads();
				}
				catch
				{

				}

                this.Dispose();
				Application.Exit();

			}
        }

        private void تعیینفعالیتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmNewAction frmN = new frmNewAction();
				frmN.TopMost = true;
				frmN.Show();
				frmN.BringToFront();
            }
            catch
            {

            }
        }

        public static frmMonth _frmMonth = new frmMonth();

        private void یاداوریToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if(!_frmMonth.Visible)
                _frmMonth.Show();
			_frmMonth.BringToFront();


		}

        private void تنظیماتپیشفرضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();
            frm.Show();
        }

        private void تغییرفعالیتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main.frm.InitialProjects();
            if (!Main.frm.Visible)
                Main.frm.Show();
			Main.frm.BringToFront();

		}

        private void کارکردنرمافزارهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProcessStatistics frm = new FrmProcessStatistics();
            frm.Show();
        }

        private void کارهایدردستانجامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmToDoActions frm = new frmToDoActions();
			frm.TopMost = true;
            frm.Show();
			frm.BringToFront();



		}

        private void Main_Load(object sender, EventArgs e)
        {

        }

        List<frmChat> _ChatForms = new List<frmChat>();
        private void اتاقگفتگوToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            List<string> Clients = new List<string>();
            string[] ips = Main._LocalIPAddress.Split('.');
            List<string> names = new List<string>();
            foreach (object item in this.tspmChat.DropDownItems)
            {
                if (item is ToolStripDropDownItem)
                {
                    if (((ToolStripDropDownItem)item).Name.StartsWith("Rec"))
                    {
                        System.Net.Sockets.Socket sock = null;

                        try
                        {

                            sock = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);

                            string ip = ((ToolStripDropDownItem)item).Name.Split('/')[0].Substring(3);

                            IAsyncResult result = sock.BeginConnect(ip, 13000, null, null);

                            bool success = result.AsyncWaitHandle.WaitOne(300, true);

                            if (success)
                            {

                            }
                            else
                                names.Add(((ToolStripDropDownItem)item).Name);

                            sock.Close();
                        }
                        catch
                        {
                            sock.Close();
                        }
                    }
                }
            }

            foreach (string sn in names)
                this.tspmChat.DropDownItems.RemoveByKey(sn);
            */
        }
        public static frmClock frmClck = new frmClock();
        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
        }


        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (Main.frmClck.Visible)
                    Main.frmClck.Hide();
                else
                {
					if (frm != null)
					{
						Main.frmClck.lblShowActivity.Text = frm.currentActivity;
						Main.frmClck.Show();
						Main.frmClck.Top = Main._clockPosition.Y;
						Main.frmClck.Left = Main._clockPosition.X;
					}


                }
            }
        }

        private void درحالبازیابیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChat frm = new frmChat();
            _ChatForms.Add(frm);
            frm.Show();
        }

        private void مشاهدهToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void تماسهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReceivers frm1 = new frmReceivers();
            frm1.Show();
        }

        private void بهروزرسانیToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.بهروزرسانیToolStripMenuItem.Enabled = false;


            _thread = new Thread(new ThreadStart(CheckOtherClients));
            _thread.Start();
        }

        private void تهیهنسخهپشتیبانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime dt0 = DateTime.Now;
                string sDate0 = ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d").Replace("/", "-") + "-" + dt0.Hour.ToString("##00") + "-" + dt0.Minute.ToString("##00"); 

                System.IO.Directory.CreateDirectory(Main._AddressAction + "\\" + sDate0);
                if (File.Exists(Main._AddressAction + "\\actions.txt")) System.IO.File.Copy(Main._AddressAction + "\\actions.txt", Main._AddressAction + "\\" + sDate0 + "\\" + "Actions.txt", true);
                if (File.Exists(Main._AddressAction + "\\DailyActivities.txt")) System.IO.File.Copy(Main._AddressAction + "\\DailyActivities.txt", Main._AddressAction + "\\" + sDate0 + "\\" + "DailyActivities.txt", true);
                if(File.Exists(Main._AddressAction + "\\Contacts.txt")) System.IO.File.Copy(Main._AddressAction + "\\Contacts.txt", Main._AddressAction + "\\" + sDate0 + "\\" + "Contacts.txt", true);
                if (File.Exists(Main._AddressAction + "\\Projects.txt")) System.IO.File.Copy(Main._AddressAction + "\\Projects.txt", Main._AddressAction + "\\" + sDate0 + "\\" + "Projects.txt", true);
                if (File.Exists(Main._AddressAction + "\\ToDoActions.txt")) System.IO.File.Copy(Main._AddressAction + "\\ToDoActions.txt", Main._AddressAction + "\\" + sDate0 + "\\" + "ToDoActions.txt", true);
                if (File.Exists(Main._AddressAction + "\\Reminder.xml")) System.IO.File.Copy(Main._AddressAction + "\\Reminder.xml", Main._AddressAction + "\\" + sDate0 + "\\" + "Reminder.xml", true);
                if (File.Exists(Main._AddressAction + "\\LeitnerBox.xml")) System.IO.File.Copy(Main._AddressAction + "\\LeitnerBox.xml", Main._AddressAction + "\\" + sDate0 + "\\" + "LeitnerBox.xml", true);
                
                MessageBox.Show("نسخه پشتیبان تهیه شد!");
            }
            catch
            {
            }
        }

        public static frmLeitnerBox frmL = null;
        private void جعبهلایتنرToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (frmL == null)
            {
                frmL = new frmLeitnerBox();
                frmL.Show();
            }

            if (!frmL.Visible) frmL.Visible = true;
        }

    }

    class MyFilter : IMessageFilter
    {
        public const int WM_HOTKEY = 0x312;

        private const int WH_MOUSE = 7;

        private const int WH_MOUSE_LL = 14;

        /// <summary>
        /// Installs a hook procedure that monitors keystroke messages. For more information, see the KeyboardProc hook procedure. 
        /// </summary>
        private const int WH_KEYBOARD = 2;

        /// <summary>
        /// The WM_MOUSEMOVE message is posted to a window when the cursor moves. 
        /// </summary>
        private const int WM_MOUSEMOVE = 0x200;

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {


                //if (m.LParam == (IntPtr)7536642)
                //{
                //    // Take action here

                //    frmToDoActions frm = new  frmToDoActions ();
                //    frm.InitialProjects();
                //    frm.ShowDialog();
                //}
                if (m.LParam == (IntPtr)7340034)
                {
                    // Take action here
                    frmNewAction frm = new frmNewAction();
                    frm.InitialProjects();
					frm.TopMost = true;
					frm.Show();
                }
                else if (m.LParam == (IntPtr)7405570)
                {
                    frmToDoActions frm = new frmToDoActions();
                    frm.InitialProjects();
					frm.TopMost = true;
                    frm.Show();
                }
                else if (m.LParam == (IntPtr)7471106)
                {
                    Main.frm.InitialProjects();
                    if (!Main.frm.Visible)
                        Main.frm.Show();
                }
                return true;
            }

            return false;
        }
    }
}
