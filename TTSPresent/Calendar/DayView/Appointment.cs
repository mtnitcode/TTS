/* Developed by Ertan Tike (ertan.tike@moreum.com) */

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections.ObjectModel;

namespace Sbn.Controls.EventCalendar
{
    public class Appointment
    {
        public Appointment()
        {
            color = Color.White;
            m_BorderColor = Color.Blue;
            m_Title = "New Appointment";
        }


        private long _ID;

        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }


        private object _Tag;
        public object Tag
        {
            get { return _Tag; }
            set { _Tag = value; }
        }

        private MyDateTime m_StartDate;

        public MyDateTime StartDate
        {
            get
            {
                return m_StartDate;
            }
            set
            {
                m_StartDate = value;
                OnStartDateChanged();

            }
        }
        protected virtual void OnStartDateChanged()
        {
        }

        private MyDateTime m_EndDate;

        public MyDateTime EndDate
        {
            get
            {
                return m_EndDate;
            }
            set
            {
                m_EndDate = value;
                OnEndDateChanged();
            }
        }
        protected virtual void OnEndDateChanged()
        {
        }

        private Collection<DateTime> m_AlarmDate = new Collection<DateTime>();
        public Collection<DateTime> AlarmDate
        {
            get
            {
                return m_AlarmDate;
            }
            set
            {
                m_AlarmDate = value;
                OnAlarmDateChanged();
            }
        }
        protected virtual void OnAlarmDateChanged()
        {
        }

        private bool m_Locked = false;

        [System.ComponentModel.DefaultValue(false)]
        public bool Locked
        {
            get { return m_Locked; }
            set
            {
                m_Locked = value;
                OnLockedChanged();
            }
        }

        protected virtual void OnLockedChanged()
        {
        }

        private Color color = Color.White;

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        private Color textColor = Color.Black;

        public Color TextColor
        {
            get { return textColor; }
            set { textColor = value; }
        }

        private Color m_BorderColor = Color.Blue;

        public Color BorderColor
        {
            get
            {
                return m_BorderColor;
            }
            set
            {
                m_BorderColor = value;
            }
        }

        private string m_Title = "";

        [System.ComponentModel.DefaultValue("")]
        public string Title
        {
            get
            {
                return m_Title;
            }
            set
            {
                m_Title = value;
                OnTitleChanged();
            }
        }

		public string Description
		{
			get
			{
				return _description;
			}

			set
			{
				_description = value;
			}
		}

		public bool AutoStart
		{
			get
			{
				return _autoStart;
			}

			set
			{
				_autoStart = value;
			}
		}

		public string Subject
		{
			get
			{
				return _subject;
			}

			set
			{
				_subject = value;
			}
		}

		protected virtual void OnTitleChanged()
        {
        }

        internal int m_ConflictCount;

		private bool _autoStart;
		private string _description;
		private string _subject;
    }
}
