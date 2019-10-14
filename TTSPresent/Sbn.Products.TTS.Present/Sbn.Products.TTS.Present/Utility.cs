using Sbn.Controls.FDate.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Sbn.Products.TTS.Present
{
    public class Action
    {
        public string ProjectName;
        public string ActionName;
        public float SumOfTime;
        public string Time;
    }
    public class TTSProcess
    {
        private string ProcessName1;

        public string ProcessName
        {
            get { return ProcessName1; }
            set { ProcessName1 = value; }
        }
        private string WindowTitle1;

        public string WindowTitle
        {
            get { return WindowTitle1; }
            set { WindowTitle1 = value; }
        }
        private int SumOfTime1;

        public int SumOfTime
        {
            get { return SumOfTime1; }
            set { SumOfTime1 = value; }
        }
    }

    public class Utility
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        private static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        public static int _LastMovetime = 0;

		
		public static string _ToDoListFilePath = "";
		public static string _ProjectFilePath = "";
		public static string _DailyActivities = "";
		public static string _Actions = "";
		public static string _Receivers = "";
		public static string _SettingsFilePath = "";

		public static string _ChatPort = "";
		public static void LogActiveProcess()
        {

            try
            {

                if (_LastMovetime >= 60) return;

                IntPtr hwnd = GetForegroundWindow();

                uint processID;

                GetWindowThreadProcessId(hwnd, out processID);

                //GetWindowThreadProcessId(hwnd, out processID);

                Process prc = Process.GetProcessById((int)processID);

                if (prc != null)
                {
                    DateTime dt0 = DateTime.Now;

                    System.IO.StreamWriter sw = System.IO.File.AppendText(Main._AddressAction + "\\Processes.txt");
                    //                System.IO.StreamWriter sw = new System.IO.StreamWriter();
                    sw.WriteLine(prc.ProcessName + ";" + prc.MainWindowTitle + ";" + ((Sbn.Controls.FDate.Utils.PersianDate)dt0).ToString("d") + ";" + dt0.Hour.ToString("##00") + ":" + dt0.Minute.ToString("##00") + ":" + dt0.Second.ToString("##00") + ";" + System.Security.Principal.WindowsIdentity.GetCurrent().Name);

                    sw.Close();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + "\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static List<TTSProcess> MakeProcessStatistic(string Month,out int total, List<string> Processes , int day = 0 )
        {

            try
            {
                total = 0;
                List<TTSProcess> ActionsStatistic = new List<TTSProcess>();

                // if (Main.frm._Projects.Count > 0)
                {

                    var lineCount = File.ReadAllLines(Main._AddressAction + "\\Processes.txt").Length;

                    System.IO.StreamReader sw = new System.IO.StreamReader(Main._AddressAction + "\\Processes.txt");

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


                    //lines.Reverse();

                    string[] preAction = null;

                    foreach (string s in lines)
                    {
                        try
                        {
                            string[] ss = s.Split(';');

                        if (int.Parse(Month) != int.Parse(ss[2].Split('/')[1])) continue;
                        if (day != 0 && day != int.Parse(ss[2].Split('/')[2])) continue;

                        int min = 0;

                            if (preAction != null && preAction[1] != "" && preAction[1] == ss[1])
                            {
                                PersianDate pd = new PersianDate(preAction[2] + " " + preAction[3]);
                                DateTime dStart = (DateTime)pd;

                                PersianDate pd2 = new PersianDate(ss[2] + " " + ss[3]);
                                DateTime dEnd = (DateTime)pd2;

                                double dif = dEnd.Subtract(dStart).TotalSeconds;

                                min = (int)dif;
                                total += min;
                                var Prcess = ActionsStatistic.Find(x => x.ProcessName == preAction[0] && x.WindowTitle == preAction[1]) as TTSProcess;

                                if (Prcess != null)
                                {

                                    Prcess.SumOfTime += min;

                                }
                                else
                                {
                                    var prc = new TTSProcess { ProcessName = preAction[0], WindowTitle = preAction[1], SumOfTime = min };
                                    ActionsStatistic.Add(prc);

                                }
                            }
                        }
                        catch { }
//                        if (ss[1] != "")
                        preAction = s.Split(';');
                    }


                    List<TTSProcess> ActionsStatistic1 = new List<TTSProcess>();

                    if (Processes != null && Processes.Count > 0)
                    {
                        total = 0;
                        foreach(TTSProcess p in ActionsStatistic)
                        {
                            if (Processes.Count > 0)
                            {
                                foreach (string s in Processes)
                                {
                                    if (s == p.WindowTitle)
                                    {
                                        var Prcess = ActionsStatistic1.Find(x => x.ProcessName == p.ProcessName && x.WindowTitle == p.WindowTitle) as TTSProcess;
                                        if (Prcess == null)
                                        {
                                            ActionsStatistic1.Add(p);
                                            total += p.SumOfTime;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ActionsStatistic1.Add(p);
                                total += p.SumOfTime;
                            }
                        }
                        return ActionsStatistic1;
                    }
                    return ActionsStatistic;
                    /*
                    List<object> ActionSt = new List<object>();

                    if (ActionsStatistic.Count > 0)
                    {

                        foreach (TTSProcess act in ActionsStatistic)
                        {
                            ActionSt.Add(new { ProcessName = act.ProcessName, WindowTitle = act.WindowTitle , SumOfTime = act.SumOfTime });
                        }

                        return ActionSt;
                    }
                     * */
                }

                return new List<TTSProcess>();

                //                this.bindingSource1.DataSource = _Queue;

            }
            catch { }
            total = 0;
            return null;

        }

        public static List<object> MakeActivityStatistic(string Month,string projectname, int day = 0)
        {

            try
            {

                //total = 0;

                List<Action> ActionsStatistic = new List<Action>();

                // if (Main.frm._Projects.Count > 0)
                {

					var lines = File.ReadAllLines(Utility._DailyActivities).ToList();

					string[] preAction = null;

                    foreach (string s in lines)
                    {
                        string[] ss = s.Split(';');

                        if (int.Parse(Month) != int.Parse(ss[3].Split('/')[1])) continue;
                        if (day != 0 && day != int.Parse(ss[3].Split('/')[2])) continue;

                        float min = 0;
                        try
                        {

                            if (preAction != null)
                            {
                                if (projectname == preAction[0])
                                {

                                    if (preAction[3] == ss[3])
                                    {
                                        PersianDate pd = new PersianDate(preAction[3] + " " + preAction[4]);
                                        DateTime dStart = (DateTime)pd;

                                        PersianDate pd2 = new PersianDate(ss[3] + " " + ss[4]);
                                        DateTime dEnd = (DateTime)pd2;

                                        double dif = dEnd.Subtract(dStart).TotalMinutes;

                                        min = (float)Math.Round( dif , 3);
                                        //total += min;
                                    }
                                    //else
                                    {
                                        //min = int.Parse(ss[4].Split(':')[1]);
                                    }

                                    var act = ActionsStatistic.Find(x => x.ProjectName == preAction[1]) as Action;

                                    if (act == null)
                                    {
                                        act = new Action { ProjectName = preAction[1], SumOfTime = min };
                                        ActionsStatistic.Add(act);
                                    }
                                    else
                                        act.SumOfTime += min;

                                }
                                else
                                {
                                    //min = int.Parse(ss[4].Split(':')[1]);
                                }
                            }

                        }
                        catch { }
                        if (ss[1] != "")
                            preAction = s.Split(';');
                    }

                    List<object> ActionSt = new List<object>();

                    if (ActionsStatistic.Count > 0)
                    {

                        foreach (Action act in ActionsStatistic)
                        {
                            ActionSt.Add(new { ProjectName = act.ProjectName, SumOfTime = act.SumOfTime });

                        }

                        return ActionSt;
                    }
                }

                return new List<object>();

                //                this.bindingSource1.DataSource = _Queue;

            }
            catch { }
            //total = 0;
            return null;

        }

        public static List<object> MakeActionStatistic(string Month, out float total, int day = 0)
        {

            try
            {

                total = 0;

                List<Action> ActionsStatistic = new List<Action>();

                // if (Main.frm._Projects.Count > 0)
                {


					List<string> lines = File.ReadAllLines(Utility._DailyActivities).ToList();

                    string[] preAction = null;

                    foreach (string s in lines)
                    {
                        string[] ss = s.Split(';');

                        if (int.Parse(Month) != int.Parse(ss[3].Split('/')[1])) continue;
                        if (day != 0 && day != int.Parse(ss[3].Split('/')[2])) continue;

                        float min = 0;
                        try
                        {

                            if (preAction != null)
                            {
                                if (preAction[3] == ss[3])
                                {
                                    PersianDate pd = new PersianDate(preAction[3] + " " + preAction[4]);
                                    DateTime dStart = (DateTime)pd;

                                    PersianDate pd2 = new PersianDate(ss[3] + " " + ss[4]);
                                    DateTime dEnd = (DateTime)pd2;

                                    double dif = dEnd.Subtract(dStart).TotalMinutes;

                                    min = (float)Math.Round( dif , 3);

                                    if (preAction[0] != "توقف کار")
                                        total += min;
                                }
                                //else
                                {
                                    //min = int.Parse(ss[4].Split(':')[1]);
                                }

                                var act = ActionsStatistic.Find(x => x.ProjectName == preAction[0]) as Action;

                                if (act == null)
                                {
                                    act = new Action { ProjectName = preAction[0], SumOfTime = min };
                                    ActionsStatistic.Add(act);
                                }
                                else
                                    act.SumOfTime += min;

                            }
                            else
                            {
                                //min = int.Parse(ss[4].Split(':')[1]);
                            }


                        }
                        catch { }
                        if (ss[1] != "")
                            preAction = s.Split(';');
                    }

                    List<object> ActionSt = new List<object>();

                    if (ActionsStatistic.Count > 0)
                    {

                        foreach (Action act in ActionsStatistic)
                        {
                            ActionSt.Add(new { ProjectName = act.ProjectName, SumOfTime = (float) Math.Round( act.SumOfTime , 3) });

                        }

                        return ActionSt;
                    }
                }

                return new List<object>();

                //                this.bindingSource1.DataSource = _Queue;

            }
            catch { }
            total = 0;
            return null;

        }


		public static List<string> GetProjects()
		{
			try
			{
				var lineCount = File.ReadAllLines(Utility._ProjectFilePath).Length;


				List<string> lines = File.ReadAllLines(Utility._ProjectFilePath).ToList();
				return lines;
			}
			catch
			{

			}
			return null;
		}

        public static List<object> GetActions(string Month, out int total, int day = 0, string sAction = "")
        {
            try
            {

                total = 0;

                List<Action> ActionsStatistic = new List<Action>();

                // if (Main.frm._Projects.Count > 0)
                {
					List<string> lines = File.ReadAllLines(Utility._Actions).ToList();

                    lines.Reverse();

                    List<object> ActionSt = new List<object>();

                    foreach (string s in lines)
                    {
                            string[] ss = s.Split(';');
                        try
                        {
                            if (ss.Length < 5) continue;
                            if (int.Parse(Month) != int.Parse(ss[3].Split('/')[1]) && sAction == "") continue;
                            // if (day != 0 && day != int.Parse(ss[3].Split('/')[2])) continue;

                            if (sAction == "" && ss[2] != "") //&& ss[1] == ""
                            {
                                ActionSt.Add(new { ProjectName = ss[0], Desc = ss[2], Time = ss[3] + " " + ss[4], CompleteDesc = ss[1], Duration = ss[5] });

                                if (ss[5] != "")
                                {
                                    int oi = 0;
                                    int.TryParse(ss[5], out oi);
                                    if (oi > 0) ;
                                    total += oi;
                                }
                                //                            ActionsStatistic.Add(new Action { ActionName = ss[2], ProjectName = ss[0], Time = ss[3] + " " + ss[4] });
                            }
                            else if (sAction != "" && ss[2].Contains(sAction))
                            {
                                ActionSt.Add(new { ProjectName = ss[0], Desc = ss[2], Time = ss[3] + " " + ss[4], CompleteDesc = ss[1] });
                            }
                        }
                        catch (Exception ex)
                        {
                            if(ss != null && ss.Length>1)
                                MessageBox.Show("اشکال در فراخوانی فعالیت " + ss[2]);
                            continue;
                            // return null;

                        }
                    }

                    return ActionSt;
                }

                return new List<object>();

                //                this.bindingSource1.DataSource = _Queue;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
			}
            total = 0;
            return null;

        }
        public static List<object> GetToDoActions(out int total, int day = 0, string sAction = "")
        {

            try
            {

                total = 0;
                {

                    var Actions = File.ReadAllLines(Utility._ToDoListFilePath);

					Actions.Reverse();

                    List<object> ActionSt = new List<object>();

                    foreach (string s in Actions)
                    {
						if (s == "") continue;
                        string[] ss = s.Split(';');

                        //if (int.Parse(Month) != int.Parse(ss[3].Split('/')[1])) continue;
                        //if (day != 0 && day != int.Parse(ss[3].Split('/')[2])) continue;

                        if (sAction == "" )
                        {
							ActionSt.Add(new { ProjectName = ss[0], Title = ss[2], Desc = ss[1], Time = ss[3] + " " + ss[4] });
                            // ActionsStatistic.Add(new Action { ActionName = ss[2], ProjectName = ss[0], Time = ss[3] + " " + ss[4] });
                        }
                        else if (sAction != "" && ss[1] == "" && ss[2].Contains(sAction))
                        {
                            ActionSt.Add(new { ProjectName = ss[0], Desc = ss[2], Time = ss[3] + " " + ss[4] });
                        }
                    }

                    return ActionSt;
                }

                return new List<object>();

                //                this.bindingSource1.DataSource = _Queue;

            }
            catch
			(Exception ex)
			{
			}
            total = 0;
            return null;

        }



        public static List<object> GetReceivers()
        {

            try
            {

                //total = 0;

                List<Action> ActionsStatistic = new List<Action>();

                // if (Main.frm._Projects.Count > 0)
                {

					List<string> lines = File.ReadAllLines(Utility._Receivers).ToList();

                    lines.Reverse();

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
                        if (ss[0].Split('/').Length >=2)
                            name = ss[0].Split('/')[1];



                        ActionSt.Add(new { IP = ip, Desc = name, Email = email });

                    }

                    return ActionSt;
                }

                return new List<object>();

                //                this.bindingSource1.DataSource = _Queue;

            }
            catch { }
         //   total = 0;
            return null;

        }


		public static EventWaitHandle waitHandle = new EventWaitHandle(true, EventResetMode.AutoReset, "SHARED_BY_ALL_PROCESSES");


		public static void WriteTofile(string path , string[] content)
		{
			try
			{
				waitHandle.WaitOne();
					File.AppendAllLines(path , content);
				waitHandle.Set();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.StackTrace + "\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

			}

			return;
		}

    }


}
