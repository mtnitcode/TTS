/* Developed by Ertan Tike (ertan.tike@moreum.com) */

using System;
using System.Collections.Generic;
using System.Text;

namespace Sbn.Controls.EventCalendar
{
    public class NewAppointmentEventArgs : EventArgs
    {
        public NewAppointmentEventArgs(string title, MyDateTime start, MyDateTime end)
        {
            m_Title = title;
            m_StartDate = start;
            m_EndDate = end;
        }

        private string m_Title;

        public string Title
        {
            get { return m_Title; }
        }

        private MyDateTime m_StartDate;

        public MyDateTime StartDate
        {
            get { return m_StartDate; }
        }

        private MyDateTime m_EndDate;

        public MyDateTime EndDate
        {
            get { return m_EndDate; }
        }
    }

    public delegate void NewAppointmentEventHandler( object sender, NewAppointmentEventArgs args );
}
