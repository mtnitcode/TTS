/* Developed by Ertan Tike (ertan.tike@moreum.com) */

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Sbn.Controls.EventCalendar
{
    public class DayView : Control
    {
        #region Variables

        private TextBox editbox;
        private VScrollBar scrollbar;
        private DrawTool drawTool;
        private SelectionTool selectionTool;
        private int allDayEventsHeaderHeight = 20;

        //private MyDateTime workStart;
        //private MyDateTime workEnd;

        #endregion

        #region Constants

        private int hourLabelWidth = 50;
        private int hourLabelIndent = 2;
        private int dayHeadersHeight = 30;
        private int appointmentGripWidth = 5;
        private int horizontalAppointmentHeight = 20;

        #endregion

        #region c.tor

        public DayView()
        {


            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);

            scrollbar = new VScrollBar();
            scrollbar.SmallChange = halfHourHeight ;
            scrollbar.LargeChange = halfHourHeight * 2 ;
            scrollbar.Dock = DockStyle.Right;
            scrollbar.Visible = allowScroll;
            scrollbar.Scroll += new ScrollEventHandler(scrollbar_Scroll);
            AdjustScrollbar();
            scrollbar.Value = (startHour * TimeStep * halfHourHeight);

            this.Controls.Add(scrollbar);

            editbox = new TextBox();
            editbox.Multiline = true;
            editbox.Visible = false;
            editbox.BorderStyle = BorderStyle.None;
            editbox.KeyUp += new KeyEventHandler(editbox_KeyUp);
            editbox.Margin = Padding.Empty;

            this.Controls.Add(editbox);

            drawTool = new DrawTool();
            drawTool.DayView = this;

            selectionTool = new SelectionTool();
            selectionTool.DayView = this;
            selectionTool.Complete += new EventHandler(selectionTool_Complete);

            activeTool = drawTool;

            UpdateWorkingHours();



            this.Renderer = new Office12Renderer(this.Font);
           // this.Renderer.BaseFont = this.Font;
            
        }

        #endregion

        #region Properties




        private ViewType _ViewDayType = ViewType.Day;

        public ViewType ViewDayType
        {
            get 
            {
                return _ViewDayType; 
            }
            set
            {
                _ViewDayType = value;
                switch (value)
                { 
                    case ViewType.Day:
                        DaysToShow = 1;
                        scrollbar.Visible = true;
                        StartViewDate = StartDate;
                        EndViewDate = StartViewDate.AddDays(DaysToShow);
                        break;

                    case ViewType.Weekly:
                        DaysToShow = 7;
                        scrollbar.Visible = false;
                        var time = new MyDateTime(StartDate.m_GregoryDate);
                        while (time.DayOfWeek != DayOfWeek.Saturday)
                        {
                            time = time.AddDays(-1);
                        }

                        StartViewDate = time;
                        EndViewDate = StartViewDate.AddDays(DaysToShow);


                        break;

                    case ViewType.Monthly:
                        DaysToShow = 42;
                        scrollbar.Visible = false;
                        time = getFirstDayOfMonth(StartDate);
                        while (time.DayOfWeek != DayOfWeek.Saturday)
                        {
                            time = time.AddDays(-1);
                        }
                        StartViewDate = time;
                        EndViewDate = StartViewDate.AddDays(DaysToShow);
                        break;

                    case ViewType.Yearly:
                        DaysToShow = 365;
                        scrollbar.Visible = false;
                        time = getFirstDayOfYear(StartDate);
                        while (time.DayOfWeek != DayOfWeek.Saturday)
                        {
                            time = time.AddDays(-1);
                        }
                        StartViewDate = time;
                        EndViewDate = StartViewDate.AddDays(DaysToShow);
                        break;

                    default:
                        DaysToShow = 1;
                        break;
                }
                this.Invalidate();
            }
        }

        /// <summary>
        /// نمايش بازه زماني
        /// </summary>
        public int TimeStep
        {
            get
            {
                return _TimeStep;
            }
            set
            {
                _TimeStep = value;
                drawTool.TimeStep = value;
            }
        }

        private int halfHourHeight = 18;

        [System.ComponentModel.DefaultValue(18)]
        public int HalfHourHeight
        {
            get
            {
                return halfHourHeight;
            }
            set
            {
                halfHourHeight = value;
                OnHalfHourHeightChanged();
            }
        }

        private void OnHalfHourHeightChanged()
        {

            AdjustScrollbar();
            Invalidate();
        }

        private AbstractRenderer renderer;

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public AbstractRenderer Renderer
        {
            get
            {
                return renderer;
            }
            set
            {
                renderer = value;
                OnRendererChanged();
            }
        }

        private void OnRendererChanged()
        {
            this.Font = renderer.BaseFont;
            this.Invalidate();
        }

        private int daysToShow = 1;

        [System.ComponentModel.DefaultValue(1)]
        public int DaysToShow
        {
            get
            {
                return daysToShow;
            }
            set
            {
                daysToShow = value;
                OnDaysToShowChanged();
            }
        }

        protected virtual void OnDaysToShowChanged()
        {
            if (this.CurrentlyEditing)
                FinishEditing(true);

            Invalidate();
        }

        private SelectionType selection;

        [System.ComponentModel.Browsable(false)]
        public SelectionType Selection
        {
            get
            {
                return selection;
            }
        }


        private MyDateTime startViewDate;

        public MyDateTime StartViewDate
        {
            get
            {
                return startViewDate;
            }
            set
            {
                if (value != null)
                {
                    startViewDate = value;
                }
                else
                {
                    startViewDate = new  MyDateTime (System.DateTime.Now);
                }
            }
        }
        private MyDateTime endViewDate;

        public MyDateTime EndViewDate
        {
            get
            {
                return endViewDate;
            }
            set
            {
                if (value != null)
                {
                    endViewDate = value;
                }
                else
                {
                    endViewDate = new  MyDateTime  (System.DateTime.Now);
                }
            }
        }


        private MyDateTime startDate;
        
        public MyDateTime StartDate
        {
            get
            {
                if (startDate == null)
                {
                    startDate = new  MyDateTime (System.DateTime.Now);
                }

                return startDate;
            }
            set
            {
                if (value != null)
                {
                    startDate = value;
                    OnStartDateChanged();
                }
                else
                {

                    //Sbn.Controls.Calendar.DateTime dd = new Sbn.Controls.Calendar.DateTime(System.DateTime.Now);
                    //dayView1.StartDate = dd;
                    startDate = new  MyDateTime (System.DateTime.Now);
                    OnStartDateChanged();
                }


                switch (this.ViewDayType)
                {
                    case ViewType.Day:
                        StartViewDate = StartDate;
                        EndViewDate = StartViewDate.AddDays(DaysToShow);
                        break;

                    case ViewType.Weekly:
                        var time = new  MyDateTime (StartDate.m_GregoryDate);
                        while (time.DayOfWeek != DayOfWeek.Saturday)
                        {
                            time = time.AddDays(-1);
                        }

                        StartViewDate = time;
                        EndViewDate = StartViewDate.AddDays(DaysToShow);


                        break;

                    case ViewType.Monthly:
                        time = getFirstDayOfMonth(StartDate);
                        while (time.DayOfWeek != DayOfWeek.Saturday)
                        {
                            time = time.AddDays(-1);
                        }
                        StartViewDate = time;
                        EndViewDate = StartViewDate.AddDays(DaysToShow);
                        break;

                    case ViewType.Yearly:
                        time = getFirstDayOfYear(StartDate);
                        while (time.DayOfWeek != DayOfWeek.Saturday)
                        {
                            time = time.AddDays(-1);
                        }
                        StartViewDate = time;
                        EndViewDate = StartViewDate.AddDays(DaysToShow);
                        break;

                    default:
                        DaysToShow = 1;
                        break;
                }

            }
        }

        protected virtual void OnStartDateChanged()
        {
            startDate = startDate.Date;

            selectedAppointment = null;
            selectedAppointmentIsNew = false;
            selection = SelectionType.DateRange;

            Invalidate();
        }

        private int startHour = 8;

        [System.ComponentModel.DefaultValue(8)]
        public int StartHour
        {
            get
            {
                return startHour;
            }
            set
            {
                startHour = value;
                OnStartHourChanged();
            }
        }

        protected virtual void OnStartHourChanged()
        {
            scrollbar.Value = (startHour * 2 * halfHourHeight);

            Invalidate();
        }

        private Appointment selectedAppointment;

        [System.ComponentModel.Browsable(false)]
        public Appointment SelectedAppointment
        {
            get { return selectedAppointment; }
        }

        private MyDateTime selectionStart;

        public MyDateTime SelectionStart
        {
            get { return selectionStart; }
            set 
            {
                if (value != null)
                {
                    selectionStart = value;
                }
                else
                {
                    selectionStart = new  MyDateTime (new System.DateTime((long)(0)));
                }

            }
        }

        private MyDateTime selectionEnd;

        public MyDateTime SelectionEnd
        {
            get { return selectionEnd; }
            set 
            {
                if (value != null)
                {
                    selectionEnd = value;
                }
                else
                {
                    selectionEnd = new  MyDateTime (new System.DateTime((long)(0)));
                }
            }
        }

        private ITool activeTool;

        [System.ComponentModel.Browsable(false)]
        public ITool ActiveTool
        {
            get { return activeTool; }
            set { activeTool = value; }
        }

        private bool _EditTextByClick = false;
        public bool EditTextByClick
        {
            get
            {
                return _EditTextByClick;
            }
            set
            {
                _EditTextByClick = value;
            }
        }
        

        [System.ComponentModel.Browsable(false)]
        public bool CurrentlyEditing
        {
            get
            {
                return editbox.Visible;
            }
        }

        private int workingHourStart = 8;

        [System.ComponentModel.DefaultValue(8)]
        public int WorkingHourStart
        {
            get
            {
                return workingHourStart;
            }
            set
            {
                workingHourStart = value;
                UpdateWorkingHours();
            }
        }

        private int workingMinuteStart = 20;

        [System.ComponentModel.DefaultValue(20)]
        public int WorkingMinuteStart
        {
            get
            {
                return workingMinuteStart;
            }
            set
            {
                workingMinuteStart = value;
                UpdateWorkingHours();
            }
        }

        private int workingHourEnd = 18;

        [System.ComponentModel.DefaultValue(18)]
        public int WorkingHourEnd
        {
            get
            {
                return workingHourEnd;
            }
            set
            {
                workingHourEnd = value;
                UpdateWorkingHours();
            }
        }

        private int workingMinuteEnd = 20;

        [System.ComponentModel.DefaultValue(20)]
        public int WorkingMinuteEnd
        {
            get { return workingMinuteEnd; }
            set
            {
                workingMinuteEnd = value;
                UpdateWorkingHours();
            }
        }

        private void UpdateWorkingHours()
        {
            //workStart = new  MyDateTime (1, 1, 1, workingHourStart, workingMinuteStart, 0);
            //workEnd = new  MyDateTime (1, 1, 1, workingHourEnd, workingMinuteEnd, 0);

            Invalidate();
        }

        bool selectedAppointmentIsNew;

        public bool SelectedAppointmentIsNew
        {
            get
            {
                return selectedAppointmentIsNew;
            }
        }

        private bool allowScroll = true;

        [System.ComponentModel.DefaultValue(true)]
        public bool AllowScroll
        {
            get
            {
                return allowScroll;
            }
            set
            {
                allowScroll = value;
            }
        }

        private bool allowInplaceEditing = true;

        [System.ComponentModel.DefaultValue(true)]
        public bool AllowInplaceEditing
        {
            get
            {
                return allowInplaceEditing;
            }
            set
            {
                allowInplaceEditing = value;
            }
        }

        private bool allowNew = true;

        [System.ComponentModel.DefaultValue(true)]
        public bool AllowNew
        {
            get
            {
                return allowNew;
            }
            set
            {
                allowNew = value;
            }
        }

        #endregion

        private int HeaderHeight
        {
            get
            {
                return dayHeadersHeight + allDayEventsHeaderHeight;
            }
        }

        #region Event Handlers

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            try
            {
                if (scrollbar.Visible)
                {
                    if (e.Delta < 0)
                    {
                        scrollbar.Value += 30;
                    }
                    else
                    {
                        scrollbar.Value -= 30;
                    }
                    Invalidate();
                }
            }
            catch
            { 

            }
        }

        void editbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                FinishEditing(true);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                FinishEditing(false);
            }
        }

        void selectionTool_Complete(object sender, EventArgs e)
        {
            if (selectedAppointment != null)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(EnterEditMode));
            }
        }

        void scrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            Invalidate();

            if (editbox.Visible)
                //scroll text box too
                editbox.Top += e.OldValue - e.NewValue;
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, height, specified);
            AdjustScrollbar();
        }

        private void AdjustScrollbar()
        {
            scrollbar.Maximum = (TimeStep * halfHourHeight * 25) - this.Height + this.HeaderHeight;
            scrollbar.Minimum = 0;
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Flicker free
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            Appointment appointment = GetAppointmentAt(e.X, e.Y);

            if (appointment == null)
            {
                //if (selectedAppointment != null)
                //{
                //    selectedAppointment = null;
                //    Invalidate();
                //}

                //newTool = drawTool;
                //selection = SelectionType.DateRange;
            }
            else
            {
                AppointmentEventArgs ee = new AppointmentEventArgs(appointment);

                if (AppoinmentMouseDoubleClick != null)
                {
                    AppoinmentMouseDoubleClick(this, ee);
                }
                //newTool = selectionTool;
                selectedAppointment = appointment;
                selection = SelectionType.Appointment;

                Invalidate();
            }

            base.OnMouseDoubleClick(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Capture focus
            this.Focus();

            if (CurrentlyEditing)
            {
                FinishEditing(false);
            }

            if (selectedAppointmentIsNew)
            {
                RaiseNewAppointment();
            }
           
            ITool newTool = null;

            Appointment appointment = GetAppointmentAt(e.X, e.Y);

            if (appointment == null)
            {
                if (selectedAppointment != null)
                {
                    selectedAppointment = null;
                    Invalidate();
                }

                newTool = drawTool;



                selection = SelectionType.DateRange;
            }
            else
            {
                newTool = selectionTool;
                selectedAppointment = appointment;
                selection = SelectionType.Appointment;

                Invalidate();
            }

            if (activeTool != null)
            {
                activeTool.MouseDown(e);
            }

            if ((activeTool != newTool) && (newTool != null))
            {
                newTool.Reset();
                newTool.MouseDown(e);
            }

            activeTool = newTool;

            base.OnMouseDown(e);
        }

        

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (activeTool != null)
                activeTool.MouseMove(e);

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (activeTool != null)
                activeTool.MouseUp(e);

            base.OnMouseUp(e);
        }

        System.Collections.Hashtable cachedAppointments = new System.Collections.Hashtable();

        protected virtual void OnResolveAppointments(ResolveAppointmentsEventArgs args)
        {
            System.Diagnostics.Debug.WriteLine("Resolve app");

            if (ResolveAppointments != null)
                ResolveAppointments(this, args);

            this.allDayEventsHeaderHeight = 0;

            // cache resolved appointments in hashtable by days.
            cachedAppointments.Clear();

            if ((selectedAppointmentIsNew) && (selectedAppointment != null))
            {
                if ((selectedAppointment.StartDate.m_GregoryDate > args.StartDate.m_GregoryDate) && (selectedAppointment.StartDate.m_GregoryDate < args.EndDate.m_GregoryDate))
                {
                    args.Appointments.Add(selectedAppointment);
                }
            }

            foreach (Appointment appointment in args.Appointments)
            {
                int key = -1;
                AppointmentList list;

                if (appointment.StartDate.Day == appointment.EndDate.Day)
                {

                    string strkey = appointment.StartDate.Month.ToString() + appointment.StartDate.Day.ToString();
                    key = int.Parse(strkey);
                    //key = appointment.StartDate.Day;
                }
                else
                {
                    // use -1 for exceeding one more than day
                    key = -1;

                    /* ALL DAY EVENTS IS NOT COMPLETE
                    this.allDayEventsHeaderHeight += horizontalAppointmentHeight;
                     */
                }

                list = (AppointmentList)cachedAppointments[key];

                if (list == null)
                {
                    list = new AppointmentList();
                    cachedAppointments[key] = list;
                }

                list.Add(appointment);
            }
        }

        internal void RaiseSelectionChanged(EventArgs e)
        {
            if (SelectionChanged != null)
                SelectionChanged(this, e);
        }

        internal void RaiseAppointmentMove(AppointmentEventArgs e)
        {
            if (AppoinmentMove != null)
                AppoinmentMove(this, e);
        }
        internal void RaiseAppointmentMoved(AppointmentEventArgs e)
        {
            if (AppoinmentMoved != null)
                AppoinmentMoved(this, e);
        }

      

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if ((allowNew) && char.IsLetterOrDigit(e.KeyChar))
            {
                if ((this.Selection == SelectionType.DateRange))
                {
                    if (!selectedAppointmentIsNew)
                        EnterNewAppointmentMode(e.KeyChar);
                }
            }
        }

        private void EnterNewAppointmentMode(char key)
        {
            Appointment appointment = new Appointment();
            appointment.StartDate = selectionStart;
            appointment.EndDate = selectionEnd;
            appointment.Title = key.ToString();

            selectedAppointment = appointment;
            selectedAppointmentIsNew = true;

            activeTool = selectionTool;

            Invalidate();

            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(EnterEditMode));
        }

        private delegate void StartEditModeDelegate(object state);

        private void EnterEditMode(object state)
        {
            if (!allowInplaceEditing)
                return;

            if (this.InvokeRequired)
            {
                Appointment selectedApp = selectedAppointment;

                System.Threading.Thread.Sleep(200);

                if (selectedApp == selectedAppointment)
                    this.Invoke(new StartEditModeDelegate(EnterEditMode), state);
            }
            else
            {
                if (EditTextByClick)
                {
                    StartEditing();
                }
            }
        }

        internal void RaiseNewAppointment()
        {
            NewAppointmentEventArgs args = new NewAppointmentEventArgs(selectedAppointment.Title, selectedAppointment.StartDate, selectedAppointment.EndDate);

            if (NewAppointment != null)
            {
                NewAppointment(this, args);
            }

            selectedAppointment = null;
            selectedAppointmentIsNew = false;

            Invalidate();
        }

        #endregion

        #region Public Methods

        public void StartEditing()
        {
            if (!selectedAppointment.Locked && appointmentViews.ContainsKey(selectedAppointment))
            {
                Rectangle editBounds = appointmentViews[selectedAppointment].Rectangle;

                editBounds.Inflate(-3, -3);
                editBounds.X += appointmentGripWidth - 2;
                editBounds.Width -= appointmentGripWidth - 5;

                editbox.Bounds = editBounds;
                editbox.Text = selectedAppointment.Title;
                editbox.Visible = true;
                editbox.SelectionStart = editbox.Text.Length;
                editbox.SelectionLength = 0;

                editbox.Focus();
            }
        }

        public void FinishEditing(bool cancel)
        {
            editbox.Visible = false;

            if (!cancel)
            {
                if (selectedAppointment != null)
                    selectedAppointment.Title = editbox.Text;
            }
            else
            {
                if (selectedAppointmentIsNew)
                {
                    selectedAppointment = null;
                    selectedAppointmentIsNew = false;
                }
            }

            Invalidate();
            this.Focus();
        }

        public MyDateTime GetTimeAt(int x, int y)
        {
            var MonthFirstDayView = getFirstDayOfMonth(startDate);

            while (MonthFirstDayView.DayOfWeek != DayOfWeek.Saturday)
            {
                MonthFirstDayView = MonthFirstDayView.AddDays(-1);
            }



            var date = startDate;
            switch (this.ViewDayType)
            { 
                case ViewType.Day:
                    int dayWidth = (this.Width - (scrollbar.Width + hourLabelWidth)) / daysToShow;

                    int hour = (y - this.HeaderHeight + scrollbar.Value) / halfHourHeight;
                    x -= hourLabelWidth;

                   

                    date = date.Date;
                    date = date.AddDays(x / dayWidth);

                    if ((hour > 0) && (hour < 24 * TimeStep))
                        date = date.AddMinutes((hour * (60 / TimeStep)));

                    return date;
                    break;

                case ViewType.Weekly:
                    dayWidth = this.Width/ 2;
                    int dayHeight = (this.Height - dayHeadersHeight) / 3;


                    if (x < this.Location.X  + dayWidth)
                    {
                        int FridayTempY = 3 * dayHeight + dayHeight / 2;

                        if (y - dayHeadersHeight < FridayTempY)
                        {

                            date = getFirstDayOfWeek(startDate).AddDays(6);
                            if (y - dayHeadersHeight < ((3 * dayHeight) - dayHeight / 2))
                            {
                                date = getFirstDayOfWeek(startDate).AddDays(5);

                                if (y - dayHeadersHeight < 2 * dayHeight)
                                {
                                    date = getFirstDayOfWeek(startDate).AddDays(4);

                                    if (y - dayHeadersHeight < dayHeight)
                                    {
                                        date = getFirstDayOfWeek(startDate).AddDays(3);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (y - dayHeadersHeight < 3 * dayHeight)
                        {
                            date = getFirstDayOfWeek(startDate).AddDays(2);

                            if (y - dayHeadersHeight < 2 * dayHeight)
                            {
                                date = getFirstDayOfWeek(startDate).AddDays(1);

                                if (y - dayHeadersHeight < dayHeight)
                                {
                                    date = getFirstDayOfWeek(startDate);
                                }
                            }
                        }

                       
                    }
                
                    return date;

                    break;

                case ViewType.Monthly:
                    dayWidth = this.Width / 7;
                     dayHeight = (this.Height - dayHeadersHeight) / 6;

                     int tempX = x;
                     int tempY = y - dayHeadersHeight;

                     int xDayLocation =  tempY /dayHeight  ;
                     int yDayLocation = tempX / dayWidth;

                    int temp = (yDayLocation ) + (xDayLocation * 7);
                    MonthFirstDayView = MonthFirstDayView.AddDays(temp);

                     return MonthFirstDayView;

                    break;

                default :

                     dayWidth = (this.Width - (scrollbar.Width + hourLabelWidth)) / daysToShow;

                     hour = (y - this.HeaderHeight + scrollbar.Value) / halfHourHeight;
                    x -= hourLabelWidth;

                     date = startDate;

                    date = date.Date;
                    date = date.AddDays(x / dayWidth);

                    if ((hour > 0) && (hour < 24 * TimeStep))
                        date = date.AddMinutes((hour * (60 / TimeStep)));

                    return date;
                    break;
            }

            return null;
        }

        public Appointment GetAppointmentAt(int x, int y)
        {
            if (y < this.HeaderHeight)
                return null;

            foreach (AppointmentView view in appointmentViews.Values)
                if (view.Rectangle.Contains(x, y))
                    return view.Appointment;

            return null;
        }

        #endregion

        #region Drawing Methods

        protected override void OnPaint(PaintEventArgs e)
        {
         //   ResolveAppointmentsEventArgs args = new ResolveAppointmentsEventArgs(this.StartDate,time.AddDays(7));// this.StartDate.AddDays(daysToShow));

            ResolveAppointmentsEventArgs args = null;
            switch (this.ViewDayType)
            { 
                case ViewType.Day:
                    scrollbar.Visible = true;
                    args = new ResolveAppointmentsEventArgs(this.StartDate,  this.StartDate.AddDays(daysToShow));
                    StartViewDate = this.StartDate;
                    EndViewDate = this.StartDate;

                    break;

                case ViewType.Weekly:
                   
                    //DateTime time = new DateTime(startDate.m_GregoryDate);
                    //int iTemp = (int)time.DayOfWeek + 1;
                    //time = time.AddDays(-iTemp);
                    args = new ResolveAppointmentsEventArgs(StartViewDate, EndViewDate);// this.StartDate.AddDays(daysToShow));
                    break;

                case ViewType.Monthly:
                   
                    args = new ResolveAppointmentsEventArgs(StartViewDate, EndViewDate);// this.StartDate.AddDays(daysToShow));
                    break;

                case ViewType.Yearly:
                   
                    args = new ResolveAppointmentsEventArgs(StartViewDate, EndViewDate);// this.StartDate.AddDays(daysToShow));
                    break;

                default:
                    break;
            }

           
           
            OnResolveAppointments(args);

            using (SolidBrush backBrush = new SolidBrush(renderer.BackColor))
                e.Graphics.FillRectangle(backBrush, this.ClientRectangle);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
            // Calculate visible rectangle
            Rectangle rectangle = new Rectangle(0, 0, this.Width , this.Height);

            if (scrollbar.Visible)
            { 
                rectangle.Width = rectangle.Width  - scrollbar.Width;
            }

          
            Rectangle daysRectangle = rectangle;
            daysRectangle.Y += this.HeaderHeight;
            daysRectangle.Height -= this.HeaderHeight;

            if (e.ClipRectangle.IntersectsWith(daysRectangle))
            {

                switch (ViewDayType)
                { 
                    case ViewType.Day:
                        Rectangle hourLabelRectangle = rectangle;
                        hourLabelRectangle.Y += this.HeaderHeight;
                        DrawHourLabels(e, hourLabelRectangle);
                        daysRectangle.X += hourLabelWidth;
                        daysRectangle.Width -= hourLabelWidth;
                        DrawDays(e, daysRectangle);
                        break;

                    case ViewType.Weekly:
                        Rectangle TilteRectangleWeekly = rectangle;
                        TilteRectangleWeekly.Height = this.HeaderHeight;
                        renderer.DrawTitleHeaderInWeekly(e.Graphics, TilteRectangleWeekly, StartDate);
                        DrawWeekly(e, daysRectangle);

                        break;

                    case ViewType.Monthly:
                        Rectangle TilteRectangleMonthly = rectangle;
                        TilteRectangleMonthly.Height = this.HeaderHeight;
                        renderer.DrawTitleHeaderInMontly(e.Graphics, TilteRectangleMonthly, StartDate);

                        DrawMonthly(e, daysRectangle);
                        break;

                    case ViewType.Yearly:

                        break;

                    default:
                        DrawDays(e, daysRectangle);
                        break;
                }

              




            }

            Rectangle headerRectangle = rectangle;

            headerRectangle.X += hourLabelWidth;
            headerRectangle.Width -= hourLabelWidth;
            headerRectangle.Height = dayHeadersHeight;

            if (e.ClipRectangle.IntersectsWith(headerRectangle))
            {
                if (this.ViewDayType == ViewType.Day)
                {
                    DrawDayHeaders(e, headerRectangle);
                }
            }

        }

        private int _TimeStep = 3;

        private void DrawHourLabels(PaintEventArgs e, Rectangle rect)
        {
            e.Graphics.SetClip(rect);

            //for (int m_Hour = 0; m_Hour < 24; m_Hour++)
            //{
            //    Rectangle hourRectangle = rect;

            //    hourRectangle.Y = rect.Y + (m_Hour * 2 * halfHourHeight) - scrollbar.Value;
            //    hourRectangle.X += hourLabelIndent;
            //    hourRectangle.Width = hourLabelWidth;

            //    if (hourRectangle.Y > this.HeaderHeight / 2)
            //        renderer.DrawHourLabel(e.Graphics, hourRectangle, m_Hour);
            //}


            for (int m_Hour = 0; m_Hour < 24; m_Hour++)
            {
                Rectangle hourRectangle = rect;

                hourRectangle.Y = rect.Y + (m_Hour * TimeStep * halfHourHeight) - scrollbar.Value;
                hourRectangle.X += hourLabelIndent;
                hourRectangle.Width = hourLabelWidth;

              //  hourRectangle.Height = rect.Y * halfHourHeight;   //@@

                if (hourRectangle.Y > this.HeaderHeight / 2)
                    renderer.DrawHourLabel(e.Graphics, hourRectangle, m_Hour, TimeStep ,halfHourHeight);
            }


          
            e.Graphics.ResetClip();
        }

        private void DrawDayHeaders(PaintEventArgs e, Rectangle rect)
        {
            int dayWidth = rect.Width / daysToShow;

            // one day header rectangle
            Rectangle dayHeaderRectangle = new Rectangle(rect.Left, rect.Top, dayWidth, rect.Height);
            var headerDate = startDate;

            for (int day = 0; day < daysToShow; day++)
            {
                renderer.DrawDayHeader(e.Graphics, dayHeaderRectangle, headerDate);

                dayHeaderRectangle.X += dayWidth;
                headerDate = headerDate.AddDays(1);
            }
        }


        private void DrawDayHeaderInWeek(PaintEventArgs e, Rectangle rect, MyDateTime headerDate)
        {
          //  int dayWidth = rect.Width / daysToShow;

            // one day header rectangle
            //Rectangle dayHeaderRectangle = new Rectangle(rect.Left, rect.Top, dayWidth, rect.Height);
            //DateTime headerDate = startDate;

           // for (int day = 1; day <= daysToShow; day++)
            {
                renderer.DrawDayHeaderInWeekly(e.Graphics, rect, headerDate);

                //dayHeaderRectangle.X += dayWidth;
                //headerDate = headerDate.AddDays(1);
            }
        }

        private void DrawDayHeaderInMonthly(PaintEventArgs e, Rectangle rect, MyDateTime headerDate)
        {
            //  int dayWidth = rect.Width / daysToShow;

            // one day header rectangle
            //Rectangle dayHeaderRectangle = new Rectangle(rect.Left, rect.Top, dayWidth, rect.Height);
            //DateTime headerDate = startDate;

            // for (int day = 1; day <= daysToShow; day++)
            {
                renderer.DrawDayHeaderInMontly(e.Graphics, rect, headerDate);

                //dayHeaderRectangle.X += dayWidth;
                //headerDate = headerDate.AddDays(1);
            }
        }

		private Rectangle GetHourRangeRectangle(Rectangle baseRectangle)        //MyDateTime start, MyDateTime end,
		{
			switch (ViewDayType)
			{
				case ViewType.Day:
					Rectangle rect = baseRectangle;

					int startY;
					int endY;

					//startY = (start.Hour * halfHourHeight * TimeStep) + ((start.Minute * halfHourHeight) / (60 / TimeStep));
					//endY = (end.Hour * halfHourHeight * TimeStep) + ((end.Minute * halfHourHeight) / (60 / TimeStep));
					startY = (WorkingHourStart * halfHourHeight * TimeStep) + ((workingMinuteStart * halfHourHeight) / (60 / TimeStep));
					endY = (WorkingHourEnd * halfHourHeight * TimeStep) + ((WorkingMinuteEnd * halfHourHeight) / (60 / TimeStep));

					rect.Y = startY - scrollbar.Value + this.HeaderHeight;

					rect.Height = endY - startY;

					return rect;
					break;

				case ViewType.Weekly:
					rect = baseRectangle;
					rect.Height -= 18;
					rect.Y += 18;

					return rect;

					break;

				case ViewType.Monthly:
					rect = baseRectangle;
					rect.Height -= 24;
					rect.Y += 24;

					return rect;
					break;

				case ViewType.Yearly:

					break;
			}

			return new Rectangle();
		}
		private Rectangle GetHourRangeRectangleForAppointment(MyDateTime start, MyDateTime end, Rectangle baseRectangle)        
		{
			switch (ViewDayType)
			{
				case ViewType.Day:
					Rectangle rect = baseRectangle;

					int startY;
					int endY;

					startY = (start.Hour * halfHourHeight * TimeStep) + ((start.Minute * halfHourHeight) / (60 / TimeStep));
					endY = (end.Hour * halfHourHeight * TimeStep) + ((end.Minute * halfHourHeight) / (60 / TimeStep));

					rect.Y = startY - scrollbar.Value + this.HeaderHeight;

					rect.Height = endY - startY;

					return rect;
					break;

				case ViewType.Weekly:
					rect = baseRectangle;
					rect.Height -= 18;
					rect.Y += 18;

					return rect;

					break;

				case ViewType.Monthly:
					rect = baseRectangle;
					rect.Height -= 24;
					rect.Y += 24;

					return rect;
					break;

				case ViewType.Yearly:

					break;
			}

			return new Rectangle();
		}



		public int GetDayOfWeek(MyDateTime dt)
        {

            switch (dt.DayOfWeek)
            { 
                case DayOfWeek.Friday:
                    return 7;
                    break;
                case DayOfWeek.Monday:
                    return 3;
                    break;

                case DayOfWeek.Saturday:
                    return 1;
                    break;

                case DayOfWeek.Sunday:
                    return 2;
                    break;

                case DayOfWeek.Thursday:
                    return 6;
                    break;

                case DayOfWeek.Tuesday:
                    return 4;
                    break;

                case DayOfWeek.Wednesday:
                    return 5;

                    break;

                default :
                    break;
            }


            return 0;
        }


        /// <summary>
        /// این متد با دریافت یک روز تاریخ اولین روز هفته یعنی شنبه که روز در آن هفته قرار دارد بر می گرداند
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public MyDateTime getFirstDayOfWeek(MyDateTime dt)
        {
            var time = new MyDateTime(dt.m_GregoryDate);
            int iTemp = GetDayOfWeek(time);
            time = time.AddDays(-iTemp + 1);

            return time;
        }

        public MyDateTime getFirstDayOfMonth(MyDateTime dt)
        {
            var time = new MyDateTime(dt.m_GregoryDate);
            //int iTemp = (int)time.DayOfWeek + 1;
            time = time.AddDays(-dt.Day + 1);

            return time;
        }

        public MyDateTime getFirstDayOfYear(MyDateTime dt)
        {

            //این متد اصلاح شود
            var time = new MyDateTime(dt.m_GregoryDate);
            //int iTemp = (int)time.DayOfWeek + 1;
          //  time = time.AddDays(-dt.Day + 1);

            return time;
        }

        private void DrawDayInMonth(PaintEventArgs e, Rectangle rect, MyDateTime time)
        {
			//renderer.DrawDayBackground(e.Graphics, rect);

			//Rectangle workingHoursRectangle = GetHourRangeRectangle(workStart, workEnd, rect);
			Rectangle workingHoursRectangle = GetHourRangeRectangle( rect);

            if (workingHoursRectangle.Y < this.HeaderHeight)
                workingHoursRectangle.Y = this.HeaderHeight;

            //if (!((time.DayOfWeek == DayOfWeek.Friday) || (time.DayOfWeek == DayOfWeek.Wednesday))) //weekends off -> no working hours
            //    renderer.DrawHourRange(e.Graphics, workingHoursRectangle, false, false);

            e.Graphics.SetClip(rect);
            using (Pen aPen = new Pen(Color.FromArgb(141, 174, 217)))
                e.Graphics.DrawRectangle(aPen, rect);

            if (StartDate.Month == time.Month)
            {
                using (SolidBrush brush = new SolidBrush(Color.LightGoldenrodYellow))
                    e.Graphics.FillRectangle(brush, rect);
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(Color.Ivory))
                    e.Graphics.FillRectangle(brush, rect);
            }

            Rectangle HeadRec = rect;
            HeadRec.Height = 24;

          //  e.Graphics.DrawRectangle(new Pen(Color.Red), HeadRec);
            DrawDayHeaderInMonthly(e, HeadRec, time);
            if ((selection == SelectionType.DateRange) && (time.Day == selectionStart.Day) && time.Month == selectionStart.Month)
            {
                //  Rectangle selectRect = rect;

                ////  selectRect.Width = rect.Width / 2;
                //  if ((int)time.DayOfWeek >= 3)
                //  {
                //      selectRect.X += selectRect.Width;
                //  }

                Rectangle selectionRectangle = GetHourRangeRectangleForAppointment(selectionStart, selectionEnd, rect);

                renderer.DrawHourRange(e.Graphics, selectionRectangle, false, true);
            }
            //for (int hour = 0; hour < 24 * TimeStep; hour++)
            //{
            //    int y = rect.Top + (hour * halfHourHeight) - scrollbar.Value;

            //using (Pen pen = new Pen(((hour % TimeStep) == 0 ? renderer.HourSeperatorColor : renderer.HalfHourSeperatorColor)))
            //    e.Graphics.DrawLine(pen, rect.Left, y, rect.Right, y);

            //    if (y > rect.Bottom)
            //        break;
            //}

            //  renderer.DrawDayGripper(e.Graphics, rect, appointmentGripWidth);

            e.Graphics.ResetClip();

            rect.Height -= HeadRec.Height;
            rect.Y += HeadRec.Height;

            DrawAppointmentInMonthly(e, rect, time);
        }


        private void DrawDayInWeek(PaintEventArgs e, Rectangle rect, MyDateTime time)
        {
            //renderer.DrawDayBackground(e.Graphics, rect);




            //Rectangle workingHoursRectangle = GetHourRangeRectangle(workStart, workEnd, rect);
			Rectangle workingHoursRectangle = GetHourRangeRectangle(rect);

			if (workingHoursRectangle.Y < this.HeaderHeight)
                workingHoursRectangle.Y = this.HeaderHeight;

            //if (!((time.DayOfWeek == DayOfWeek.Friday) || (time.DayOfWeek == DayOfWeek.Wednesday))) //weekends off -> no working hours
            //    renderer.DrawHourRange(e.Graphics, workingHoursRectangle, false, false);

            

          

          //  e.Graphics.SetClip(rect);
            using (SolidBrush brush = new SolidBrush(Color.LightGoldenrodYellow))
                e.Graphics.FillRectangle(brush, rect);

            using (Pen aPen = new Pen(Color.FromArgb(141, 174, 217)))
                e.Graphics.DrawRectangle(aPen, rect);

       //     e.Graphics.DrawRectangle(new Pen(Color.Red ) , rect);

          

            Rectangle HeadRec = rect;
            HeadRec.Height = 18;

          

         

         //   e.Graphics.DrawRectangle(new Pen(Color.Red), HeadRec);

            DrawDayHeaderInWeek(e, HeadRec, time);



            if ((selection == SelectionType.DateRange)&& (time.Day == selectionStart.Day))
            {
                //  Rectangle selectRect = rect;

                ////  selectRect.Width = rect.Width / 2;
                //  if ((int)time.DayOfWeek >= 3)
                //  {
                //      selectRect.X += selectRect.Width;
                //  }


                Rectangle selectionRectangle = GetHourRangeRectangleForAppointment(selectionStart, selectionEnd, rect);

                renderer.DrawHourRange(e.Graphics, selectionRectangle, false, true);
            }
            //for (int hour = 0; hour < 24 * TimeStep; hour++)
            //{
            //    int y = rect.Top + (hour * halfHourHeight) - scrollbar.Value;

            //using (Pen pen = new Pen(((hour % TimeStep) == 0 ? renderer.HourSeperatorColor : renderer.HalfHourSeperatorColor)))
            //    e.Graphics.DrawLine(pen, rect.Left, y, rect.Right, y);

            //    if (y > rect.Bottom)
            //        break;
            //}

          //  renderer.DrawDayGripper(e.Graphics, rect, appointmentGripWidth);

            e.Graphics.ResetClip();

            rect.Height -= HeadRec.Height;
            rect.Y += HeadRec.Height;
            
            DrawAppointmentInWeekly(e, rect, time);
        }

        private void DrawDay(PaintEventArgs e, Rectangle rect, MyDateTime time)
        {
            //renderer.DrawDayBackground(e.Graphics, rect);




            //Rectangle workingHoursRectangle = GetHourRangeRectangle(workStart, workEnd, rect);
			Rectangle workingHoursRectangle = GetHourRangeRectangle(rect);

			if (workingHoursRectangle.Y < this.HeaderHeight)
                workingHoursRectangle.Y = this.HeaderHeight;

            if (!((time.DayOfWeek == DayOfWeek.Friday) || (time.DayOfWeek == DayOfWeek.Thursday))) //weekends off -> no working hours
                renderer.DrawHourRange(e.Graphics, workingHoursRectangle, false, false);

            if ((selection == SelectionType.DateRange) && (time.Day == selectionStart.Day))
            {
                Rectangle selectionRectangle = GetHourRangeRectangleForAppointment(selectionStart, selectionEnd, rect);

                renderer.DrawHourRange(e.Graphics, selectionRectangle, false, true);
            }

           
            e.Graphics.SetClip(rect);

            for (int hour = 0; hour < 24 * TimeStep; hour++)
            {
                int y = rect.Top + (hour * halfHourHeight) - scrollbar.Value;

                using (Pen pen = new Pen(((hour % TimeStep) == 0 ? renderer.HourSeperatorColor : renderer.HalfHourSeperatorColor)))
                    e.Graphics.DrawLine(pen, rect.Left, y, rect.Right, y);

                if (y > rect.Bottom)
                    break;
            }

            renderer.DrawDayGripper(e.Graphics, rect, appointmentGripWidth);

            e.Graphics.ResetClip();

            DrawAppointments(e, rect, time);
        }

        internal Dictionary<Appointment, AppointmentView> appointmentViews = new Dictionary<Appointment, AppointmentView>();


        private void DrawAppointmentInMonthly(PaintEventArgs e, Rectangle rect, MyDateTime time)
        {
            var timeStart = time.Date;
            var timeEnd = timeStart.AddHours(24);
            timeEnd = timeEnd.AddSeconds(-1);

            string strKey = time.Month.ToString() + time.Day.ToString();

            AppointmentList appointments = (AppointmentList)cachedAppointments[int.Parse(strKey)];

            if (appointments != null)
            {
                Rectangle appRect = rect;
                appRect.Height = 13;
                appRect.Width = rect.Width ;
                foreach (Appointment Appp in appointments)
                {
                    int TempHeghit = appRect.Y - rect.Y;
                    if (Appp != null && TempHeghit <= rect.Height)
                    {
                        e.Graphics.SetClip(appRect);

                        renderer.DrawAppointmentInWeekly(e.Graphics, appRect, Appp, Appp == selectedAppointment, appointmentGripWidth);

                        AppointmentView view = new AppointmentView();
                        view.Rectangle = appRect;
                        view.Appointment = Appp;

            //            //  appointmentViews[appointment] = view;

                        if (!appointmentViews.ContainsKey(Appp))
                        {
                            appointmentViews.Add(Appp, view);
                            appRect.Y += appRect.Height;
                            e.Graphics.ResetClip();
                        }

                      

                    }
                    else
                    {
                        appRect.X += appRect.Width;
                        appRect.Y = rect.Y;

                        e.Graphics.FillRectangle(new SolidBrush(Color.LightGreen), new Rectangle(rect.Location.X + rect.Width - 10, rect.Location.Y + rect.Height - 10, 7, 7));
                        //  break;
                    }
                }


           
            }
        }

        private void DrawAppointmentInWeekly(PaintEventArgs e, Rectangle rect, MyDateTime time)
        {
            var timeStart = time.Date;
            var timeEnd = timeStart.AddHours(24);
            timeEnd = timeEnd.AddSeconds(-1);

            string strKey = time.Month.ToString() + time.Day.ToString();

            AppointmentList appointments = (AppointmentList)cachedAppointments[int.Parse(strKey)];

            if (appointments != null)
            {
                Rectangle appRect = rect;
                appRect.Height = 20;
                appRect.Width = rect.Width / 3;
                foreach (Appointment Appp in appointments)
                {
                    int TempHeghit =appRect.Y -  rect.Y  ;

                    if (Appp != null && TempHeghit <= rect.Height)
                    {
                        e.Graphics.SetClip(appRect);
                        renderer.DrawAppointmentInWeekly(e.Graphics, appRect, Appp, Appp == selectedAppointment, appointmentGripWidth);

                        AppointmentView view = new AppointmentView();
                        view.Rectangle = appRect;
                        view.Appointment = Appp;
                        appointmentViews.Add(Appp, view);
                        appRect.Y += 20;
                        e.Graphics.ResetClip();

                    }
                    else
                    {
                        appRect.X += appRect.Width;
                        appRect.Y = rect.Y;
                        e.Graphics.FillRectangle(new SolidBrush(Color.LightGreen), new Rectangle(rect.Location.X + rect.Width - 10, rect.Location.Y + rect.Height - 10, 7, 7));
                      //  e.Graphics.DrawRectangle(new Pen(Color.Red), new Rectangle(rect.Location.X + rect.Width - 10, rect.Location.Y + rect.Height - 10, 7, 7));
                      //  break;
                    }
                }
               
            }
        }

        private void DrawAppointments(PaintEventArgs e, Rectangle rect, MyDateTime time)
        {
            var timeStart = time.Date;
            var timeEnd = timeStart.AddHours(24);
            timeEnd = timeEnd.AddSeconds(-1);

            string strKey = time.Month.ToString() + time.Day.ToString();

            AppointmentList appointments = (AppointmentList)cachedAppointments[int.Parse(strKey)];

            if (appointments != null)
            {

                HalfHourLayout[] layout = GetMaxParalelAppointments(appointments);
                List<Appointment> drawnItems = new List<Appointment>();

                for (int halfHour = 0; halfHour < 24 * TimeStep; halfHour++)
                {
                    HalfHourLayout hourLayout = layout[halfHour];

                    if ((hourLayout != null) && (hourLayout.Count > 0))
                    {
                        for (int appIndex = 0; appIndex < hourLayout.Count; appIndex++)
                        {
                            Appointment appointment = hourLayout.Appointments[appIndex];

                            if (drawnItems.IndexOf(appointment) < 0)
                            {
                                Rectangle appRect = rect;
                                int appointmentWidth;
                                AppointmentView view;

                                appointmentWidth = rect.Width / appointment.m_ConflictCount;

                                int lastX = 0;

                                foreach (Appointment app in hourLayout.Appointments)
                                {
                                    if ((app != null) && (appointmentViews.ContainsKey(app)))
                                    {
                                        view = appointmentViews[app];

                                        if (lastX < view.Rectangle.X)
                                            lastX = view.Rectangle.X;
                                    }
                                }

                                if ((lastX + (appointmentWidth * 2)) > (rect.X + rect.Width))
                                    lastX = 0;

                                appRect.Width = appointmentWidth - 5;

                                if (lastX > 0)
                                    appRect.X = lastX + appointmentWidth;

                                appRect = GetHourRangeRectangleForAppointment(appointment.StartDate, appointment.EndDate, appRect);

                                view = new AppointmentView();
                                view.Rectangle = appRect;
                                view.Appointment = appointment;

                                appointmentViews[appointment] = view;

                                e.Graphics.SetClip(rect);

                                renderer.DrawAppointment(e.Graphics, appRect, appointment, appointment == selectedAppointment, appointmentGripWidth);

                                e.Graphics.ResetClip();

                                drawnItems.Add(appointment);
                            }
                        }
                    }
                }
            }
        }

        private HalfHourLayout[] GetMaxParalelAppointments(List<Appointment> appointments)
        {
            HalfHourLayout[] appLayouts = new HalfHourLayout[24 * TimeStep];

            foreach (Appointment appointment in appointments)
            {
                appointment.m_ConflictCount = 1;
            }

            foreach (Appointment appointment in appointments)
            {
                int firstHalfHour = appointment.StartDate.Hour * TimeStep + (appointment.StartDate.Minute / (60 / TimeStep));
                int lastHalfHour = appointment.EndDate.Hour * TimeStep + (appointment.EndDate.Minute / (60 / TimeStep));

                for (int halfHour = firstHalfHour; halfHour < lastHalfHour; halfHour++)
                {
                    HalfHourLayout layout = appLayouts[halfHour];

                    if (layout == null)
                    {
                        layout = new HalfHourLayout();
                        layout.Appointments = new Appointment[(60 / TimeStep)];
                        appLayouts[halfHour] = layout;
                    }

                    layout.Appointments[layout.Count] = appointment;
                    layout.Count++;

                    // update conflicts
                    foreach (Appointment app2 in layout.Appointments)
                    {
                        if (app2 != null)
                            if (app2.m_ConflictCount < layout.Count)
                                app2.m_ConflictCount = layout.Count;
                    }
                }
            }

            return appLayouts;
        }

        private void DrawWeekly(PaintEventArgs e, Rectangle rect)
        {
            int dayWidth = rect.Width / 2;

            int dayHeight = rect.Height / 3;

            // ALL DAY EVENTS IS NOT COMPLETE
			
            //AppointmentList longAppointments = (AppointmentList)cachedAppointments[2];

            //int y = dayHeadersHeight;

            //if (longAppointments != null)
            //{
            //    Rectangle backRectangle = rect;
            //    backRectangle.Y = y;
            //    backRectangle.Height = allDayEventsHeaderHeight;

            //    renderer.DrawAllDayBackground(e.Graphics, backRectangle);

            //    foreach (Appointment appointment in longAppointments)
            //    {
            //        Rectangle appointmenRect = rect;

            //        appointmenRect.Width = (dayWidth * (appointment.EndDate.Day - appointment.StartDate.Day));
            //        appointmenRect.Height = horizontalAppointmentHeight;
            //        appointmenRect.X += (appointment.StartDate.Day - startDate.Day) * dayWidth;
            //        appointmenRect.Y = y;

            //        renderer.DrawAppointment(e.Graphics, appointmenRect, appointment, appointment == selectedAppointment, appointmentGripWidth);

            //        y += horizontalAppointmentHeight;
            //    }
            //}
            

            var time = new MyDateTime(startDate.m_GregoryDate);


            while (time.DayOfWeek != DayOfWeek.Saturday)
            {
                time = time.AddDays(-1);
            }

            //int iTemp = (int)time.DayOfWeek + 1;

            // time = time.AddDays(-iTemp);
            //time.Day = time.Day - iTemp;
            //time.m_GregoryDate.da

            Rectangle rectangle = rect;
            rectangle.Width = dayWidth;
            rectangle.Height = dayHeight;
            rectangle.X += dayWidth;
            appointmentViews.Clear();

            for (int day = 1; day <= 7; day++)
            {

                if (SelectionStart == null)
                {
                    //SelectionStart =new DateTime(System.DateTime(((long)(0));
                    SelectionStart = new MyDateTime(new System.DateTime((long)(0)));
                }

                if (SelectionEnd == null)
                {
                    SelectionEnd = new MyDateTime(new System.DateTime((long)(0)));
                }




                DrawDayInWeek(e, rectangle, time);

                if (day == 6 || day == 5)
                {
                   
                    if (day == 5)
                    {
                        rectangle.Y += dayHeight ;
                        rectangle.Height = rectangle.Height / 2;
                    }
                    else
                    {
                        
                        rectangle.Y += dayHeight / 2;
                       // rectangle.Height = rectangle.Height / 2;
                       
                    }
                   
                }
                else
                {
                    
                    if (day == 3)
                    {
                        rectangle.X -= dayWidth;
                        rectangle.Y = this.HeaderHeight;
                    }
                    else
                    {
                       
                        rectangle.Y += dayHeight;
                    }
                }
                
                time = time.AddDays(1);
            }
        }

        private void DrawMonthly(PaintEventArgs e, Rectangle rect)
        {
            int dayWidth = rect.Width / 7;

            int dayHeight = rect.Height / 6;

            var time = getFirstDayOfMonth(startDate);

            while (time.DayOfWeek != DayOfWeek.Saturday)
            {
               time =  time.AddDays(-1);
            }

          //  time = getFirstDayOfWeek(time);

            //int iTemp = (int)time.DayOfWeek + 1;

            //time = time.AddDays(-iTemp);
            //time.Day = time.Day - iTemp;
            //time.m_GregoryDate.da

            Rectangle rectangle = rect;
            rectangle.Width = dayWidth;
            rectangle.Height = dayHeight;

            appointmentViews.Clear();

            for (int day = 1; day <= 42; day++)
            {
                if (SelectionStart == null)
                {
                    //SelectionStart =new DateTime(System.DateTime(((long)(0));
                    SelectionStart = new  MyDateTime (new System.DateTime((long)(0)));
                }

                if (SelectionEnd == null)
                {
                    SelectionEnd = new  MyDateTime (new System.DateTime((long)(0)));
                }

                DrawDayInMonth(e, rectangle, time);

                rectangle.X += dayWidth;
                if (day % 7 == 0)
                {
                    rectangle.X = 0;
                    rectangle.Y += dayHeight;
                }

                time = time.AddDays(1);
            }
        }

        private void DrawDays(PaintEventArgs e, Rectangle rect)
        {
            int dayWidth = rect.Width / daysToShow;

			/* ALL DAY EVENTS IS NOT COMPLETE
			
            AppointmentList longAppointments = (AppointmentList)cachedAppointments[-1];

            int y = dayHeadersHeight;

            if (longAppointments != null)
            {
                Rectangle backRectangle = rect;
                backRectangle.Y = y;
                backRectangle.Height = allDayEventsHeaderHeight;

                renderer.DrawAllDayBackground(e.Graphics, backRectangle);

                foreach (Appointment appointment in longAppointments)
                {
                    Rectangle appointmenRect = rect;

                    appointmenRect.Width = (dayWidth * (appointment.EndDate.Day - appointment.StartDate.Day));
                    appointmenRect.Height = horizontalAppointmentHeight;
                    appointmenRect.X += (appointment.StartDate.Day - startDate.Day) * dayWidth;
                    appointmenRect.Y = y;

                    renderer.DrawAppointment(e.Graphics, appointmenRect, appointment, appointment == selectedAppointment, appointmentGripWidth);

                    y += horizontalAppointmentHeight;
                }
            }
            */

            var time = new MyDateTime(startDate.m_GregoryDate);
            Rectangle rectangle = rect;
            rectangle.Width = dayWidth;

            appointmentViews.Clear();

            for (int day = 0; day < daysToShow; day++)
            {



                if (SelectionStart == null)
                {
                    //SelectionStart =new DateTime(System.DateTime(((long)(0));
                    SelectionStart = new  MyDateTime (new  System.DateTime((long)(0)));
                }

                if (SelectionEnd == null)
                {
                    SelectionEnd = new  MyDateTime (new System.DateTime((long)(0)));
                }
                DrawDay(e, rectangle, time);
                

                rectangle.X += dayWidth;
                time = time.AddDays(1);
            }
        }

        #endregion

        #region Internal Utility Classes

        class HalfHourLayout
        {
            public int Count;
            public Appointment[] Appointments;
        }

        internal class AppointmentView
        {
            public Appointment Appointment;
            public Rectangle Rectangle;
        }

        class AppointmentList : List<Appointment>
        {
        }

        #endregion

        #region Events

        public event EventHandler SelectionChanged;
        public event ResolveAppointmentsEventHandler ResolveAppointments;
        public event NewAppointmentEventHandler NewAppointment;
        public event EventHandler<AppointmentEventArgs> AppoinmentMove;
        public event EventHandler<AppointmentEventArgs> AppoinmentMoved;
        public event EventHandler<AppointmentEventArgs> AppoinmentMouseDoubleClick;
        

        #endregion
    }
}
