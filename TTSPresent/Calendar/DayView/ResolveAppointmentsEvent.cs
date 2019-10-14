/* Developed by Ertan Tike (ertan.tike@moreum.com) */

using System;
using System.Collections.Generic;
using System.Text;

namespace Sbn.Controls.EventCalendar
{
    public class ResolveAppointmentsEventArgs : EventArgs
    {
        public ResolveAppointmentsEventArgs(MyDateTime start, MyDateTime end)
        {
            m_StartDate = start;
            m_EndDate = end;
            m_Appointments = new List<Appointment>();
        }

        private MyDateTime m_StartDate;

        public MyDateTime StartDate
        {
            get { return m_StartDate; }
            set { m_StartDate = value; }
        }

        private MyDateTime m_EndDate;

        public MyDateTime EndDate
        {
            get { return m_EndDate; }
            set { m_EndDate = value; }
        }

        private List<Appointment> m_Appointments;

        public List<Appointment> Appointments
        {
            get { return m_Appointments; }
            set { m_Appointments = value; }
        }
    }

    public delegate void ResolveAppointmentsEventHandler(object sender, ResolveAppointmentsEventArgs args);
}
