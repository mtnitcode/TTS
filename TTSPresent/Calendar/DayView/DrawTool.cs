/* Developed by Ertan Tike (ertan.tike@moreum.com) */

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Sbn.Controls.EventCalendar
{
    public class DrawTool : ITool
    {
        public int TimeStep = 3;

        MyDateTime m_SelectionStart;
        bool m_SelectionStarted;

        public void Reset()
        {
            m_SelectionStarted = false;
        }

        public void MouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (m_SelectionStarted)
                {
                    MyDateTime m_Time = m_DayView.GetTimeAt(e.X, e.Y);
                    m_Time = m_Time.AddMinutes((60/TimeStep));

                    //if (m_Time.Day == m_SelectionStart.Day)
                    //{
                        if (m_Time.m_GregoryDate < m_SelectionStart.m_GregoryDate)
                        {
                            m_DayView.SelectionStart = m_Time;
                            m_DayView.SelectionEnd = m_SelectionStart;
                        }
                        else
                        {
                            m_DayView.SelectionEnd = m_Time;
                        }
                    //}

                    m_DayView.Invalidate();
                }
            }
        }

        public void MouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_DayView.Capture = false;
                m_SelectionStarted = false;

                m_DayView.RaiseSelectionChanged(EventArgs.Empty);

                if (Complete != null)
                    Complete(this, EventArgs.Empty);
            }
        }

        public void MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_SelectionStart = m_DayView.GetTimeAt(e.X, e.Y);

                m_DayView.SelectionStart = m_SelectionStart;


                

                m_DayView.SelectionEnd = m_SelectionStart.AddMinutes((60/TimeStep));

                m_SelectionStarted = true;

                m_DayView.Invalidate();
                m_DayView.Capture = true;
            }
        }

        private DayView m_DayView;

        public DayView DayView
        {
            get { return m_DayView; }
            set { m_DayView = value; }
        }

        public event EventHandler Complete;
    }
}
