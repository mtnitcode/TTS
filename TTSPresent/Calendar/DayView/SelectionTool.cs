/* Developed by Ertan Tike (ertan.tike@moreum.com) */

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Sbn.Controls.EventCalendar
{
    public class SelectionTool : ITool
    {
        private DayView dayView;

        public DayView DayView
        {
            get
            {
                return dayView;
            }
            set
            {
                dayView = value;
            }
        }

        private MyDateTime startDate;
        private TimeSpan length;
        private Mode mode;
        private TimeSpan delta;

        public void Reset()
        {
            length = TimeSpan.Zero;
            delta = TimeSpan.Zero;
        }

        public void MouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            Appointment selection = dayView.SelectedAppointment;

            if ((selection != null) && (!selection.Locked))
            {
                switch (e.Button)
                {
                    case System.Windows.Forms.MouseButtons.Left:

                        // Get time at mouse position
                        var m_Date = dayView.GetTimeAt(e.X, e.Y);

                        switch (mode)
                        {
                            case Mode.Move:

                                // add delta value
                                m_Date = m_Date.Add(delta);

                                if (length == TimeSpan.Zero)
                                {
                                    startDate = selection.StartDate;
                                    length = selection.EndDate.m_GregoryDate - startDate.m_GregoryDate;
                                }
                                else
                                {
                                    var m_EndDate = m_Date.Add(length);

                                    if (m_EndDate.Day == m_Date.Day)
                                    {
                                        selection.StartDate = m_Date;
                                        selection.EndDate = m_EndDate;
                                        dayView.Invalidate();
                                        dayView.RaiseAppointmentMove(new AppointmentEventArgs(selection));
                                        
                                    }
                                }

                                break;

                            case Mode.ResizeBottom:

                                if (m_Date.m_GregoryDate > selection.StartDate.m_GregoryDate)
                                {
                                    if (selection.EndDate.Day == m_Date.Day)
                                    {
                                        selection.EndDate = m_Date;
                                        dayView.Invalidate();
                                        dayView.RaiseAppointmentMove(new AppointmentEventArgs(selection));
                                    }
                                }

                                break;

                            case Mode.ResizeTop:

                                if (m_Date.m_GregoryDate < selection.EndDate.m_GregoryDate)
                                {
                                    if (selection.StartDate.Day == m_Date.Day)
                                    {
                                        selection.StartDate = m_Date;
                                        dayView.Invalidate();
                                        dayView.RaiseAppointmentMove(new AppointmentEventArgs(selection));
                                    }
                                }

                                break;
                        }

                        break;

                    default:

                        Mode tmpNode = GetMode(e);

                        switch (tmpNode)
                        {
                            case Mode.Move:
                                dayView.Cursor = System.Windows.Forms.Cursors.Default;
                                break;
                            case Mode.ResizeBottom:
                            case Mode.ResizeTop:
                                dayView.Cursor = System.Windows.Forms.Cursors.SizeNS;
                                break;
                        }

                        break;
                }
            }
        }

        private Mode GetMode(System.Windows.Forms.MouseEventArgs e)
        {
            if (dayView.SelectedAppointment == null)
                return Mode.None;

            if (dayView.appointmentViews.ContainsKey(dayView.SelectedAppointment))
            {
                DayView.AppointmentView view = dayView.appointmentViews[dayView.SelectedAppointment];

                Rectangle topRect = view.Rectangle;
                Rectangle bottomRect = view.Rectangle;

                bottomRect.Y = bottomRect.Bottom - 5;
                bottomRect.Height = 5;
                topRect.Height = 5;

                if (topRect.Contains(e.Location))
                    return Mode.ResizeTop;
                else if (bottomRect.Contains(e.Location))
                    return Mode.ResizeBottom;
                else
                    return Mode.Move;
            }

            return Mode.None;
        }

        public void MouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (Complete != null)
                    Complete(this, EventArgs.Empty);

                dayView.RaiseAppointmentMoved(new AppointmentEventArgs(dayView.SelectedAppointment));
            }

            dayView.RaiseSelectionChanged(EventArgs.Empty);

            mode = Mode.Move;

            delta = TimeSpan.Zero;
        }

        public void MouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (dayView.SelectedAppointmentIsNew)
            {
                dayView.RaiseNewAppointment();
            }

            if (dayView.CurrentlyEditing)
                dayView.FinishEditing(false);

            mode = GetMode(e);

            if (dayView.SelectedAppointment != null)
            {
                var downPos = dayView.GetTimeAt(e.X, e.Y);
                // Calculate delta time between selection and clicked point
                delta = dayView.SelectedAppointment.StartDate.m_GregoryDate - downPos.m_GregoryDate;
            }
            else
            {
                delta = TimeSpan.Zero;
            }

            length = TimeSpan.Zero;
        }

        public event EventHandler Complete;

        enum Mode
        {
            ResizeTop,
            ResizeBottom,
            Move,
            None
        }
    }
}
