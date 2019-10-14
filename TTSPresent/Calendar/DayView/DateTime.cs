using Sbn.Controls.FDate.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sbn.Controls.EventCalendar
{
    public class MyDateTime
    {

        private int m_Day;
        private int m_Month;
        private int m_Year;

        private int m_hour;
        private int m_minute;
        private int m_second;

        
        public MyDateTime Date
        {
            get
            {
                System.DateTime dd = m_GregoryDate.Date;
                MyDateTime dt = new MyDateTime(m_GregoryDate.Date);
                return dt;
            }
            
        }

        public System.DateTime m_GregoryDate;

        public MyDateTime(long date)
        {
            m_GregoryDate = new System.DateTime(date);

            DateTime dtt = new DateTime(((PersianDate)(m_GregoryDate)).Year, ((PersianDate)(m_GregoryDate)).Month, ((PersianDate)(m_GregoryDate)).Day, ((PersianDate)(m_GregoryDate)).Hour, ((PersianDate)(m_GregoryDate)).Minute, ((PersianDate)(m_GregoryDate)).Second);

            this.m_Day = dtt.Day;
            this.m_Month = dtt.Month;
            this.m_Year = dtt.Year;
            this.m_hour = dtt.Hour;
            this.m_minute = dtt.Minute;
            this.m_second = dtt.Second;

        }

        public MyDateTime(System.DateTime date)
        {
            this.m_GregoryDate = date;

            PersianDate dtt = new PersianDate(((PersianDate)(date)).Year, ((PersianDate)(date)).Month, ((PersianDate)(date)).Day, ((PersianDate)(date)).Hour, ((PersianDate)(date)).Minute, ((PersianDate)(date)).Second);

            this.m_Day = dtt.Day;
            this.m_Month = dtt.Month;
            this.m_Year = dtt.Year;
            this.m_hour = dtt.Hour ;
            this.m_minute = dtt.Minute ;
            this.m_second = dtt.Second ;


            
        }

        //private PersianDate m_convDate;


        public string ToShortTimeString()
        {
            PersianDate pd = new PersianDate(m_GregoryDate);

            return pd.ToString("d");
        }

        public string ToLongDateString()
        {

            PersianDate pd = new PersianDate(m_GregoryDate);

            return pd.ToString("D");

        }

        public MyDateTime Subtract(TimeSpan ts)
        {
            System.DateTime dt = m_GregoryDate.Subtract(ts);

            PersianDate pp = (PersianDate)dt;
            //            DTime dd = m_convDate.GregoryToShamsi(dt.Year, dt.Month, dt.Day);

            var dtt = new MyDateTime(pp.Year, pp.Month, pp.Day);

            //DateTime dtt = new DateTime(dd.DT_year, dd.DT_month, dd.DT_day);

            return dtt;


        }

        public MyDateTime Add(TimeSpan ts)
        {
            System.DateTime dt = m_GregoryDate.Add (ts);

            PersianDate pp = (PersianDate)dt;
            //            DTime dd = m_convDate.GregoryToShamsi(dt.Year, dt.Month, dt.Day);

            var dtt = new MyDateTime(pp.Year, pp.Month, pp.Day,pp.Hour , pp.Minute,pp.Second);

            //DateTime dtt = new DateTime(dd.DT_year, dd.DT_month, dd.DT_day);

            return dtt;


        }

        public System.DayOfWeek DayOfWeek
        {
            get
            {
                return m_GregoryDate.DayOfWeek;
            }
        }

        public MyDateTime(int Year, int Month, int Day , int hour , int minute , int second)
        {
            this.m_Day = Day;
            this.m_Month = Month;
            this.m_Year = Year;
            this.m_hour = hour;
            this.m_minute = minute;
            this.m_second = second;

            //m_convDate = new  PersianDate ();

            int y = Year, m = Month, d = Day;


            PersianDate pp = new PersianDate(y, m, d ,  hour , minute , second );
            System.DateTime dd = (System.DateTime)pp;

//            System.DateTime tempD = m_convDate.ShamsiToGregory(y, m, d);
            m_GregoryDate = dd;

        }

        public MyDateTime(int Year, int Month, int Day)
        {
            this.m_Day = Day;
            this.m_Month = Month;
            this.m_Year = Year;

            //m_convDate = new  PersianDate ();

            int y = Year, m = Month, d = Day;
            PersianDate pp = new PersianDate(y, m, d );
            System.DateTime dd = (System.DateTime)pp;

            m_GregoryDate = dd;

        }

        public MyDateTime AddMinutes(int addMinutes)
        {
            System.DateTime dt =  m_GregoryDate.AddMinutes(addMinutes);

            string retDate = ((PersianDate)(dt)).ToString();

//            DTime dd = m_convDate.GregoryToShamsi(dt.Year, dt.Month, dt.Day);
            MyDateTime dtt = new MyDateTime(((PersianDate)(dt)).Year, ((PersianDate)(dt)).Month, ((PersianDate)(dt)).Day , ((PersianDate)(dt)).Hour , ((PersianDate)(dt)).Minute , ((PersianDate)(dt)).Second  );
            return dtt;

        }

        public MyDateTime AddHours(int addHours)
        {
            System.DateTime dt = m_GregoryDate.AddHours(addHours);

            var dtt = new MyDateTime(((PersianDate)(dt)).Year, ((PersianDate)(dt)).Month, ((PersianDate)(dt)).Day, ((PersianDate)(dt)).Hour, ((PersianDate)(dt)).Minute, ((PersianDate)(dt)).Second);

            //DTime dd = m_convDate.GregoryToShamsi(dt.Year, dt.Month, dt.Day);
            //DateTime dtt = new DateTime(dd.DT_year, dd.DT_month, dd.DT_day);
            return dtt;

        }

        public int Minute
        {
            get { return m_minute ; }
            set { this.m_minute = value; }
        }

        public int Hour
        {
            get { return m_hour; }
            set { this.m_hour  = value; }
        }

        public int Second
        {
            get { return m_second ; }
            set { this.m_second  = value; }
        }


        public bool Equals(MyDateTime date)
        {
            return m_GregoryDate.Equals(date.m_GregoryDate);
        }


        
        public MyDateTime AddDays(double addDays)
        {
            System.DateTime dt =  m_GregoryDate.AddDays(addDays);

            var dtt = new MyDateTime(((PersianDate)(dt)).Year, ((PersianDate)(dt)).Month, ((PersianDate)(dt)).Day, ((PersianDate)(dt)).Hour, ((PersianDate)(dt)).Minute, ((PersianDate)(dt)).Second);

            //DTime dd = m_convDate.GregoryToShamsi(dt.Year, dt.Month, dt.Day);
            //DateTime dtt = new DateTime(dd.DT_year, dd.DT_month, dd.DT_day);

            return dtt;

        }
        public MyDateTime AddSeconds(double addSeconds)
        {
            System.DateTime dt = m_GregoryDate.AddSeconds(addSeconds);

            var dtt = new MyDateTime(((PersianDate)(dt)).Year, ((PersianDate)(dt)).Month, ((PersianDate)(dt)).Day, ((PersianDate)(dt)).Hour, ((PersianDate)(dt)).Minute, ((PersianDate)(dt)).Second);

            //DTime dd = m_convDate.GregoryToShamsi(dt.Year, dt.Month, dt.Day);
            //DateTime dtt = new DateTime(dd.DT_year, dd.DT_month, dd.DT_day);

            return dtt;

        }

        public static MyDateTime MinValue
        {
            get
            {
                MyDateTime dt = new  MyDateTime (1380, 1, 1);
                return dt;
            }
        }

        public int CompareTo(MyDateTime dtCompare)
        {

            return this.m_GregoryDate.CompareTo(dtCompare.m_GregoryDate);

        }

        public int Day
        {
            get
            {
                return m_Day;
            }
            set
            {
                m_Day = value;
            }
        }

        public int Month
        {
            get
            {
                return m_Month;
            }
            set
            {
                m_Month = value;
            }
        }

        public int Year
        {
            get
            {
                return m_Year;
            }
            set
            {
                m_Year = value;
            }
        }

        public static MyDateTime Now
        {
            get 
            {

                MyDateTime dt = new  MyDateTime (PersianDate.Now.Year, PersianDate.Now.Month, PersianDate.Now.Day);

//                DateTime dt = new DateTime(dd.DT_year  , dd.DT_month , dd.DT_day );

                dt.Hour = System.DateTime.Now.Hour;
                dt.Minute  = System.DateTime.Now.Minute ;
                dt.Second  = System.DateTime.Now.Second ;
                return dt;
            }
        }
    

    }
}
